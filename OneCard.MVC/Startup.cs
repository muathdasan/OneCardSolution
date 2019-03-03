using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneCard.MVC.Startup))]
namespace OneCard.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
