using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OneCard.MVC
{
    public class CultureConstraint : IRouteConstraint
    {
        private readonly string defaultCulture;
        private readonly string pattern;

        public CultureConstraint(string defaultCulture, string pattern)
        {
            this.defaultCulture = defaultCulture;
            this.pattern = pattern;
        }
        public bool Match(
            HttpContextBase httpContext,
            Route route,
            string parameterName,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.UrlGeneration &&
                this.defaultCulture.Equals(values[parameterName]))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch((string)values[parameterName], "^" + pattern + "$");
            }
        }
    }
    public class RouteConfig
    {
        
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DefaultWithCulture",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { culture = new CultureConstraint(defaultCulture: "ar-SY", pattern: "[a-z,A-Z]{2}") },
                namespaces: new string[] { "OneCard.MVC.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, },
                namespaces: new string[] { "OneCard.MVC.Controllers" }
            );
        }
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        name: "Default",
        //        url: "{controller}/{action}/{id}",
        //        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        //    );
        //}
    }
}
