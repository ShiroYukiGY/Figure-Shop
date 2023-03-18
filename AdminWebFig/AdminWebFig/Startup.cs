using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminWebFig.Startup))]
namespace AdminWebFig
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
