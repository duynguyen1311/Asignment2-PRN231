using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookDAO
    {
        private readonly BookDbContext _context;

        public BookDAO(BookDbContext context)
        {
            _context = context;
        }
        public List<Book>? GetBooks()
        {
            var list = _context.Books.ToList();
            return list;
        }

        public Book FindBookById(int prodId)
        {
            var p = _context.Books.AsNoTracking().SingleOrDefault(x => x.book_id == prodId);
            return p;
        }

        public void SaveBook(Book p)
        {
            try
            {
                _context.Books.Add(p);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateBook(Book p)
        {
            try
            {
                _context.Entry<Book>(p).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteBook(int id)
        {
            try
            {
                var p1 = _context.Books.SingleOrDefault(c => c.book_id == id);
                _context.Books.Remove(p1);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
