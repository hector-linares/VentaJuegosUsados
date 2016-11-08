using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VentaJuegosUsados.Startup))]
namespace VentaJuegosUsados
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
