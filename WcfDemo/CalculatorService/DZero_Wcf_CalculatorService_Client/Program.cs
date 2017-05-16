
using DZero_Wcf_CalculatorService_Client.CalculatorService;
using System;
using System.Diagnostics;
using System.Reflection;

namespace DZero_Wcf_CalculatorService_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string strNum = ChooseNumber();
            Write(strNum);
            Console.ReadKey();
        }

        public static string ChooseNumber()
        {
            Console.WriteLine("---------Choose the Fuction----------");
            Console.WriteLine("---------输入数字 1 进入 加法------- ");
            Console.WriteLine("---------输入数字 2 进入 减法------- ");
            Console.WriteLine("---------输入数字 3 进入 乘法------- ");
            Console.WriteLine("---------输入数字 4 进入 除法----- ");
            Console.WriteLine("----------------------------------- ");
            Console.Write("---------输入数字:");
            return Console.ReadLine().ToString();
        }

        public static void Write(string strChooseNo)
        {
            using (CalculatorServiceClient proxy = new CalculatorServiceClient())
            {
                switch (strChooseNo)
                {
                    case "1":
                        Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
                        Write(ChooseNumber());
                        break;
                    case "2":
                        Console.WriteLine("x - y = {2} when x = {0} and y = {1}", 1, 2, proxy.Subtract(1, 2));
                        Write(ChooseNumber());
                        break;
                    case "3":
                        Console.WriteLine("x * y = {2} when x = {0} and y = {1}", 1, 2, proxy.Multiply(1, 2));
                        Write(ChooseNumber());
                        break;
                    case "4":
                        Console.WriteLine("x / y = {2} when x = {0} and y = {1}", 1, 2, proxy.Divide(1, 2));
                        Write(ChooseNumber());
                        break;
                    default:
                        Console.WriteLine("输入错误，请重新输入数字！");
                        Write(ChooseNumber());
                        break;
                }
            }
        }

    }
}
