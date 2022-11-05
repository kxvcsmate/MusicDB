using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Repository.ModelRepositories
{
    public class ArtistRepository : Repository<Artist>
    {
        public ArtistRepository(MusicDbContext ctx) : base(ctx)
        {
        }

        public override Artist Read(int id)
        {
            return ctx.Artists.FirstOrDefault(c => c.ArtistId == id);
        }

        public override void Update(Artist item)
        {
            var old = Read(item.ArtistId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
