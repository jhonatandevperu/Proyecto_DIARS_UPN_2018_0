using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EscalaConstructoresSAC.Startup))]
namespace EscalaConstructoresSAC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
