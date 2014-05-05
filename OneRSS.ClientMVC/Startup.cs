using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneRSS.ClientMVC.Startup))]
namespace OneRSS.ClientMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
