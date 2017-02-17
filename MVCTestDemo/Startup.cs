using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCTestDemo.Startup))]
namespace MVCTestDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
