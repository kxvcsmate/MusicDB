using C8N5NZ_HFT_2022231.Logic.Interfaces;
using C8N5NZ_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace C8N5NZ_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        ISongLogic logic;

        public SongController(ISongLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Song> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Song Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Creat([FromBody] Song value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Song value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
