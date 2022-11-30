using C8N5NZ_HFT_2022231.Models;
using ConsoleTools;
using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace C8N5NZ_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:53770/", "music");
            CrudService crud = new CrudService(rest);
            NonCrudService nonCrud = new NonCrudService(rest);

            var albumSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Album>())
                .Add("Create", () => crud.Create<Album>())
                .Add("Delete", () => crud.Delete<Album>())
                .Add("Update", () => crud.Update<Album>())
                .Add("Exit", ConsoleMenu.Close);

            var artistSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("List", () => crud.List<Artist>())
                 .Add("Create", () => crud.Create<Artist>())
                 .Add("Delete", () => crud.Delete<Artist>())
                 .Add("Update", () => crud.Update<Artist>())
                 .Add("Exit", ConsoleMenu.Close);

            var songSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("List", () => crud.List<Song>())
                 .Add("Create", () => crud.Create<Song>())
                 .Add("Delete", () => crud.Delete<Song>())
                 .Add("Update", () => crud.Update<Song>())
                 .Add("Exit", ConsoleMenu.Close);

            var ncrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Artist statistics", () => nonCrud.NumberOfAlbumsByArtist())
                .Add("Album statistics", () => nonCrud.NumberOfSongsByAlbum())
                .Add("Songs by length", () => nonCrud.GetSongsByLength())
                .Add("Average ratings by Artist", () => nonCrud.AVGRatingByArtist())
                .Add("Albums by Length", () => nonCrud.AlbumByLength())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Albums", () => albumSubMenu.Show())
                .Add("Artists", () => artistSubMenu.Show())
                .Add("Songs", () => songSubMenu.Show())
                .Add("Non-CRUD", () => ncrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
