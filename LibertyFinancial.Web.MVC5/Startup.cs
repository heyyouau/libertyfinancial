using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibertyFinancial.Web.MVC5.Startup))]
namespace LibertyFinancial.Web.MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
