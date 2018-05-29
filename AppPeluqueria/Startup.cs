using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppPeluqueria.Startup))]
namespace AppPeluqueria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
