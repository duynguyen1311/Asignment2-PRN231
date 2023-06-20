using AutoMapper;
using BusinessObject.Model;
using DataAccess.DTO;
using DataAccess.IRepository;
using DataAccess.Repository;
using DataAccess.Service;
using eBookStoreWebAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static BusinessObject.RequestDTO.UserRequestDTO;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BookDbContext _context;
        private readonly IUserRepository _repo;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
        {
            _repo = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponseModel>> UserLogin(LoginRequestDTO model)
        {
            var user = _repo.Login(model.Email, model.Password);
            if (user == null) return NotFound();
            var role = user.role_id == 1 ? "user" : "admin";

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JwtIssuer"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.NameIdentifier, user.user_id.ToString()),
                        new Claim(ClaimTypes.Name, $"{user.first_name} {user.middle_name} {user.last_name}"),
                        new Claim(ClaimTypes.Email, user.email_address),
                        new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var response = _mapper.Map<LoginResponseModel>(user);
            response.role = role;
            response.token = tokenHandler.WriteToken(token);
            return Ok(response);
        }

        [HttpPost("Register")]
        public IActionResult RegisterAccount([FromBody] UserRequestDTO request)
        {
             _repo.Register(request);
            return Ok();
        }
    }
}
