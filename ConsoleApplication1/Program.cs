using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DZero.ConsoleApp.TestDemo
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
            //B b = new B();
            //Console.ReadLine();
            ////A a1 = new A();
            //A a2 = new B();
            //Console.ReadLine();

            //TaskDemo.MainTest();
            //TaskDemo.MainTest2();

            //委托
            //Delegate_Event_Demo ded = new Delegate_Event_Demo();
            //MyDelegate md = ded.ShowMsg;//将实例化的方法赋值给委托实例,
            //md+= ded.ShowMsgBox;//"+="
            //md("Hello World");
            //CallbackMethod(100,50, md);
            //Console.ReadLine();


            //异步
            //Test.write();
            //Console.ReadLine();



            //new EF_Test().Add();
            //new EF_Test().Add2();
            //new EF_Test().Delete();
            //Console.ReadLine();

            //var s= new Dapper_Test().QueryAll();
            // Console.ReadLine();

            //EF 和 Dapper 
            //查询表数据
            int SelTimes = 1;
            Stopwatch wach = new Stopwatch();
            wach.Start();
            for (int i = 0; i < SelTimes; i++)
            {
                new EF_Test().QueryAll();
            }
            wach.Stop();
            Console.WriteLine($"EF 查表 {SelTimes} 次，花费时间： {wach.ElapsedMilliseconds} 毫秒。");
            wach.Reset();
            wach.Start();
            for (int i = 0; i < SelTimes; i++)
            {
                new Dapper_Test().QueryAll();
            }
            wach.Stop();
            Console.WriteLine($"Dapper 查表 {SelTimes} 次，花费时间： {wach.ElapsedMilliseconds} 毫秒。");
            Console.ReadLine();

        }

        private static void CallbackMethod(int m, int n, MyDelegate dlg)
        {
            dlg((m + n).ToString());
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
