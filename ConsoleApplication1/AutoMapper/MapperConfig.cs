using AutoMapper;
namespace DZero.ConsoleApp.TestDemo.AutoMapper
{
    public class MapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DZeroProFile>();
            });
        }
    }
}
