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
            //Nullable<int> x = 1;
            //int? y = null;
            //y++;
            //Console.WriteLine("{0}{1}{2}{3}", x.HasValue, x.GetValueOrDefault(), y.HasValue, y.GetValueOrDefault());
            //if (x < y)
            //{
            //    Console.WriteLine("X<y");
            //}
            //else
            //{
            //    Console.WriteLine("x>y");
            //}
            B b = new B();
            Console.ReadLine();
            //A a1 = new A();
            A a2 = new B();
            Console.ReadLine();
        }
        class B : A
        {
            static B()
            {
                Console.Write("B-static ");
            }

            public B()
            {
                Console.Write("B-base ");
            }
        };

        class A
        {
            static A()
            {
                Console.Write("A-static ");
            }

            public A()
            {
                Console.Write("A-base ");
            }
        };

    }
}
