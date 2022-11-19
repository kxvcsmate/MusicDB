using C8N5NZ_HFT_2022231.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace C8N5NZ_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        IAlbumLogic logic;

        // GET: api/<AlbumController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AlbumController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlbumController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlbumController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlbumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
