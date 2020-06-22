using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialDataFeed.Startup))]
namespace SocialDataFeed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
