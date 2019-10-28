using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using Practica3_4.Helpers;

namespace Practica3_4
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            CargarData.cargar();
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
