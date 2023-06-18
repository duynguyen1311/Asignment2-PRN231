using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AuthorDAO
    {
        private readonly BookDbContext _context;

        public AuthorDAO(BookDbContext context)
        {
            _context = context;
        }
        public List<Author>? GetAuthors()
        {
            var list = _context.Authors.ToList();
            return list;
        }

        public Author FindAuthorById(int prodId)
        {
            var p = _context.Authors.AsNoTracking().SingleOrDefault(x => x.author_id == prodId);
            return p;
        }

        public void SaveAuthor(Author p)
        {
            try
            {
                _context.Authors.Add(p);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateAuthor(Author p)
        {
            try
            {
                _context.Entry<Author>(p).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteAuthor(int id)
        {
            try
            {
                var p1 = _context.Authors.SingleOrDefault(c => c.author_id == id);
                _context.Authors.Remove(p1);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
