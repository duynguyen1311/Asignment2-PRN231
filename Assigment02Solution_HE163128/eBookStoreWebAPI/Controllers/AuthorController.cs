using BusinessObject.Model;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorController : ODataController
    {
        private readonly IAuthorRepository _repo;

        public AuthorController(IAuthorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [EnableQuery]

        public IActionResult Get()
        {
            var list = _repo.GetAuthors();
            return Ok(list);
        }

        [HttpGet("{key}")]
        [EnableQuery]

        public IActionResult Get([FromODataUri] int key)
        {
            var Author = _repo.GetAuthorById(key);
            if (Author == null)
            {
                return NotFound();
            }

            return Ok(Author);
        }
        [HttpPost]

        public IActionResult Post([FromBody] Author p)
        {
            _repo.SaveAuthor(p);

            return Created(nameof(AuthorController), p);
        }

        [HttpPut]

        public IActionResult Put([FromODataUri] int key, Author p)
        {
            if (key != p.author_id)
            {
                return BadRequest();
            }

            _repo.UpdateAuthor(p);

            return NoContent();
        }

        [HttpDelete]

        public IActionResult Delete([FromODataUri] int key)
        {
            _repo.DeleteAuthor(key);
            return NoContent();
        }
    }
}
