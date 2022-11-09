using C8N5NZ_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Repository.Database
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        public MusicDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                .UseInMemoryDatabase("music")
                .UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(album => album
            .HasOne(album => album.Artist)
            .WithMany(artist => artist.Albums)
            .HasForeignKey(album => album.ArtistId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Song>(song => song
            .HasOne(song => song.Album)
            .WithMany(album => album.Songs)
            .HasForeignKey(song => song.AlbumId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Album>().HasData(new Album[]
            {
                new Album("1#The Fame#1#2008#71#14"),
                new Album("2#Born This Way#1#2011#71#14"),
                new Album("3#Chromatica#1#2020#79#16"),
                new Album("4#Untouchables#2#2002#80#14"),
                new Album("5#The Nothing#2#2019#83#13"),
                new Album("6#Requiem#2#2022#77#9"),
                new Album("7#Blurryface#3#2015#80#14"),
                new Album("8#Trench#3#2018#81#14"),
                new Album("9#Scaled and Icy#3#2021#70#11"),
                new Album("10#Born to Die#4#2012#62#12"),
                new Album("11#Ultraviolence#4#2014#74#11"),
                new Album("12#Lust for Life#4#2017#77#16"),
            });
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist("1#Lady Gaga"),
                new Artist("2#Korn"),
                new Artist("3#Twenty One Pilots"),
                new Artist("4#Lana Del Rey"),
            });
            modelBuilder.Entity<Song>().HasData(new Song[]
            {
                new Song("1#Just Dance#3#1"),
                new Song("2#Paparazzi#3#1"),
                new Song("3#Poker Face#4#1"),
                new Song("4#Judas#3#2"),
                new Song("5#Born This Way#2#2"),
                new Song("6#The Edge of Glory#3#2"),
                new Song("7#Stupid Love#4#3"),
                new Song("8#911#2#3"),
                new Song("9#Sour Candy#3#3"),
                new Song("10#Here to Stay#4#4"),
                new Song("11#Blame#3#4"),
                new Song("12#Hollow Life#5#4"),
                new Song("13#Cold#3#5"),
                new Song("14#Finally Free#4#5"),
                new Song("15#This Loss#3#5"),
                new Song("16#Forgotten#2#6"),
                new Song("17#Disconnect#4#6"),
                new Song("18#My Confession#5#6"),
                new Song("19#Ride#4#7"),
                new Song("20#The Judge#3#7"),
                new Song("21#Goner#3#7"),
                new Song("22#Jumpsuit#4#8"),
                new Song("23#Morph#2#8"),
                new Song("24#Chlorine#4#8"),
                new Song("25#Choker#3#9"),
                new Song("26#Shy Away#5#9"),
                new Song("27#Saturday#4#9"),
                new Song("28#Video Games#3#10"),
                new Song("29#Radio#5#10"),
                new Song("30#Dark Paradise#4#10"),
                new Song("31#Sad Girl#2#11"),
                new Song("32#West Coast#3#11"),
                new Song("33#Old Money#4#11"),
                new Song("34#Love#5#12"),
                new Song("35#Cherry#6#12"),
                new Song("36#Change#2#12"),
            });
        }
    }
}
