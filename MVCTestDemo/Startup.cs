using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DZero.Mvc.TestDemo.Startup))]
namespace DZero.Mvc.TestDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
