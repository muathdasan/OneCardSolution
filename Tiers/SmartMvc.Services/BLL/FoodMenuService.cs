using SmartMvc.Core.Domain;
using SmartMvc.Services.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Services.BLL
{
    public class FoodMenuService : GlobalService
    {
        public int Add(FoodMenu menu)
        {
            if (menu == null)
            {
                return 0;
            }
            menu.FMenuAddDate = menu.FMenuModifyDate = CurrentDate;
            menu.FMenuIsDeleted = IsDeleted;
            menu.FMenuIsPublished = IsPublished;
            menu.FMenuPriority = menu.FMenuPriority > 0 ? menu.FMenuPriority : Priority;
            _db.FoodMenus.Add(menu);
            return _db.SaveChanges();
        }
        public int Edit(FoodMenu menu)
        {
            if (menu == null)
            {
                return 0;
            }
            FoodMenu item = _db.FoodMenus.Find(menu.FMenuId);
            item.FMenuTitle = menu.FMenuTitle;
            item.FMenuDescription = menu.FMenuDescription;
            item.FMenuPrice = menu.FMenuPrice;
            item.FMenuPriority = menu.FMenuPriority > 0 ? menu.FMenuPriority : Priority;
            item.FMenuCode = menu.FMenuCode;
            item.FMenuModifyUserId = menu.FMenuModifyUserId;
            item.FMenuModifyDate = CurrentDate;
            return _db.SaveChanges();

        }
        public List<FoodMenu> GetList()
        {
            var menus = _db.FoodMenus.Where(d => d.FMenuIsDeleted == false).OrderByDescending(d => d.FMenuId);
            return menus.ToList();
        }
        public FoodMenu GetItem(int id)
        {
            if (id == 0)
            {
                return null;
            }
            FoodMenu menu = _db.FoodMenus.FirstOrDefault(d => d.FMenuId == id && d.FMenuIsDeleted == false);
            return menu;
        }
        public int Delete(int id, Guid userId)
        {
            FoodMenu item = _db.FoodMenus.Find(id);
            item.FMenuIsDeleted = true;
            item.FMenuIsPublished = false;
            item.FMenuModifyDate = CurrentDate;
            item.FMenuModifyUserId = userId;
            return _db.SaveChanges();

        }

    }
}
