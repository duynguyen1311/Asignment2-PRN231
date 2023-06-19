using AutoMapper;
using DataAccess.IRepository;
using eBookStoreWebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : ODataController
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BookAuthorController(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var list = _repo.GetBooks();
            var map = _mapper.Map<List<BookAuthorDTO>>(list);
            return Ok(map);
        }
    }
}
