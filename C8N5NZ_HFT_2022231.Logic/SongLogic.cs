using C8N5NZ_HFT_2022231.Logic.Interfaces;
using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Repository.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Logic
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
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Song Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Song> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Song item)
        {
            this.repo.Update(item);
        }

        //NON-CRUD
        public IEnumerable<KeyValuePair<string, int>> AlbumByLength()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Album.AlbumTitle into g
                   select new KeyValuePair<string, int>(g.Key, g.Sum(t => t.Length));
        }
    }
}
