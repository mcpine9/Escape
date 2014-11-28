using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EscapeMobility.Startup))]
namespace EscapeMobility
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
