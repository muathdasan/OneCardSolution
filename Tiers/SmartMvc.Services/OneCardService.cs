using SmartMvc.Core.Domain;
using SmartMvc.Services.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Services
{
    public class OneCardService : IOneCardService
    {
        public void Dispose()
        {
        }

        #region CategoryTypeService
        public int AddCategoryType(CategoryType Item)
        {
            CategoryTypeService bll = new CategoryTypeService();
            return bll.Add(Item);
        }
        public int EditCategoryType(CategoryType Item)
        {
            CategoryTypeService bll = new CategoryTypeService();
            return bll.Edit(Item);
        }
        public CategoryType GetCategoryType(int id)
        {
            CategoryTypeService bll = new CategoryTypeService();
            return bll.GetItem(id);
        }
        public List<CategoryType> GetCategoryTypes()
        {
            CategoryTypeService bll = new CategoryTypeService();
            return bll.GetList();
        }
        public int DeleteCategoryType(int id, Guid userId)
        {
            CategoryTypeService bll = new CategoryTypeService();
            return bll.Delete(id, userId);
        }
        #endregion

        #region BookService
        public int AddBook(Book Item)
        {
            BookService bll = new BookService();
            return bll.Add(Item);
        }
        public int EditBook(Book Item)
        {
            BookService bll = new BookService();
            return bll.Edit(Item);
        }
        public Book GetBook(int id)
        {
            BookService bll = new BookService();
            return bll.GetItem(id);
        }
        public List<Book> GetBooks()
        {
            BookService bll = new BookService();
            return bll.GetList();
        }
        public int DeleteBook(int id, Guid userId)
        {
            BookService bll = new BookService();
            return bll.Delete(id, userId);
        }
        #endregion

        #region TerminalService
        public int AddTerminal(Terminal Item)
        {
            TerminalService bll = new TerminalService();
            return bll.Add(Item);
        }
        public int EditTerminal(Terminal Item)
        {
            TerminalService bll = new TerminalService();
            return bll.Edit(Item);
        }
        public Terminal GetTerminal(int id)
        {
            TerminalService bll = new TerminalService();
            return bll.GetItem(id);
        }
        public List<Terminal> GetTerminals()
        {
            TerminalService bll = new TerminalService();
            return bll.GetList();
        }
        public int DeleteTerminal(int id, Guid userId)
        {
            TerminalService bll = new TerminalService();
            return bll.Delete(id, userId);
        }
        #endregion

        #region FoodMenuService
        public int AddFoodMenu(FoodMenu Item)
        {
            FoodMenuService bll = new FoodMenuService();
            return bll.Add(Item);
        }
        public int EditFoodMenu(FoodMenu Item)
        {
            FoodMenuService bll = new FoodMenuService();
            return bll.Edit(Item);
        }
        public FoodMenu GetFoodMenu(int id)
        {
            FoodMenuService bll = new FoodMenuService();
            return bll.GetItem(id);
        }
        public List<FoodMenu> GetFoodMenus()
        {
            FoodMenuService bll = new FoodMenuService();
            return bll.GetList();
        }
        public int DeleteFoodMenu(int id, Guid userId)
        {
            FoodMenuService bll = new FoodMenuService();
            return bll.Delete(id, userId);
        }
        #endregion

        #region TemplateService
        public int AddTemplate(Template Item)
        {
            TemplateService bll = new TemplateService();
            return bll.Add(Item);
        }
        public int EditTemplate(Template Item)
        {
            TemplateService bll = new TemplateService();
            return bll.Edit(Item);
        }
        public Template GetTemplate(int id)
        {
            TemplateService bll = new TemplateService();
            return bll.GetItem(id);
        }
        public List<Template> GetTemplates()
        {
            TemplateService bll = new TemplateService();
            return bll.GetList();
        }
        public int DeleteTemplate(int id, Guid userId)
        {
            TemplateService bll = new TemplateService();
            return bll.Delete(id, userId);
        }
        public int SetTemplateDefualt(int id, Guid userId)
        {
            TemplateService bll = new TemplateService();
            return bll.SetDefualt(id, userId);
        }
        #endregion

        #region OwnerService
        public int AddOwner(Owner Item)
        {
            OwnerService bll = new OwnerService();
            return bll.Add(Item);
        }
        public int EditOwner(Owner Item)
        {
            OwnerService bll = new OwnerService();
            return bll.Edit(Item);
        }
        public Owner GetOwner(int id)
        {
            OwnerService bll = new OwnerService();
            return bll.GetItem(id);
        }
        public List<Owner> GetOwners()
        {
            OwnerService bll = new OwnerService();
            return bll.GetList();
        }
        public int DeleteOwner(int id, Guid userId)
        {
            OwnerService bll = new OwnerService();
            return bll.Delete(id, userId);
        }
        
        #endregion
    }
}
