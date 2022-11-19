using C8N5NZ_HFT_2022231.Logic;
using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Repository.Database;
using C8N5NZ_HFT_2022231.Repository.GenericRepository;
using C8N5NZ_HFT_2022231.Repository.ModelRepositories;
using System;
using System.Linq;

namespace C8N5NZ_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MusicDbContext();
            var repo = new AlbumRepository(ctx);
            var logic = new AlbumLogic(repo);

            var test = logic.NumberOfSongsByAlbum();
            var test2 = logic.AVGRatingByArtist();
            var test3 = logic.ArtistWithTheLongestALbum();
            ;

        }
    }
}
