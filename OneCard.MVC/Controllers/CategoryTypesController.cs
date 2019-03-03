using SmartMvc.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OneCard.MVC.Controllers
{
    public class CategoryTypesController : GlobalController
    {
        public ActionResult Index()
        {
            AddModelSuccess();
            return View(_service.GetCategoryTypes());

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( CategoryType item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.CtUserId = UserId;
                    if (_service.AddCategoryType(item) != 0)
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
            catch (Exception ex)
            {
                // Logger.Exception(ex);
                //ModelState.AddModelError("", AppSettingHelper.IsDebugMode ? ex.ToString() : General.Err_TryLater);
            }
            return View(item);
        }

        public ActionResult Edit(int? id)
        {
            CategoryType item = new CategoryType();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetCategoryType((int)id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                //ViewData["ActionType"] = "Edit";
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
        public ActionResult Edit(CategoryType item)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    item.CtUserId = UserId;
                    if (_service.EditCategoryType(item) != 0)
                    {
                        ModelSuccess = Resources.Site.MsgSuccess;
                        return RedirectToAction("Index");
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    //Logger.Exception(ex);
            //    //ModelState.AddModelError("", AppSettingHelper.IsDebugMode ? ex.ToString() : General.Err_TryLater);
            //}
            return View(item);
        }

        public ActionResult Delete(int? id)
        {
            CategoryType item = new CategoryType();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetCategoryType((int)id);
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
            return View(item);
        } 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(_service.DeleteCategoryType(id, UserId) != 0)
                  ModelSuccess = Resources.Site.MsgSuccess;
                //AddModelSuccess(Resources.Site.MsgSuccess);
            else
                AddModelError(Resources.Site.MsgGeneralError);

            return RedirectToAction("Index");
        }

    }
}