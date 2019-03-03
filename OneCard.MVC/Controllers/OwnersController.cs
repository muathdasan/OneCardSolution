using SmartMvc.Core.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OneCard.MVC.Controllers
{
    public class OwnersController : GlobalController
    { 
        public ActionResult Index()
        {
            AddModelSuccess();
            return View(_service.GetOwners());
        }

        public ActionResult Details(int? id)
        {
            Owner item = new Owner();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item = _service.GetOwner((int)id);
            ViewData["ActionType"] = "Details";
            if (item == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Owners/_View.cshtml", item);
        }
        public ActionResult Create()
        {
            ViewBag.CategoryTypeId = new SelectList(_service.GetCategoryTypes(), "CtId", "CtTitle");
            ViewBag.OwnerTemplateId = new SelectList(_service.GetTemplates(), "TempId", "TempTitle");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner item, HttpPostedFileBase OwnerImagePath, HttpPostedFileBase OwnerAttachFile1, HttpPostedFileBase OwnerAttachFile2, HttpPostedFileBase OwnerAttachFile3, string imageData)
        {
            try
            {
                if (OwnerImagePath != null || imageData != null )
                {
                    long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    if (imageData != null && imageData !="")
                    {
                        string ImageName4 = milliseconds.ToString() + "__Captured";
                        var t = imageData.Substring(22);  // remove data:image/png;base64,  
                        byte[] bytes = Convert.FromBase64String(t);
                        Image image;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                        }
                        var randomFileName = ImageName4 + ".png";
                        var fullPath = Path.Combine(Server.MapPath("~/Images/"), randomFileName);
                        image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
                        item.OwnerImagePath = randomFileName;
                    }
                    else if (OwnerImagePath != null)
                    {
                        if (Path.GetExtension(OwnerImagePath.FileName).ToLower() == ".jpg" ||
                       Path.GetExtension(OwnerImagePath.FileName).ToLower() == ".png" ||
                       Path.GetExtension(OwnerImagePath.FileName).ToLower() == ".gif" ||
                       Path.GetExtension(OwnerImagePath.FileName).ToLower() == ".jpeg")
                        {
                            string ImageName = milliseconds.ToString() + "__" + System.IO.Path.GetFileName(OwnerImagePath.FileName);
                            string PhysicalPath = Server.MapPath("~/Images/" + ImageName);
                            OwnerImagePath.SaveAs(PhysicalPath);
                            item.OwnerImagePath = ImageName;
                        }
                        else
                        {
                            AddModelError(Resources.Site.MsgAddOwnerExtension);
                            ViewBag.CategoryTypeId = new SelectList(_service.GetCategoryTypes(), "CtId", "CtTitle");
                            ViewBag.OwnerTemplateId = new SelectList(_service.GetTemplates(), "TempId", "TempTitle");
                            return View(item);
                        }
                    }
                    item.OwnerUserId = UserId;
                    item.OwnerModifyUserId = UserId;
                    if (OwnerAttachFile1 != null)
                    {
                        string ImageName1 = milliseconds.ToString() + "__" + System.IO.Path.GetFileName(OwnerAttachFile1.FileName);
                        string PhysicalPath1 = Server.MapPath("~/Files/" + ImageName1);
                        OwnerAttachFile1.SaveAs(PhysicalPath1);
                        item.OwnerAttachFile1 = ImageName1;
                    }
                    if (OwnerAttachFile2 != null)
                    {
                        string ImageName2 = milliseconds.ToString() + "__" + System.IO.Path.GetFileName(OwnerAttachFile2.FileName);
                        string PhysicalPath2 = Server.MapPath("~/Files/" + ImageName2);
                        OwnerAttachFile2.SaveAs(PhysicalPath2);
                        item.OwnerAttachFile2 = ImageName2;
                    }
                    if (OwnerAttachFile3 != null)
                    {
                        string ImageName3 = milliseconds.ToString() + "__" + System.IO.Path.GetFileName(OwnerAttachFile3.FileName);
                        string PhysicalPath3 = Server.MapPath("~/Files/" + ImageName3);
                        OwnerAttachFile3.SaveAs(PhysicalPath3);
                        item.OwnerAttachFile3 = ImageName3;
                    }
                    if (ModelState.IsValid)
                    {
                        AddModelSuccess();
                        if (_service.AddOwner(item) != 0)
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
                else
                {
                    AddModelError(Resources.Site.MsgAddOwnerImage);
                }

            }
            catch (Exception ex)
            {
                AddModelError(Resources.Site.MsgGeneralError);
            }
            ViewBag.CategoryTypeId = new SelectList(_service.GetCategoryTypes(), "CtId", "CtTitle");
            ViewBag.OwnerTemplateId = new SelectList(_service.GetTemplates(), "TempId", "TempTitle");
            return View(item);
        }

        public ActionResult Edit(int? id)
        {
            Owner item = new Owner();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetOwner((int)id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CategoryTypeId = new SelectList(_service.GetCategoryTypes(), "CtId", "CtTitle", item.CategoryTypeId);
                ViewBag.OwnerTemplateId = new SelectList(_service.GetTemplates(), "TempId", "TempTitle", item.OwnerTemplateId);
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
        public ActionResult Edit(Owner item, HttpPostedFileBase OwnerImagePath, HttpPostedFileBase OwnerAttachFile1, HttpPostedFileBase OwnerAttachFile2, HttpPostedFileBase OwnerAttachFile3, string imageData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    if (OwnerImagePath != null || imageData != null)
                    {
                        if (imageData != null && imageData != "")
                        {
                            string ImageName4 = milliseconds.ToString() + "__Captured";
                            var t = imageData.Substring(22);  // remove data:image/png;base64,  
                            byte[] bytes = Convert.FromBase64String(t);
                            Image image;
                            using (MemoryStream ms = new MemoryStream(bytes))
                            {
                                image = Image.FromStream(ms);
                            }
                            var randomFileName = ImageName4 + ".png";
                            var fullPath = Path.Combine(Server.MapPath("~/Images/"), randomFileName);
                            image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
                            item.OwnerImagePath = randomFileName;
                        }
                        else if (OwnerImagePath != null)
                        {
                            if (Path.GetExtension(OwnerImagePath.FileName).ToLower() == ".jpg" ||
                               Path.GetExtension(OwnerImagePath.FileName).ToLower() == ".png" ||
                               Path.GetExtension(OwnerImagePath.FileName).ToLower() == ".gif" ||
                               Path.GetExtension(OwnerImagePath.FileName).ToLower() == ".jpeg")
                            {

                                string ImageName = milliseconds.ToString() + "__" + System.IO.Path.GetFileName(OwnerImagePath.FileName);
                                string PhysicalPath = Server.MapPath("~/Images/" + ImageName);
                                OwnerImagePath.SaveAs(PhysicalPath);
                                item.OwnerImagePath = ImageName;
                            }
                            else
                            {
                                AddModelError(Resources.Site.MsgAddOwnerExtension);
                                ViewBag.CategoryTypeId = new SelectList(_service.GetCategoryTypes(), "CtId", "CtTitle", item.CategoryTypeId);
                                ViewBag.OwnerTemplateId = new SelectList(_service.GetTemplates(), "TempId", "TempTitle", item.OwnerTemplateId);
                                return View(item);
                            }
                        }
                    }
                    if (OwnerAttachFile1 != null)
                    {
                        string ImageName1 = milliseconds.ToString() + "__" + System.IO.Path.GetFileName(OwnerAttachFile1.FileName);
                        string PhysicalPath1 = Server.MapPath("~/Files/" + ImageName1);
                        OwnerAttachFile1.SaveAs(PhysicalPath1);
                        item.OwnerAttachFile1 = ImageName1;
                    }
                    if (OwnerAttachFile2 != null)
                    {
                        string ImageName2 = milliseconds.ToString() + "__" + System.IO.Path.GetFileName(OwnerAttachFile2.FileName);
                        string PhysicalPath2 = Server.MapPath("~/Files/" + ImageName2);
                        OwnerAttachFile2.SaveAs(PhysicalPath2);
                        item.OwnerAttachFile2 = ImageName2;
                    }
                    if (OwnerAttachFile3 != null)
                    {
                        string ImageName3 = milliseconds.ToString() + "__" + System.IO.Path.GetFileName(OwnerAttachFile3.FileName);
                        string PhysicalPath3 = Server.MapPath("~/Files/" + ImageName3);
                        OwnerAttachFile3.SaveAs(PhysicalPath3);
                        item.OwnerAttachFile3 = ImageName3;
                    }
                    item.OwnerModifyUserId = UserId;
                    if (_service.EditOwner(item) != 0)
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
                AddModelError(Resources.Site.MsgGeneralError);
            }
            ViewBag.CategoryTypeId = new SelectList(_service.GetCategoryTypes(), "CtId", "CtTitle", item.CategoryTypeId);
            ViewBag.OwnerTemplateId = new SelectList(_service.GetTemplates(), "TempId", "TempTitle", item.OwnerTemplateId);
            return View(item);
        }

        public ActionResult Delete(int? id)
        {
            Owner item = new Owner();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                item = _service.GetOwner((int)id);
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
            return PartialView("~/Views/Owners/_View.cshtml", item);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                if (_service.DeleteOwner(id, UserId) != 0)
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