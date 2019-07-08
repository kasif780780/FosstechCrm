using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FossTechCrm.Startup))]
namespace FossTechCrm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
