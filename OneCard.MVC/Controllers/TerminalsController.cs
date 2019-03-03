using SmartMvc.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OneCard.MVC.Controllers
{
    public class TerminalsController : GlobalController
    {
        public ActionResult Index()
        {
            AddModelSuccess();
            return View(_service.GetTerminals());
        }
        public ActionResult Details(int? id)
        {
            Terminal item = new Terminal();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item = _service.GetTerminal((int)id);
            ViewData["ActionType"] = "Details";
            if (item == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Terminals/_View.cshtml", item);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Terminal item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.TermUserId = UserId;
                    item.TermModifyUserId = UserId;
                    if (_service.AddTerminal(item) != 0)
                    {
                        ModelSuccess = Resources.Site.MsgSuccess;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddModelError(Resources.Site.MsgGeneralError);
                    }
                }
            }
            catch
            {
            }
            return View(item);
        }

        public ActionResult Edit(int? id)
        {
            Terminal item = new Terminal();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetTerminal((int)id);
                if (item == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception ex)
            {
                //Logger.Exception(ex);
                //ModelState.AddModelError("", AppSettingHelper.IsDebugMode ? ex.ToString() : General.Err_TryLater);
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Terminal item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.TermModifyUserId = UserId;
                    if (_service.EditTerminal(item) != 0)
                    {
                        ModelSuccess = Resources.Site.MsgSuccess;
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {

            }
            return View(item);
        }

        public ActionResult Delete(int? id)
        {
            Terminal item = new Terminal();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetTerminal((int)id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                ViewData["ActionType"] = "Delete";
            }
            catch (Exception ex)
            {
                //Logger.Exception(ex);
                //ModelState.AddModelError("", AppSettingHelper.IsDebugMode? ex.ToString() : General.Err_TryLater);
            }
            return PartialView("~/Views/Terminals/_View.cshtml", item);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                if (_service.DeleteTerminal(id, UserId) != 0)
                    ModelSuccess = Resources.Site.MsgSuccess;
                else
                    AddModelError(Resources.Site.MsgGeneralError);
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }
    }
}