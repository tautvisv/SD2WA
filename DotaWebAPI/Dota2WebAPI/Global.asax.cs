using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using DataCache;
using NLog;

namespace Dota2WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
        }

    }
}
