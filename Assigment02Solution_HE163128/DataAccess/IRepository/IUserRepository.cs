using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IUserRepository
    {
        string Login(string email, string password);
        void Register(UserRequestDTO member);
    }
}
