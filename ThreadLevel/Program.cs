using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLevel
{
    class Program
    {
        static FileStream fs = new FileStream("d:/a.txt",FileMode.Append);
       static StringBuilder sb = new StringBuilder(6*30*1000);
        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ParameterizedThreadStart(run));
            Thread th2 = new Thread(new ParameterizedThreadStart(run));
            Thread th3 = new Thread(new ParameterizedThreadStart(run));
            Thread th4 = new Thread(new ParameterizedThreadStart(run));
            Thread th5 = new Thread(new ParameterizedThreadStart(run));

            th1.Priority = ThreadPriority.Highest;
            th2.Priority = ThreadPriority.AboveNormal;
            th3.Priority = ThreadPriority.Normal;
            th4.Priority = ThreadPriority.BelowNormal;
            th5.Priority = ThreadPriority.Lowest;




            th1.Start(1);
            th2.Start(2);
            th3.Start(3);
            th4.Start(4);
            th5.Start(6);


            Thread.Sleep(10000);
            byte[] b = System.Text.Encoding.Default.GetBytes(sb.ToString());
            fs.WriteAsync(b,0,b.Length);

        }
        public static void run(object obj)
        {
            
            int i = 0;
            while (i < 1000)
            {
                sb.Append(string.Format("{0}:{1}:{2}\r\n", obj,DateTime.Now.Ticks.ToString(),i));
                i++;               
            }
        }
    }
}
