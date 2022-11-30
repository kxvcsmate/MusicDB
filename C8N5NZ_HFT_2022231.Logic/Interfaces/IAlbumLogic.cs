using C8N5NZ_HFT_2022231.Logic.Classes;
using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace C8N5NZ_HFT_2022231.Logic.Interfaces
{
    public interface IAlbumLogic
    {
        IEnumerable<KeyValuePair<string, double>> AVGRatingByArtist();
        IEnumerable<AlbumStat> NumberOfSongsByAlbum();
        void Create(Album item);
        void Delete(int id);
        Album Read(int id);
        IQueryable<Album> ReadAll();
        void Update(Album item);
    }
}