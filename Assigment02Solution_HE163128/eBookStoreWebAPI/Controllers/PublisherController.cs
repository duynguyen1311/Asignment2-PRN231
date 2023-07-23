using BusinessObject.Model;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PublisherController : ODataController
    {
        private readonly IPublisherRepository _repo;

        public PublisherController(IPublisherRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var list = _repo.GetPublishers();
            return Ok(list);
        }

        [HttpGet("{key}")]
        [EnableQuery]
    
        public IActionResult Get([FromODataUri] int key)
        {
            var Publisher = _repo.GetPublisherById(key);
            if (Publisher == null)
            {
                return NotFound();
            }

            return Ok(Publisher);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Publisher p)
        {
            _repo.SavePublisher(p);

            return Created(nameof(PublisherController), p);
        }

        [HttpPut]
        public IActionResult Put([FromODataUri] int key, Publisher p)
        {
            if (key != p.pub_id)
            {
                return BadRequest();
            }

            _repo.UpdatePublisher(p);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromODataUri] int key)
        {
            _repo.DeletePublisher(key);
            return NoContent();
        }
    }
}
