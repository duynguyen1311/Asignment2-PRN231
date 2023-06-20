using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.RequestDTO
{
    public class UserRequestDTO
    {
        public class LoginRequestDTO
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class LoginResponseModel
        {
            public int user_id { get; set; }
           
            public string email_address { get; set; }
            
            public string password { get; set; }
            public string? source { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string last_name { get; set; }
            public int? role_id { get; set; }
            public int? pub_id { get; set; }
            public DateTime? hire_date { get; set; }
            public string role { get; set; }
            public string token { get; set; }
        }
    }
}
