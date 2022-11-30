using C8N5NZ_HFT_2022231.Logic.Classes;
using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace C8N5NZ_HFT_2022231.Logic.Interfaces
{
    public interface IArtistLogic
    {
        IEnumerable<ArtistStat> NumberOfAlbumsByArtist();
        void Create(Artist item);
        void Delete(int id);
        Artist Read(int id);
        IQueryable<Artist> ReadAll();
        void Update(Artist item);
    }
}