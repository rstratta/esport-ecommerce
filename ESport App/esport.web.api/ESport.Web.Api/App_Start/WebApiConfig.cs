using ESport.DependencyResolver;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace ESport.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			 
			var container = new UnityContainer();
            config.EnableCors();
            ComponentLoader.LoadContainer(container, ".\\bin", "ESport.*.dll");

            config.DependencyResolver = new UnityResolver(container);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
