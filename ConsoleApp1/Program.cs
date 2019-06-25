using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
           var v = Convert.ChangeType("2018/3/2T01:10:00", typeof(DateTime));
            int i = 0;
            for (var j=0;j<10;j++) {
                Console.WriteLine((++i) * 10);
            }
            DateTime dt = DateTime.MinValue;
            if (dt < DateTime.Now) {
                Console.WriteLine(dt);
            }
            if (dt == DateTime.MinValue) {
                Console.WriteLine(dt);
            }
        }
    }
}
