using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IPublisherRepository
    {
        void SavePublisher(Publisher p);
        Publisher GetPublisherById(int id);
        void DeletePublisher(int id);
        void UpdatePublisher(Publisher p);
        List<Publisher>? GetPublishers();
    }
}
