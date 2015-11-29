using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotaMVCRepresentationLayer.Startup))]
namespace DotaMVCRepresentationLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
