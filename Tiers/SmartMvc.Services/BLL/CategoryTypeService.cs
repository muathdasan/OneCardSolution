using SmartMvc.Core.Domain;
using SmartMvc.Services.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Services.BLL
{
    public class CategoryTypeService : GlobalService
    {
        public int Add(CategoryType ct)
        {
            if (ct == null)
            {
                return 0;
            }
            ct.CtAddDate = ct.CtModifyDate = CurrentDate;
            ct.CtIsDeleted = IsDeleted;
            ct.CtIsPublished = IsPublished;
            ct.CtPriority = ct.CtPriority > 0 ? ct.CtPriority : Priority;
            _db.CategoryTypes.Add(ct);
            return _db.SaveChanges();
        }
        public int Edit(CategoryType ct)
        {
            //try
            //{
                if (ct == null)
                {
                    return 0;
                }
                CategoryType item = _db.CategoryTypes.Find(ct.CtId);
                item.CtTitle = ct.CtTitle;
                item.CtPriority = ct.CtPriority > 0 ? ct.CtPriority : Priority;
                item.CtCode = ct.CtCode;
                item.CtUserId = ct.CtUserId;
                item.CtDescription = ct.CtDescription;
                item.CtModifyDate = CurrentDate;
            return _db.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    return 0;
            //}
        }
        public List<CategoryType> GetList()
        {
            var cts = _db.CategoryTypes.Where(d => d.CtIsDeleted == false).OrderByDescending(d => d.CtId);
            return cts.ToList();
        }
        public CategoryType GetItem(int id)
        {
            if (id == 0)
            {
                return null;
            }
            CategoryType ct = _db.CategoryTypes.FirstOrDefault(d => d.CtId == id && d.CtIsDeleted == false);
            return ct;
        }
        public int Delete(int id, Guid userId)
        {
            CategoryType item = _db.CategoryTypes.Find(id);
            item.CtIsDeleted = true;
            item.CtIsPublished = false;
            item.CtModifyDate = CurrentDate;
            item.CtUserId = userId;
            return _db.SaveChanges();

        }

    }
}
