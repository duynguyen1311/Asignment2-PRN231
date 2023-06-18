using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IBookRepository
    {
        void SaveBook(Book p);
        Book GetBookById(int id);
        void DeleteBook(int id);
        void UpdateBook(Book p);
        List<Book>? GetBooks();
    }
}
