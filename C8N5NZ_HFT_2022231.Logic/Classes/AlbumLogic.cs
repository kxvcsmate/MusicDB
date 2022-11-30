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
    public class AlbumLogic : IAlbumLogic
    {
        IRepository<Album> repo;

        public AlbumLogic(IRepository<Album> repo)
        {
            this.repo = repo;
        }

        public void Create(Album item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Album Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Album> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Album item)
        {
            repo.Update(item);
        }
        //NON-CRUD
        public IEnumerable<AlbumStat> NumberOfSongsByAlbum()
        {
            var albumStats = from x in this.repo.ReadAll()
                             select new AlbumStat()
                             {
                                 AlbumTitle = x.AlbumTitle,
                                 SongCount = x.Songs.Count,
                             };
            return albumStats;
        }

        public IEnumerable<KeyValuePair<string, double>> AVGRatingByArtist()
        {
            return from x in repo.ReadAll()
                   group x by x.Artist.Name into g
                   select new KeyValuePair<string, double>(g.Key, g.Average(t => t.Rating));
        }
    }
}
