using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace threadspace
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(run));
            Thread th2 = new Thread(new ParameterizedThreadStart(run1));
            Console.WriteLine("thread start ....");

            th.Start();
            th2.Start(11);
           // th2.Start("object");
            Console.WriteLine("hello world");
            Console.Read();
        }
        public static void run()
        {
            bool state = Thread.CurrentThread.IsAlive;
            Thread.Sleep(5000);
            Console.WriteLine(state);
            Console.WriteLine("new thread");

        }
        public static void run1(object str)
        {
            Console.WriteLine("run {0}",str);
        }
    }
}
