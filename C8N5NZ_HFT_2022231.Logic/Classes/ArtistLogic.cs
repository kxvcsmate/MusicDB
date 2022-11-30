using C8N5NZ_HFT_2022231.Logic.Interfaces;
using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Models.DTOs;
using C8N5NZ_HFT_2022231.Repository.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Logic.Classes
{
    public class ArtistLogic : IArtistLogic
    {
        IRepository<Artist> repo;

        public ArtistLogic(IRepository<Artist> repo)
        {
            this.repo = repo;
        }

        public void Create(Artist item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Artist Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Artist> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Artist item)
        {
            repo.Update(item);
        }

        //NON-CRUD
        public IEnumerable<ArtistStat> NumberOfAlbumsByArtist()
        {
            var artistStats = from x in this.repo.ReadAll()
                             select new ArtistStat()
                             {
                                 ArtistName = x.Name,
                                 AlbumCount = x.Albums.Count,
                             };
            return artistStats;
        }

    }
}
