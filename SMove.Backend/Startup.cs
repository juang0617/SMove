using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMove.Backend.Startup))]
namespace SMove.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
