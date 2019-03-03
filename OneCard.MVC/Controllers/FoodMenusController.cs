using SmartMvc.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OneCard.MVC.Controllers
{
    public class FoodMenusController : GlobalController
    {
        public ActionResult Index()
        {
            AddModelSuccess();
            return View(_service.GetFoodMenus());
        }

        public ActionResult Details(int? id)
        {
            FoodMenu item = new FoodMenu();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item = _service.GetFoodMenu((int)id);
            ViewData["ActionType"] = "Details";
            if (item == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/FoodMenus/_View.cshtml", item);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodMenu item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.FMenuUserId = UserId;
                    item.FMenuModifyUserId = UserId;
                    if (_service.AddFoodMenu(item) != 0)
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
            FoodMenu item = new FoodMenu();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetFoodMenu((int)id);
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
        public ActionResult Edit(FoodMenu item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.FMenuModifyUserId = UserId;
                    if (_service.EditFoodMenu(item) != 0)
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
            FoodMenu item = new FoodMenu();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetFoodMenu((int)id);
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
            return PartialView("~/Views/FoodMenus/_View.cshtml", item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                if (_service.DeleteFoodMenu(id, UserId) != 0)
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
