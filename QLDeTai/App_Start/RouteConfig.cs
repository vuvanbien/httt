using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLDeTai
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "GiaoVien",
              url: "giao-vien",
              defaults: new { controller = "GiaoVien", action = "Index", alias = UrlParameter.Optional },
              namespaces: new[] { "QLDeTai.Controllers" }
          );
            routes.MapRoute(
             name: "HocVien",
             url: "hoc-vien",
             defaults: new { controller = "HocVien", action = "Index", alias = UrlParameter.Optional },
             namespaces: new[] { "QLDeTai.Controllers" }
         );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
