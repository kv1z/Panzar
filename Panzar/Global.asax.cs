namespace Panzar
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Panzar.DAL;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Database.SetInitializer(new UserInitializer());

            RegisterRoutes(RouteTable.Routes);
        }
    }
}