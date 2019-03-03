using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OneCard.MVC.Helpers
{
    public class AppSettingHelper
    {
        //public static bool IsDebugMode => HttpContext.Current.IsDebuggingEnabled;
        //public static bool IsDevelopement => bool.Parse(ConfigurationManager.AppSettings["IsDevelopment"]);
        //public static bool IsStaging => bool.Parse(ConfigurationManager.AppSettings["IsStaging"]);
        //public static bool IsProduction => bool.Parse(ConfigurationManager.AppSettings["IsProduction"]);

        public static string SiteName => ConfigurationManager.AppSettings["MvcTemplate:SiteName"] ?? "#SiteName";
    }
}