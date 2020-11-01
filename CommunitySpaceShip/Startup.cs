using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommunitySpaceShip.Startup))]
namespace CommunitySpaceShip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
