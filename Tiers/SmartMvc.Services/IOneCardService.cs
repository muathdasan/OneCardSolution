using SmartMvc.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Services
{
    public interface IOneCardService : IDisposable
    {
        #region CategoryTypeService
        int AddCategoryType(CategoryType Item);
        int EditCategoryType(CategoryType Item);
        CategoryType GetCategoryType(int id);
        List<CategoryType> GetCategoryTypes();
        int DeleteCategoryType(int id, Guid userId);
        #endregion

        #region BookService
        int AddBook(Book Item);
        int EditBook(Book Item);
        Book GetBook(int id);
        List<Book> GetBooks();
        int DeleteBook(int id, Guid userId);
        #endregion

        #region TerminalService
        int AddTerminal(Terminal Item);
        int EditTerminal(Terminal Item);
        Terminal GetTerminal(int id);
        List<Terminal> GetTerminals();
        int DeleteTerminal(int id, Guid userId);
        #endregion

        #region FoodMenuService
        int AddFoodMenu(FoodMenu Item);
        int EditFoodMenu(FoodMenu Item);
        FoodMenu GetFoodMenu(int id);
        List<FoodMenu> GetFoodMenus();
        int DeleteFoodMenu(int id, Guid userId);
        #endregion

        #region TemplateService
        int AddTemplate(Template Item);
        int EditTemplate(Template Item);
        Template GetTemplate(int id);
        List<Template> GetTemplates();
        int DeleteTemplate(int id, Guid userId);
        int SetTemplateDefualt(int id, Guid userId);
        #endregion

        #region OwnerService
        int AddOwner(Owner Item);
        int EditOwner(Owner Item);
        Owner GetOwner(int id);
        List<Owner> GetOwners();
        int DeleteOwner(int id, Guid userId);
        #endregion
    }
}
