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
                new Album("1#The Fame#1#2008#72,3"),
                new Album("2#Born This Way#1#2011#77,4"),
                new Album("3#Follow the Leader#1#1998#79,2"),
                new Album("4#Untouchables#2#2002#80,1"),
                new Album("5#The Nothing#2#2019#83,6"),
                new Album("6#Requiem#2#2022#77,8"),
                new Album("7#Blurryface#3#2015#80,5"),
                new Album("8#Trench#3#2018#81,6"),
                new Album("9#Scaled and Icy#3#2021#70,4"),
                new Album("10#Born to Die#4#2012#62,8"),
                new Album("11#Ultraviolence#4#2014#74,4"),
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
                new Song("2#Love Game#3#1"),
                new Song("3#Paparazzi#3#1"),
                new Song("4#Poker Face#4#1"),
                new Song("5#Eh, Eh#3#1"),
                new Song("6#Beautiful, Dirty, Rich#3#1"),
                new Song("7#The Fame#4#1"),
                new Song("8#Money Honey#3#1"),
                new Song("9#Starstruck#4#1"),
                new Song("10#Boys Boys Boys#3#1"),
                new Song("11#Paper Gangsta#4#1"),
                new Song("12#Brown Eyes#4#1"),
                new Song("13#I Like It Rough#3#1"),
                new Song("14#Summerboy#4#1"),
                
                new Song("15#Marry the Night#4#2"),
                new Song("16#Born This Way#4#2"),
                new Song("17#Government Hooker#4#1"),
                new Song("18#Judas#4#2"),
                new Song("19#Americano#4#2"),
                new Song("20#Hair#5#2"),
                new Song("21#Bloody Mary#4#2"),
                new Song("22#Bad Kids#4#2"),
                new Song("23#Road to Love#4#2"),
                new Song("24#Heavy Metal Lover#4#2"),
                new Song("25#You and I#5#2"),
                new Song("26#The Edge of Glory#5#2"),
                
                new Song("27#It's On#4#3"),
                new Song("28#Freak on a Leash#4#3"),
                new Song("29#Got the Life#4#3"),
                new Song("30#Dead Bodies Everywhere#5#3"),
                new Song("31#Children of the Korn#4#3"),
                new Song("32#BBK#4#3"),
                new Song("33#Pretty#4#3"),
                new Song("34#All in the Family#5#3"),
                new Song("35#Reclaim My Place#5#3"),
                new Song("36#Justin#4#3"),
                new Song("37#Seed#6#3"),
                new Song("38#Cameltosis#5#3"),
                new Song("39#My Gift to You#7#3"),
                new Song("40#Earache My Eye#5#3"),
                
                new Song("41#Here to Stay#4#4"),
                new Song("42#Make Believe#4#4"),
                new Song("43#Blame#4#4"),
                new Song("44#Hollow Life#4#4"),
                new Song("45#Bottled Up Inside#4#4"),
                new Song("46#Thoughtless#4#4"),
                new Song("47#Hating#5#4"),
                new Song("48#One Mare Time#4#4"),
                new Song("49#Alone I Break#4#4"),
                new Song("50#Embrace#4#4"),
                new Song("51#Beat It Upright#4#4"),
                new Song("52#Wake Up Hate#3#4"),
                new Song("53#I'm Hiding#4#4"),
                new Song("54#No One's There#5#4"),
                
                new Song("55#The End Begins#2#5"),
                new Song("56#Cold#4#5"),
                new Song("57#You'll Never Find Me#4#5"),
                new Song("58#The Darkness Is Revealing#4#5"),
                new Song("59#Idiosyncrasy#4#5"),
                new Song("60#The Seduction of Indulgence#2#5"),
                new Song("61#Finally Free#4#5"),
                new Song("62#Can You Hear Me#3#5"),
                new Song("63#The Ringmaster#3#5"),
                new Song("64#Gravity of Discomfort#3#5"),
                new Song("65#Harder#5#5"),
                new Song("66#This Loss#5#5"),
                new Song("67#Surrender to Failure#2#5"),
                
                new Song("68#Forgotten#3#6"),
                new Song("69#Let The Dark Do the Rest#3#6"),
                new Song("70#Start the Healing#3#6"),
                new Song("71#Lost in the Grandeur#4#6"),
                new Song("72#Disconnect#3#6"),
                new Song("73#Hopeless and Beaten#4#6"),
                new Song("74#Penance to Sorrow#3#6"),
                new Song("75#My Confession#3#6"),
                new Song("76#Worst Is on Its Way#4#6"),
                
                new Song("77#Heavydirtysoul#4#7"),
                new Song("78#Stressed Out#3#7"),
                new Song("79#Ride#3#7"),
                new Song("80#Fairy Local#3#7"),
                new Song("81#Tear in My Heart#3#7"),
                new Song("82#Lane Boy#4#7"),
                new Song("83#The Judge#5#7"),
                new Song("84#Doubt#3#7"),
                new Song("85#Polarize#4#7"),
                new Song("86#Message Man#4#7"),
                new Song("87#Hometown#4#7"),
                new Song("88#Not Today#4#7"),
                new Song("89#Goner#4#7"),
                
                new Song("90#Jumpsuit#4#8"),
                new Song("91#Levitate#2#8"),
                new Song("92#Morph#4#8"),
                new Song("93#My Blood#4#8"),
                new Song("94#Chlorine#5#8"),
                new Song("95#Smithereens#3#8"),
                new Song("96#Neon Gravestone#4#8"),
                new Song("97#The Hype#4#8"),
                new Song("98#Nico and the Niners#4#8"),
                new Song("99#Cut My Lip#5#8"),
                new Song("100#Bandito#5#8"),
                new Song("101#et Cheetah#3#8"),
                new Song("102#Legend#3#8"),
                new Song("103#Leave the City#5#8"),
                
                new Song("104#Good Day#3#9"),
                new Song("105#Choker#4#9"),
                new Song("106#Shy Away#3#9"),
                new Song("107#The Outside#3#9"),
                new Song("108#Saturday#3#9"),
                new Song("109#Never Take It#4#9"),
                new Song("110#Mulberry Street#4#9"),
                new Song("111#Formidable#3#9"),
                new Song("112#Bounce Man#3#9"),
                new Song("113#No Chances#4#9"),
                new Song("114#Redecorate#4#9"),
                
                new Song("115#Born to Die#5#10"),
                new Song("116#Off to the Races#5#10"),
                new Song("117#Blue Jeans#3#10"),
                new Song("118#Video Games#5#10"),
                new Song("119#Diet Mountain Dew#4#10"),
                new Song("120#National Anthem#4#10"),
                new Song("121#Dark Paradise#4#10"),
                new Song("122#Radio#3#10"),
                new Song("123#Carmen#4#10"),
                new Song("124#Million Dollar Man#4#10"),
                new Song("125#Summertime Sadness#4#10"),
                new Song("126#This is What Makes Us Girls#4#10"),
                
                new Song("127#Cruel World#6#11"),
                new Song("128#Ultraviolence#4#11"),
                new Song("129#Shades of Cool#6#11"),
                new Song("130#Brooklyn Baby#6#11"),
                new Song("131#West Coast#4#11"),
                new Song("132#Sad Girl#5#11"),
                new Song("133#Pretty When You Cry#4#11"),
                new Song("134#Money Power Glory#4#11"),
                new Song("135#Fucked My Way Up to the Top#3#11"),
                new Song("136#Old Money#4#11"),
                new Song("137#The Other Woman#3#11"),
                new Song("138#Black Beauty#5#11"),
                new Song("139#Guns and Roses#3#11"),
                new Song("140#Florida Kilos#4#11"),
                new Song("141#Is This Happiness#3#11"),
                new Song("142#Flipside#5#11"),
            });
        }
    }
}
