using System.ComponentModel.DataAnnotations;

namespace eBookStore.Models.Account
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
    }
}
