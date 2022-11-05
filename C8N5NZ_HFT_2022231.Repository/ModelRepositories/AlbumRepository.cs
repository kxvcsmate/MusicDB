using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Repository.Database;
using C8N5NZ_HFT_2022231.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Repository.ModelRepositories
{
    public class AlbumRepository : Repository<Artist>
    {
        public AlbumRepository(MusicDbContext ctx) : base(ctx)
        {
        }

        public override Artist Read(int id)
        {
            return ctx.Albums.FirstOrDefault(c => c.AlbumId == id);
        }

        public override void Update(Artist item)
        {
            var old = Read(item.AlbumId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
