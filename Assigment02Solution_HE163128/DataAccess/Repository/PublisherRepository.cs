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
    public class PublisherRepository : IPublisherRepository
    {
        private readonly PublisherDAO _dao;

        public PublisherRepository(PublisherDAO dao) { _dao = dao; }
        public void DeletePublisher(int id) => _dao.DeletePublisher(id);
        public void SavePublisher(Publisher p) => _dao.SavePublisher(p);
        public void UpdatePublisher(Publisher p) => _dao.UpdatePublisher(p);
        public List<Publisher>? GetPublishers() => _dao.GetPublishers();
        public Publisher GetPublisherById(int id) => _dao.FindPublisherById(id);
    }
}
