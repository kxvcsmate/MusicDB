using C8N5NZ_HFT_2022231.Repository.Database;
using System;
using System.Linq;

namespace C8N5NZ_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicDbContext ctx = new MusicDbContext();

            ctx.Albums.ToList().ForEach(t => Console.WriteLine(t.AlbumTitle));
        }
    }
}
