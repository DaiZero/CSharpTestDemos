using AutoMapper;
using System;
using System.Diagnostics;

namespace DZero.ConsoleApp.TestDemo.AutoMapper
{
    public class DZeroProFile : Profile
    {
       public DZeroProFile()
        {
            //名称自动匹配，映射
            Stopwatch watch = new Stopwatch();
            watch.Start();
            CreateMap<Source1Model, Destination1Model>();
            watch.Stop();
            Console.WriteLine($"CreateMap<Source1Model, Destination1Model>花费时间：{watch.ElapsedMilliseconds} 毫秒.");
        }
    }
}
