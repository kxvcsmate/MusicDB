using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Repository.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Logic
{
    public class AlbumLogic
    {
        IRepository<Album> repo;

        public AlbumLogic(IRepository<Album> repo)
        {
            this.repo = repo;
        }

        public void Create(Album item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Album Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Album> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Album item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<ArtistInfo> ArtistStatistics()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Artist.ArtistId into g
                   select new ArtistInfo()
                   {
                       Name = g.Key,
                       AvgRating = g.Average(t => t.Rating),
                       AlbumNumber = g.Count(),
                       SongNumber = g.Sum(t => t.Songs.Count)
                   };
        }

        public class ArtistInfo
        {
            public int Name { get; set; }
            public double? AvgRating { get; set; }
            public int AlbumNumber { get; set; }
            public int SongNumber { get; set; }
        }
    }
}
