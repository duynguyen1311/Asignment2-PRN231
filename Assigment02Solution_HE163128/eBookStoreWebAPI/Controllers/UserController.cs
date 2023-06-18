using BusinessObject.Model;
using DataAccess.DTO;
using DataAccess.IRepository;
using DataAccess.Repository;
using DataAccess.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ODataController
    {
        private readonly BookDbContext _context;
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("Login")]
        [EnableQuery]
        public IActionResult Post(string email, string password)
        {
            var user = _repo.Login(email, password);
            if (user == null) { return Unauthorized(); }
            return Ok(user);
        }
    }
}
