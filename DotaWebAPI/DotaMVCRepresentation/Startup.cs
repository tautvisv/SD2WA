using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotaMVCRepresentation.Startup))]
namespace DotaMVCRepresentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
