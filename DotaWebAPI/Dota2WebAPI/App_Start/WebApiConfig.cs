using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Logger;

namespace Dota2WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes(); 

            config.Services.Add(typeof(IExceptionLogger), new NLogExceptionLogger()); 
            //config.Services.Add(typeof(ExceptionFilterAttribute), ExceptionFilterAttribute);
            //var cors = new EnableCorsAttribute("http://localhost:12028/", "*", "*");
            //config.EnableCors(cors);
           // config.Routes.MapHttpRoute(
           //     name: "DefaultApi",
           //     routeTemplate: "api/{controller}/{id}",
           //     defaults: new { id = RouteParameter.Optional }
           // );
           //// config.Routes.MapHttpRoute(
           ////    name: "DefaultApiEmpty",
           ////    routeTemplate: "api/{controller}",
           ////    defaults: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
           ////);
           // config.Routes.MapHttpRoute(
           //     name: "DefaultApiPostWithId2",
           //     routeTemplate: "api/{controller}/{action}/{id}",
           //     defaults: new { id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
           //     );
           // config.Routes.MapHttpRoute(
           //     name: "DefaultApiPost",
           //     routeTemplate: "api/{controller}/{action}",
           //     defaults: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
           //     );
           // config.Routes.MapHttpRoute(
           //     name: "DefaultApiGet",
           //     routeTemplate: "api/{controller}/{action}",
           //     defaults: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
           //     );

            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
