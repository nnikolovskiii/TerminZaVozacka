using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TerminZaVozacka.Startup))]
namespace TerminZaVozacka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
