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
        //NON-CRUD
        public IEnumerable<KeyValuePair<string, int>> NumberOfSongsByAlbum()
        {
            return from x in this.repo.ReadAll()
                   select new KeyValuePair<string, int>(x.AlbumTitle, x.Songs.Count);
        }
        public IEnumerable<KeyValuePair<string, double>> AVGRatingByArtist()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Artist.Name into g
                   select new KeyValuePair<string, double>(g.Key, g.Average(t => t.Rating));
        }
        public string ArtistWithTheLongestALbum()
        {
            var input = this.repo.ReadAll();
            string name = "";
            var sum = 0;
            foreach (var item in input)
            {
                var length = 0;
                var songs = item.Songs;
                foreach (var s in songs)
                {
                    length += s.Length;
                }
                if (length > sum)
                {
                    sum = length;
                    name = item.Artist.Name;
                }
            }
            return name;
        }
    }
}
