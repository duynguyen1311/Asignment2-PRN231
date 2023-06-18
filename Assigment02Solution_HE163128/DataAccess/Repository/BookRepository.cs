using BusinessObject.Model;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDAO _dao;

        public BookRepository(BookDAO dao) { _dao = dao; }
        public void DeleteBook(int id) => _dao.DeleteBook(id);
        public void SaveBook(Book p) => _dao.SaveBook(p);
        public void UpdateBook(Book p) => _dao.UpdateBook(p);
        public List<Book>? GetBooks() => _dao.GetBooks();
        public Book GetBookById(int id) => _dao.FindBookById(id);
    }
}
