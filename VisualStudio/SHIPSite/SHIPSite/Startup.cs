using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SHIPSite.Startup))]
namespace SHIPSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
