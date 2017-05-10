using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DZero_DB_dict.Startup))]
namespace DZero_DB_dict
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
