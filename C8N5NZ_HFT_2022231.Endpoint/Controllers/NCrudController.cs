using C8N5NZ_HFT_2022231.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using C8N5NZ_HFT_2022231.Models.DTOs;
using C8N5NZ_HFT_2022231.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace C8N5NZ_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NCrudController : ControllerBase
    {
        IAlbumLogic albumLogic;
        IArtistLogic artistLogic;
        ISongLogic songLogic;

        public NCrudController(IAlbumLogic albumLogic, IArtistLogic artistLogic, ISongLogic songLogic)
        {
            this.albumLogic = albumLogic;
            this.artistLogic = artistLogic;
            this.songLogic = songLogic;
        }

        [HttpGet]
        public IEnumerable<AlbumStat> NumberOfSongsByAlbum()
        {
            return albumLogic.NumberOfSongsByAlbum();
        }

        [HttpGet]
        public IEnumerable<ArtistStat> NumberOfAlbumsByArtist()
        {
            return artistLogic.NumberOfAlbumsByArtist();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string,double>> AVGRatingByArtist()
        {
            return albumLogic.AVGRatingByArtist();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> AlbumByLength()
        {
            return songLogic.AlbumByLength();
        }

        [HttpGet]
        public IEnumerable<Song> GetCarsByPriceRange([FromQuery] int length)
        {
            return songLogic.GetSongsByLength(length);
        }
    }
}
