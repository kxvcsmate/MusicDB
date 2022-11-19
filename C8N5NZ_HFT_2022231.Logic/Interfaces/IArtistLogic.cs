using C8N5NZ_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace C8N5NZ_HFT_2022231.Logic.Interfaces
{
    public interface IArtistLogic
    {
        string ArtistWithTheHighestRateALbum();
        void Create(Artist item);
        void Delete(int id);
        IEnumerable<KeyValuePair<string, int>> NumberOfAlbumsByArtist();
        Artist Read(int id);
        IQueryable<Artist> ReadAll();
        void Update(Artist item);
    }
}