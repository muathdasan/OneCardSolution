using SmartMvc.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OneCard.MVC.Controllers
{
    public class BooksController : GlobalController
    {
        
        public ActionResult Index()
        {
            AddModelSuccess();
            return View(_service.GetBooks());
        }

        public ActionResult Details(int? id)
        {
            Book item = new Book();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item = _service.GetBook((int)id);
            ViewData["ActionType"] = "Details";
            if (item == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Books/_View.cshtml", item);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.BookUserId = UserId;
                    if (_service.AddBook(item) != 0)
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
            Book item = new Book();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetBook((int)id);
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
        public ActionResult Edit(Book item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.BookUserId = UserId;
                    if (_service.EditBook(item) != 0)
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
            Book item = new Book();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetBook((int)id);
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
            return PartialView("~/Views/Books/_View.cshtml", item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                if (_service.DeleteBook(id, UserId) != 0)
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
