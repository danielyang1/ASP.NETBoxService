using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Crafty.Startup))]
namespace Crafty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
