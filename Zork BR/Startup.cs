using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zork_BR.Startup))]
namespace Zork_BR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
