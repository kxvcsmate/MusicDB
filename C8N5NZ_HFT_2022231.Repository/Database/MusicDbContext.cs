using C8N5NZ_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Repository.Database
{
    public class MusicDbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        public MusicDbContext()
        {
            this.Database.EnsureCreated();
        }
        
    }
}
