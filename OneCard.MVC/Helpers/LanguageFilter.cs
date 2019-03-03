using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Globalization;
using System.Web.Mvc;

namespace OneCard.MVC.Helpers
{
    public class LanguageFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var culture = (string)HttpContext.Current.Request.RequestContext.RouteData.Values["culture"] ?? "ar";

            //CultureInfo cultureInfo = new CultureInfo(culture.ToString());
            CultureInfo cultureInfo = new CultureInfo(culture.ToLower() == "ar" ? "ar-sy" : culture);

            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);

            base.OnActionExecuting(filterContext);
        }

    }
}