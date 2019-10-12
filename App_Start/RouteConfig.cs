using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Routing;
using System.Web.Script.Serialization;
using Microsoft.AspNet.FriendlyUrls;
using Newtonsoft.Json;
using Practica3_4.Helpers;
using Practica3_4.Models;

namespace Practica3_4
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            cargarData.cargar();
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
