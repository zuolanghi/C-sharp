using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process1
{
    class Program
    {
        static void Main(string[] args)
        {

            Process []ps=Process.GetProcesses();
            foreach(Process p in ps)
            {
                try
                {
                p.Kill();

                }catch(Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            Console.Read();
        }

    }

}
