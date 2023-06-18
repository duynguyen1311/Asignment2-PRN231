using BusinessObject.Model;
using DataAccess.DTO;
using DataAccess.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        private readonly BookDbContext _context;
        private readonly IConfiguration _configuration;

        public UserDAO(BookDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public string Login(string email, string password)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.email_address == email && x.password == password);
                if (user == null) { return null; }
                var token = new TokenService(_configuration).GenerateToken(user);
                return token;
            }
            
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Register(UserRequestDTO User)
        {
            try
            {
                using (var context = new BookDbContext())
                {
                    var mem = new User()
                    {
                        email_address = User.Email,
                        password = User.Password,
                        source = User.Source,
                        first_name = User.FirstName,
                        middle_name = User.MiddleName,
                        last_name = User.LastName,
                        role_id = 1,
                        pub_id = User.PubId,
                        hire_date = DateTime.Now
                    };
                    context.Users.Add(mem);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /*public static List<User>? GetUsers(string? keyword)
        {
            List<User>? listUsers = null;
            try
            {
                using (var context = new BookDbContext())
                {
                    if (keyword == null)
                    {
                        listUsers = context.Users.AsNoTracking().ToList();
                    }
                    else
                    {
                        listUsers = context.Users.Where(i => !string.IsNullOrEmpty(i.CompanyName) && i.CompanyName.ToLower().Contains(keyword.ToLower())
                                                              || !string.IsNullOrEmpty(i.Email) && i.Email.ToLower().Contains(keyword.ToLower())).AsNoTracking().ToList();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listUsers;
        }

        public static User FindUserById(int prodId)
        {
            User p = new User();
            try
            {
                using (var context = new BookDbContext())
                {
                    p = context.Users.SingleOrDefault(x => x.UserId == prodId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static void SaveUser(UserRequestDto p)
        {
            try
            {
                using (var context = new BookDbContext())
                {
                    var mem = new User()
                    {
                        Email = p.Email,
                        CompanyName = p.CompanyName,
                        City = p.City,
                        Country = p.Country,
                        Password = p.Password
                    };
                    context.Users.Add(mem);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateUser(UserUpdateRequest p)
        {
            try
            {
                using (var context = new BookDbContext())
                {
                    var mem = new User()
                    {
                        UserId = p.UserId,
                        Email = p.Email,
                        CompanyName = p.CompanyName,
                        City = p.City,
                        Country = p.Country,
                        Password = p.Password,
                    };
                    context.Entry<User>(mem).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteUser(User p)
        {
            try
            {
                using (var context = new BookDbContext())
                {
                    var p1 = context.Users.SingleOrDefault(
                        c => c.UserId == p.UserId);
                    context.Users.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/
    }
}
