using log4net;
using MPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static log4net.ILog log;
        static void Main(string[] args)
        {
            log4net.GlobalContext.Properties["LogName"] = "Kenny";
            log = log4net.LogManager.GetLogger(typeof(Program));
            log.Info("programme start");
            Console.WriteLine("programme start");
            Console.ReadKey();
        }
    }
}
