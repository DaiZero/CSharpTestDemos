using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Nullable<int> x = 1;
            int? y = null;
            y++;
            Console.WriteLine("{0}{1}{2}{3}", x.HasValue, x.GetValueOrDefault(), y.HasValue, y.GetValueOrDefault());
            if (x<y)
            {
                Console.WriteLine("X<y");
            }
            else
            {
                Console.WriteLine("x>y");
            }
            Console.ReadLine();
        }
    }
}
