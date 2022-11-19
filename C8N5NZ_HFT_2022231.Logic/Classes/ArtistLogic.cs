using C8N5NZ_HFT_2022231.Logic.Interfaces;
using C8N5NZ_HFT_2022231.Models;
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
        public IEnumerable<KeyValuePair<string, int>> NumberOfAlbumsByArtist()
        {
            return from x in repo.ReadAll()
                   select new KeyValuePair<string, int>(x.Name, x.Albums.Count);
        }

        public string ArtistWithTheHighestRateALbum()
        {
            var input = repo.ReadAll();
            string name = "";
            double max = 0;
            foreach (var item in input)
            {
                var albums = item.Albums;
                foreach (var a in albums)
                {
                    var rate = a.Rating;
                    if (rate > max)
                    {
                        max = rate;
                        name = item.Name;
                    }
                }
            }
            return name;
        }

    }
}
