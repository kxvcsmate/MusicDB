using C8N5NZ_HFT_2022231.Logic.Interfaces;
using C8N5NZ_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace C8N5NZ_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        IAlbumLogic logic;

        public AlbumController(IAlbumLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Album> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Album Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Creat([FromBody] Album value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Album value)
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
