using SmartMvc.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OneCard.MVC.Controllers
{
    public class TemplatesController : GlobalController
    {
        public ActionResult Index()
        {
            AddModelSuccess();
            return View(_service.GetTemplates());
        }

        public ActionResult Details(int? id)
        {
            Template item = new Template();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item = _service.GetTemplate((int)id);
            ViewData["ActionType"] = "Details";
            if (item == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Templates/_View.cshtml", item);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryTypeId = new SelectList(_service.GetCategoryTypes(), "CtId", "CtTitle"); 

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Template item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.TempUserId = UserId;
                    item.TempModifyUserId = UserId;
                    if (_service.AddTemplate(item) != 0)
                    {
                        ModelSuccess = Resources.Site.MsgSuccess;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddModelError(Resources.Site.MsgGeneralError);
                    }
                }
                ViewBag.CategoryTypeId = new SelectList(_service.GetCategoryTypes(), "CtId", "CtTitle"); 
            }
            catch
            {
            }
            return View(item);
        }

        public ActionResult Edit(int? id)
        {
            Template item = new Template();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetTemplate((int)id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CategoryTypeId = new SelectList(_service.GetCategoryTypes(), "CtId", "CtTitle", item.CategoryTypeId); 
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
        public ActionResult Edit(Template item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.TempModifyUserId = UserId;
                    if (_service.EditTemplate(item) != 0)
                    {
                        ModelSuccess = Resources.Site.MsgSuccess;
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.CategoryTypeId = new SelectList(_service.GetCategoryTypes(), "CtId", "CtTitle", item.CategoryTypeId); 

            }
            catch
            {

            }
            return View(item);
        }

        public ActionResult Delete(int? id)
        {
            Template item = new Template();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetTemplate((int)id);
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
            return PartialView("~/Views/Templates/_View.cshtml", item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                if (_service.DeleteTemplate(id, UserId) != 0)
                    ModelSuccess = Resources.Site.MsgSuccess;
                else
                    AddModelError(Resources.Site.MsgGeneralError);
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }
        public ActionResult SetTemplateDefualt(int? id)
        {
            Template item = new Template();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetTemplate((int)id);
                if (item == null)
                {
                    return HttpNotFound();
                }
               // ViewData["ActionType"] = "Delete";
            }
            catch (Exception ex)
            {
                //Logger.Exception(ex);
                //ModelState.AddModelError("", AppSettingHelper.IsDebugMode? ex.ToString() : General.Err_TryLater);
            }
            return PartialView("~/Views/Templates/_ConfirmDefualt.cshtml", item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetTemplateDefualt(int id)
        {
            try
            {
                if (_service.SetTemplateDefualt(id, UserId) != 0)
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