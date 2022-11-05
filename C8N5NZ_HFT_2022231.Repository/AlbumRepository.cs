using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Repository
{
    public class AlbumRepository : Repository<Album>
    {
        public AlbumRepository(MusicDbContext ctx) : base(ctx)
        {
        }

        public override Album Read(int id)
        {
            return ctx.Albums.FirstOrDefault(c => c.AlbumId == id);
        }

        public override void Update(Album item)
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
