using AutoMapper;
using BusinessObject.Model;
using DataAccess.IRepository;
using eBookStoreWebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ODataController
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BookController(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var list = _repo.GetBooks();
            return Ok(list);
        }

        [HttpGet("{key}")]
        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            var Book = _repo.GetBookById(key);
            if (Book == null)
            {
                return NotFound();
            }

            return Ok(Book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book p)
        {
            _repo.SaveBook(p);

            return Created(nameof(BookController), p);
        }

        [HttpPut]
        public IActionResult Put([FromODataUri] int key, Book p)
        {
            if (key != p.pub_id)
            {
                return BadRequest();
            }

            _repo.UpdateBook(p);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromODataUri] int key)
        {
            _repo.DeleteBook(key);
            return NoContent();
        }
    }
}
