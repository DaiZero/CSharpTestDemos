using DZero_Wcf_CalculatorService_Contracts;
using System;
using System.Diagnostics;
using System.Reflection;

namespace DZero_Wcf_CalculatorService_Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class CalculatorService : ICalculator
    {
        string machineName = Environment.MachineName;
        public double Add(double x, double y)
        {
            MethodBase m = new StackTrace().GetFrame(0).GetMethod();
            Console.WriteLine($"{machineName} 正在使用{m}方法被使用！");
            return x + y;
        }

        public double Divide(double x, double y)
        {
            MethodBase m = new StackTrace().GetFrame(0).GetMethod();
            Console.WriteLine($"{machineName} 正在使用{m}方法被使用！");
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            MethodBase m = new StackTrace().GetFrame(0).GetMethod();
            Console.WriteLine($"{machineName} 正在使用{m}方法被使用！");
            return x * y;
        }

        public double Subtract(double x, double y)
        {
            MethodBase m = new StackTrace().GetFrame(0).GetMethod();
            Console.WriteLine($"{machineName} 正在使用{m}方法被使用！");
            return x / y;
        }

    }
}
