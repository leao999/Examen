using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLuisArrieta.Startup))]
namespace WebLuisArrieta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
