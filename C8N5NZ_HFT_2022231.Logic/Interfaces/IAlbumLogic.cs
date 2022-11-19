using C8N5NZ_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace C8N5NZ_HFT_2022231.Logic.Interfaces
{
    public interface IAlbumLogic
    {
        string ArtistWithTheLongestALbum();
        IEnumerable<KeyValuePair<string, double>> AVGRatingByArtist();
        void Create(Album item);
        void Delete(int id);
        IEnumerable<KeyValuePair<string, int>> NumberOfSongsByAlbum();
        Album Read(int id);
        IQueryable<Album> ReadAll();
        void Update(Album item);
    }
}