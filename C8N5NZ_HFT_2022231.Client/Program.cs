using C8N5NZ_HFT_2022231.Logic;
using C8N5NZ_HFT_2022231.Logic.Classes;
using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Repository.Database;
using C8N5NZ_HFT_2022231.Repository.GenericRepository;
using C8N5NZ_HFT_2022231.Repository.ModelRepositories;
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
            var ctx = new MusicDbContext();
            var repo = new AlbumRepository(ctx);
            var arepo = new ArtistRepository(ctx);
            var srepo = new SongRepository(ctx);
            var logic = new AlbumLogic(repo);
            var alogic = new ArtistLogic(arepo);
            var slogic = new SongLogic(srepo);

            var test = logic.NumberOfSongsByAlbum();
            var test2 = logic.AVGRatingByArtist();
            var test3 = logic.ArtistWithTheLongestALbum();

            var test4 = alogic.NumberOfAlbumsByArtist();
            var test5 = alogic.ArtistWithTheHighestRateALbum();
            var test6 = slogic.AlbumByLength();
            ;

            RestService rest = new RestService("http://localhost:33531/", "music");
            CrudService crud = new CrudService(rest);
            NonCrudService nonCrud = new NonCrudService(rest);

            var artistSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List("Artist"))
                .Add("Create", () => crud.Create("Artist"))
                .Add("Delete", () => crud.Delete("Artist"))
                .Add("Update", () => crud.Update("Artist"))
                .Add("Exit", ConsoleMenu.Close);

            var albumSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List("Album"))
                .Add("Create", () => crud.Create("Album"))
                .Add("Delete", () => crud.Delete("Album"))
                .Add("Update", () => crud.Update("Album"))
                .Add("Exit", ConsoleMenu.Close);

            var songSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List("Song"))
                .Add("Create", () => crud.Create("Song"))
                .Add("Delete", () => crud.Delete("Song"))
                .Add("Update", () => crud.Update("Song"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Artist", () => artistSubMenu.Show())
                .Add("Albums", () => albumSubMenu.Show())
                .Add("Songs", () => songSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
        }
    }
}
