using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Test
    {
        public static async void write()
        {
            //Func<Task> taskFunc = () =>
            //{
            //    return Task.Run(() =>
            //    {
            //        Thread.Sleep(1000);
            //        Console.WriteLine("333");
            //    });
            //};

            //Console.WriteLine("111");
            await Task.Run(() =>
            {
                Thread.Sleep(1000);  //异步执行一些任务
                Console.WriteLine("222");
            });
            double num1 = 1234.5;
            double num2 = 1.01;
            await Task.Run(()=> {
                for (int i = 0; i < 1000000; i++)
                {
                    num1 = num1 / num2;
                }
                Console.WriteLine(num1);
            });
            Console.WriteLine("444");
        }
    }
}
