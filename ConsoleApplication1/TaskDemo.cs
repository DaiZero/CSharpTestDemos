using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZero.ConsoleApp.TestDemo
{
    public class TaskDemo
    {
        private static int workThreadNums = 0;

        private static bool isStop = false;

        public static void MainTest()
        {
            var tasks = new Task[10];


            for (int i = 0; i < 10; i++)
            {
                tasks[i] = Task.Factory.StartNew((obj) =>
                {
                    Run();
                }, i);
            }

            //是否退出
            string input = Console.ReadLine();

            while ("Y".Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            isStop = true;

            while (workThreadNums != 0)
            {
                Console.WriteLine("正在等待线程结束，当前还在运行线程有：{0}", workThreadNums);

                Thread.Sleep(10);
            }
            Console.WriteLine("准备退出了。。。");
            Console.Read();
            Environment.Exit(0);
        }

        static void Run()
        {
            try
            {
                workThreadNums++;

                while (true)
                {
                    if (isStop) break;

                    Thread.Sleep(1000);

                    //执行业务逻辑
                    Console.WriteLine("我是线程:{0}，正在执行业务逻辑", Thread.CurrentThread.ManagedThreadId);
                }
            }
            finally
            {
                workThreadNums--;
            }
        }

       public
            
            static void MainTest2()
        {
            CancellationTokenSource source = new CancellationTokenSource();

            var tasks = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                tasks[i] = Task.Factory.StartNew((m) =>
                {
                    Run(source.Token);
                }, i);
            }

            Task.WhenAll(tasks).ContinueWith((t) =>
            {
                Console.WriteLine("准备退出了。。。");
                Console.Read();
                Environment.Exit(0);
            });

            string input = Console.ReadLine();
            while ("Y".Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                source.Cancel();
            }

            Console.Read();
        }
        static void Run(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested) break;

                Thread.Sleep(1000);

                //执行业务逻辑
                Console.WriteLine("我是线程:{0}，正在执行业务逻辑", Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}
