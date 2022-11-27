using C8N5NZ_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Client
{
    public class NonCrudService
    {
        private RestService rest;

        public NonCrudService(RestService rest)
        {
            this.rest = rest;
        }
        public void AlbumWithTheMostSongs()
        {
            var result = rest.GetSingle<string>("Stat/AlbumWithTheMostSongs");
            Console.WriteLine($"Album with the most songs: {result}");
            Console.ReadLine();
        }
        public void ArtistWithTheLongestALbum()
        {
            var result = rest.GetSingle<string>("Stat/ArtistWithTheLongestALbum");
            Console.WriteLine($"Artist with the longest aLbum: {result}");
            Console.ReadLine();
        }
        public void AVGRatingByArtist()
        {
            var items = rest.Get<Artist>("Stat/AVGRatingByArtist");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public void ArtistWithTheHighestRateALbum()
        {
            var result = rest.GetSingle<string>("Stat/ArtistWithTheHighestRateALbum");
            Console.WriteLine($"Artist with the highest rate aLbum: {result}");
            Console.ReadLine();
        }
        public void AlbumByLength()
        {
            var items = rest.Get<Album>("Stat/AlbumByLength");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

    }
}
