using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace weight_wise_Invoice
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

            routes.MapRoute(
                name: " WeightWiseWeightInvoice",
                url: "WeightWiseWeightInvoice",
                defaults: new { controller = "WeightWise", action = "WeightInvoice" }
            );
            routes.MapRoute(
               name: " WeightWiseGenerateInvoice",
               url: "WeightWiseGenerateInvoice",
               defaults: new { controller = "WeightWise", action = "GenerateInvoice" }
           );
            routes.MapRoute(
             name: " WeightPaymentPaymentForm",
             url: "WeightPaymentPaymentForm",
             defaults: new { controller = "WeightPayment", action = "PaymentForm" }
         );
        }
    }
}
