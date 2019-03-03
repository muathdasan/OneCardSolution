using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Threading;
using System.Globalization;

namespace OneCard.MVC.Helpers
{
    public class CultureHelper
    {
        protected HttpSessionState session;

        //constructor 
        public CultureHelper(HttpSessionState httpSessionState)
        {
            session = httpSessionState;
        }
        // Properties
        public static bool IsRtl => Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft;
        public static int CurrentCulture
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "ar")
                {
                    return 0;
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "en")
                {
                    return 1;
                }
                else
                {
                    return 1;
                }
            }
            set
            {

                if (value == 0)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
                }
                else if (value == 1)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                }

                else
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
                }

                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            }
        }
    }
    public class ControllersList
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}