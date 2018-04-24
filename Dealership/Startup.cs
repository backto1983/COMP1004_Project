using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dealership.Startup))]
namespace Dealership
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
