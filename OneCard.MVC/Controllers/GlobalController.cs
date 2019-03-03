using OneCard.MVC.Helpers;
using SmartMvc.Services;
using SmartMvc.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneCard.MVC.Utilities;
using System.Threading;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;
using System.Reflection;

namespace OneCard.MVC.Controllers
{
    [LanguageFilter]
    public class GlobalController : Controller
    {
        public IOneCardService _service = new OneCardService();
        public Guid UserId { get { return ManageUsers.GetId(); } }

        #region msg
        public string ActionType { get { return ViewData["ActionType"] as string; } set { ViewData["ActionType"] = value; } }
        public string ModelInfo { get { return ViewData[MsgHelper.ModelInfo] as string; } set { ViewData[MsgHelper.ModelInfo] = value; } }
        public object ModelSuccess { get { return TempData[MsgHelper.ModelSuccess]; } set { TempData[MsgHelper.ModelSuccess] = value; } }

        public void AddModelError(string msg = null)
        {
            ModelState.AddModelError(MsgHelper.ModelError, msg == null ? Resources.Site.MsgGeneralError : msg);
        }

        public void AddModelSuccess(string msg = null)
        {
            if (msg == null)
            {
                ViewData[MsgHelper.ModelSuccess] = ModelSuccess;
                ModelSuccess = null;
            }
            else ViewData[MsgHelper.ModelSuccess] = msg;
        }
        #endregion
       
      
        //public ActionResult RedirectResult(string action = "Index")
        //{
        //    if (CallBackUrl != null)
        //    {
        //        return Redirect(CallBackUrl);
        //    }
        //    return RedirectToAction(action);
        //}
    }

}