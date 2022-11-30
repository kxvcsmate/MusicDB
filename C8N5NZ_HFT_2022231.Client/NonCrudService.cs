using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        public void NumberOfSongsByAlbum()
        {
            var items = rest.Get<AlbumStat>("Stat/NumberOfSongsByAlbum");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void NumberOfAlbumsByArtist()
        {
            var items = rest.Get<ArtistStat>("Stat/NumberOfAlbumsByArtist");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public void GetSongsByLength()
        {
            Console.WriteLine("Length=");
            int length = int.Parse(Console.ReadLine());

            var items = rest.Get<Song>($"Stat/GetSongsByLength?length={length}");
            foreach (var item in items)
            {
                Console.WriteLine("Title: " + item.SongTitle + ", " + "Artist: " + item.Album.Artist.Name);
            }
            Console.ReadLine();
        }
        public void AVGRatingByArtist()
        {
            var items = rest.Get<AVGRating>("Stat/AVGRatingByArtist");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public void AlbumByLength()
        {
            var items = rest.Get<AlbumLengthStat>("Stat/AlbumByLength");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

    }
}
