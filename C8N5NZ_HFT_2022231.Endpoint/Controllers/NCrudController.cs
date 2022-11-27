using C8N5NZ_HFT_2022231.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<KeyValuePair<string, int>> NumberOfSongsByAlbum()
        {
            return albumLogic.NumberOfSongsByAlbum();
        }

        [HttpGet]
        public string AlbumWithTheMostSongs()
        {
            return albumLogic.AlbumWithTheMostSongs();
        }

        [HttpGet]
        public string ArtistWithTheLongestALbum()
        {
            return albumLogic.ArtistWithTheLongestALbum();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string,double>> AVGRatingByArtist()
        {
            return albumLogic.AVGRatingByArtist();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> NumberOfAlbumsByArtist()
        {
            return artistLogic.NumberOfAlbumsByArtist();
        }

        [HttpGet]
        public string ArtistWithTheHighestRateALbum()
        {
            return artistLogic.ArtistWithTheHighestRateALbum();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> AlbumByLength()
        {
            return songLogic.AlbumByLength();
        }
    }
}
