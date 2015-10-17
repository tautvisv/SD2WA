using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotaWebAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //routes.MapHttpRoute(
            //    name: "DefaultApiPostWithId",
            //    routeTemplate: "rest/{controller}/{action}/{id}",
            //    defaults: new { id = UrlParameter.Optional, httpMethod = new HttpMethodConstraint("post") }
            //    //constraints: new {id=@"\d+"} // ID formatas
            //    );

            //routes.MapHttpRoute(
            //    name: "DefaultApiPost",
            //    routeTemplate: "Api/{controller}/{action}",
            //    defaults: new { httpMethod = new HttpMethodConstraint("post") }
            //    //constraints: new {id=@"\d+"} // ID formatas
            //    );


            

            //routes.MapHttpRoute("DefaultApiWithAction", "Api/{controller}/{action}");
            //routes.MapHttpRoute(
            //    "DefaultApiWithId",
            //    "Api/{controller}/{id}", 
            //    new { id = RouteParameter.Optional },
            //    new { id = @"\d+" });
            
            //routes.MapHttpRoute(
            //    "DefaultApiGet", "Api/{controller}", 
            //    new { action = "Get" },
            //    new { httpMethod = new HttpMethodConstraint("get") });


            //routes.MapHttpRoute("DefaultApiPost", "Api/{controller}/{action}",
            //    new { action = "Post" },
            //    new { httpMethod = new HttpMethodConstraint("post") });
            //routes.MapHttpRoute(
            //    name: "API Default",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional },
                
            //    );
        }
    }
}