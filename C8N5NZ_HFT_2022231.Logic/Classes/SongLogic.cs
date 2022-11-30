using C8N5NZ_HFT_2022231.Logic.Interfaces;
using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Models.DTOs;
using C8N5NZ_HFT_2022231.Repository.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Logic.Classes
{
    public class SongLogic : ISongLogic
    {
        IRepository<Song> repo;

        public SongLogic(IRepository<Song> repo)
        {
            this.repo = repo;
        }

        public void Create(Song item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Song Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Song> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Song item)
        {
            repo.Update(item);
        }

        //NON-CRUD
        public IEnumerable<AlbumLengthStat> AlbumByLength()
        {
            var lngth = from x in repo.ReadAll()
                        group x by x.Album.AlbumTitle into g
                        select new AlbumLengthStat()
                        {
                            AlbumTitle = g.Key,
                            Length = g.Sum(t => t.Length)
                        };
            return lngth;
    }

        public IEnumerable<Song> GetSongsByLength(int length)
        {
            return from x in repo.ReadAll()
                   where length == x.Length
                   select x;
        }
    }
}
