using DZero_Wcf_CalculatorService_Contracts;
using DZero_Wcf_CalculatorService_Services;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace DZero_Wcf_CalculatorService_Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                #region 服务寄宿代码,可在config里面配置
                //host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "http://127.0.0.1:9999/calculatorservice");
                // if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                // {
                //     ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                //     behavior.HttpGetEnabled = true;
                //     behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/calculatorservice/metadata");
                //     host.Description.Behaviors.Add(behavior);
                // }

                #endregion

                host.Opened += delegate
                {
                    Console.WriteLine("CalculaorService已经启动，按任意键终止服务！");
                };
                host.Open();
                Console.Read();
            }
        }
    }
}
