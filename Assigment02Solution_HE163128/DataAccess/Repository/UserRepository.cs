using BusinessObject.Model;
using DataAccess.DAO;
using DataAccess.DTO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _dao;
        public UserRepository(UserDAO dao)
        {
            _dao = dao;
        }
        public User Login(string email, string password) => _dao.Login(email, password);

        public void Register(UserRequestDTO member) => _dao.Register(member);
    }
}
