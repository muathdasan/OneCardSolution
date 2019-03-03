using SmartMvc.Core.Domain;
using SmartMvc.Services.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Services.BLL
{
    public class TemplateService : GlobalService
    {
        public int Add(Template temp)
        {
            if (temp == null)
            {
                return 0;
            }
            //TempIsDefualt
            temp.TempAddDate = temp.TempModifyDate = CurrentDate;
            temp.TempIsDeleted = IsDeleted;
            temp.TempIsPublished = IsPublished;
            temp.TempPriority = temp.TempPriority > 0 ? temp.TempPriority : Priority;
            _db.Templates.Add(temp);
            return _db.SaveChanges();
        }
        public int Edit(Template temp)
        {
            if (temp == null)
            {
                return 0;
            }
            Template item = _db.Templates.Find(temp.TempId);
            //TempIsDefualt
            item.TempTitle = temp.TempTitle;
            item.TempDescription = temp.TempDescription;
            item.TempPath = temp.TempPath;
            item.CategoryTypeId = temp.CategoryTypeId;
            item.TempPriority = temp.TempPriority > 0 ? temp.TempPriority : Priority;
            item.TempCode = temp.TempCode;
            item.TempModifyUserId = temp.TempModifyUserId;
            item.TempModifyDate = CurrentDate;
            return _db.SaveChanges();

        }
        public List<Template> GetList()
        {
            var temps = _db.Templates.Include(d => d.CategoryType).Where(d => d.TempIsDeleted == false).OrderByDescending(d => d.TempId);
            return temps.ToList();
        }
        public Template GetItem(int id)
        {
            if (id == 0)
            {
                return null;
            }
            Template temp = _db.Templates.FirstOrDefault(d => d.TempId == id && d.TempIsDeleted == false);
            return temp;
        }
        public int Delete(int id, Guid userId)
        {
            Template item = _db.Templates.Find(id);
            item.TempIsDeleted = true;
            item.TempIsPublished = false;
            item.TempModifyDate = CurrentDate;
            item.TempModifyUserId = userId;
            return _db.SaveChanges();

        }
        public int SetDefualt(int id, Guid userId)
        {
            var temps = _db.Templates.Where(d => d.TempIsDeleted == false);
            foreach (var  item in temps)
            {
                item.TempIsDefualt = false;
            }
            Template itemDefualt = _db.Templates.Find(id);
            itemDefualt.TempIsDefualt = true;
            return _db.SaveChanges();
        }
    }
}
