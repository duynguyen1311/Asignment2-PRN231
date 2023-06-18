using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class PublisherDAO
    {
        private readonly BookDbContext _context;

        public PublisherDAO(BookDbContext context)
        {
            _context = context;
        }
        public List<Publisher>? GetPublishers()
        {
            var list = _context.Publishers.ToList();
            return list;
        }

        public Publisher FindPublisherById(int prodId)
        {
            var p = _context.Publishers.AsNoTracking().SingleOrDefault(x => x.pub_id == prodId);
            return p;
        }

        public void SavePublisher(Publisher p)
        {
            try
            {
                _context.Publishers.Add(p);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdatePublisher(Publisher p)
        {
            try
            {
                _context.Entry<Publisher>(p).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeletePublisher(int id)
        {
            try
            {
                var p1 = _context.Publishers.SingleOrDefault(c => c.pub_id == id);
                _context.Publishers.Remove(p1);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
