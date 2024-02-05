using BusinessObject.Model;
using eBookStore.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using static BusinessObject.RequestDTO.UserRequestDTO;

namespace eBookStore.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly HttpContext _httpContext;
        private readonly HttpClient client = null;
        private string ApiUrl = "";
        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContext.Request.Cookies["AccessToken"]);
            ApiUrl = "https://localhost:44322/api/User/Login";
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model)
        {


            if (User.Identity?.IsAuthenticated == true) return RedirectToPage("/Home/Index");

            var json = JsonSerializer.Serialize(model);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var requestModel = new LoginRequestDTO { Email = model.Email, Password = model.Password };
            var response = await client.PostAsync(ApiUrl, body);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                var res = JsonSerializer.Deserialize<LoginResponseModel>(content);

                HttpContext.Response.Cookies.Append("AccessToken", res.token, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1).AddMinutes(-1)
                });
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, res.user_id.ToString()),
                    new Claim(ClaimTypes.Name, res.first_name + " " + res.last_name),
                    new Claim(ClaimTypes.Email, res.email_address),
                    new Claim(ClaimTypes.Role, res.role)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal, new AuthenticationProperties
                {
                    IsPersistent = false
                });
                /*if(res.role == "admin") HttpContext.Session.SetString("IsAdmin", "true");
                if(res.role == "user") HttpContext.Session.SetString("IsUser", "true");
                HttpContext.Session.SetString("IsLoggedIn", "true");*/
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Title"] = "Incorrect email or password";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuthentication");
            return RedirectToAction("Login", "Account");
        }
    }
}
//Helloooo
