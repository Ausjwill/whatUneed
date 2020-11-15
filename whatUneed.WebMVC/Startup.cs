using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(whatUneed.WebMVC.Startup))]
namespace whatUneed.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
