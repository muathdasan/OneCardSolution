using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneCard.Startup))]
namespace OneCard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
