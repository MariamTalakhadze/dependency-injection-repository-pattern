using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.Mvc5;

namespace PWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}