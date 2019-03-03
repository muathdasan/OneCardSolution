using SmartMvc.Core.Domain;
using SmartMvc.Services.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Services.BLL
{
    public class BookService : GlobalService
    {
        public int Add(Book book)
        {
            if (book == null)
            {
                return 0;
            }
            book.BookAddDate = book.BookModifyDate = CurrentDate;
            book.BookIsDeleted = IsDeleted;
            book.BookPriority = book.BookPriority > 0 ? book.BookPriority : Priority;
            _db.Books.Add(book);
            return _db.SaveChanges();
        }
        public int Edit(Book book)
        {
            if (book == null)
            {
                return 0;
            }
            Book item = _db.Books.Find(book.BookId);
            item.BookTitle = book.BookTitle;
            item.BookPriority = book.BookPriority > 0 ? book.BookPriority : Priority;
            item.BookCode = book.BookCode;
            item.BookPrice = book.BookPrice;
            item.BookStatus = book.BookStatus;
            item.BookAuthor = book.BookAuthor;
            item.BookYear = book.BookYear;
            item.BookQuantity = book.BookQuantity;
            item.BookUserId = book.BookUserId;
            item.BookModifyDate = CurrentDate;
            return _db.SaveChanges();
        }
        public List<Book> GetList()
        {
            var books = _db.Books.Where(d => d.BookIsDeleted == false).OrderByDescending(d => d.BookId);
            return books.ToList();
        }
        public Book GetItem(int id)
        {
            if (id == 0)
            {
                return null;
            }
            Book book = _db.Books.FirstOrDefault(d => d.BookId == id && d.BookIsDeleted == false);
            return book;
        }
        public int Delete(int id, Guid userId)
        {
            Book item = _db.Books.Find(id);
            item.BookIsDeleted = true;
            item.BookModifyDate = CurrentDate;
            item.BookUserId = userId;
            return _db.SaveChanges();

        }
    }
}
