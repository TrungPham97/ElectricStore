using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ElectronicStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "Payment",
             url: "thanh-toan",
             defaults: new { controller = "CheckOut", action = "Payment", id = UrlParameter.Optional },
             namespaces: new[] { "ElectricStore.Controllers" }
             );

            routes.MapRoute(
             name: "Checkout",
             url: "don-hang",
             defaults: new { controller = "CheckOut", action = "index", id = UrlParameter.Optional },
             namespaces: new[] { "ElectricStore.Controllers" }
             );

            routes.MapRoute(
             name: "Product",
             url: "san-pham",
             defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "ElectricStore.Controllers" }
             );

            routes.MapRoute(
                 name: "Product Detail",
                 url: "chi-tiet/{meta-title}-{id}",
                 defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                 namespaces: new[] { "ElectricStore.Controllers" }
             );
            routes.MapRoute(
             name: "Home",
             url: "trang-chu",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "ElectricStore.Controllers" }
             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ElectricStore.Controllers" }
            );


        }
    }
}
