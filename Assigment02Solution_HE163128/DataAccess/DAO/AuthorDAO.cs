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
                var au = _context.Authors.FirstOrDefault(x => x.author_id == p.author_id);
                au.first_name = p.first_name;
                au.last_name = p.last_name;
                au.phone = p.phone;
                au.address = p.address;
                au.city = p.city;
                au.state = p.state;
                au.zip = p.zip;
                au.email_address = p.email_address;
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
