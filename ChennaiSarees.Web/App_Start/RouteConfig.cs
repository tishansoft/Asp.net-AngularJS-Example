using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChennaiSarees.Web
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          name: "ProductsRoute",
          url: "product/{action}",
          defaults: new { controller = "product", action = "Empty" }
      );
      routes.MapRoute(
        name: "ShoppingCartRoute",
        url: "ShoppingCart/{action}",
        defaults: new { controller = "ShoppingCart", action = "Empty" }
      );
      routes.MapRoute(
          name: "Default",
          url: "{*catchAll}",
          defaults: new { controller = "Default", action = "Main", catchAll = UrlParameter.Optional }
      );
    }
  }
}