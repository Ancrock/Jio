using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jio.Startup))]
namespace Jio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
