using C8N5NZ_HFT_2022231.Logic.Classes;
using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Models.DTOs;
using C8N5NZ_HFT_2022231.Repository.Intefaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace C8N5NZ_HFT_2022231.Test
{
    [TestFixture]
    public class AlbumLogicTester
    {
        AlbumLogic logic;
        Mock<IRepository<Album>> mockRepo;
        Artist fakeArtist;
        Album album1;
        Album album2;
        Album album3;

        [SetUp]
        public void Init()
        {
            mockRepo = new Mock<IRepository<Album>>();

            fakeArtist = new Artist();
            fakeArtist.ArtistId = 1;
            fakeArtist.Name = "Eminem";

            album1 = new Album()
            {
                AlbumTitle = "AlbumA",
                AlbumId= 1,
                Rating = 64,
                Release = 2009,
                Artist = fakeArtist,
                Songs = new List<Song>()
                {
                    new Song()
                    {
                        SongTitle = "A",
                        Length= 4,
                    }
                }
            };

            album2 = new Album()
            {
                AlbumTitle = "AlbumB",
                AlbumId= 2,
                Rating = 73,
                Release = 2008,
                Artist = fakeArtist,
                Songs = new List<Song>()
                {
                    new Song()
                    {
                        SongTitle = "B",
                        Length= 2,
                    },
                    new Song()
                    {
                        SongTitle = "C",
                        Length= 1,
                    }
                }
            };

            album3 = new Album()
            {
                AlbumTitle = "AlbumC",
                AlbumId= 3,
                Rating = 82,
                Release = 2009,
                Artist = fakeArtist,
                Songs = new List<Song>()
                {
                    new Song()
                    {
                        SongTitle = "D",
                        Length= 2,
                    },
                    new Song()
                    {
                        SongTitle = "E",
                        Length= 3,
                    },
                    new Song()
                    {
                        SongTitle = "F",
                        Length= 3,
                    }
                }
            };

            var albums = new List<Album>()
            {
                album1 , album2 , album3
            }.AsQueryable();

            mockRepo.Setup(t => t.ReadAll())
                .Returns(albums);

            logic = new AlbumLogic(mockRepo.Object);
        }

        [Test]
        public void AVGRatingByArtistTest()
        {
            var result = logic.AVGRatingByArtist();
            var expectedResult = new Dictionary<string, double> { { "Eminem", 73 } };

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void NumberOfSongsByAlbumTest()
        {
            AlbumStat albumStat = new AlbumStat()
            {
                AlbumTitle = album1.AlbumTitle,
                SongCount = album1.Songs.Count,
            };

            var result = logic.NumberOfSongsByAlbum();

            Assert.That(result.First(), Is.EqualTo(albumStat));
        }

        [Test]
        public void CreateTest()
        {
            Album album4 = new Album()
            {
                AlbumTitle = "AlbumTest",
                AlbumId = 4,
                Rating = 66,
                Release = 2010,
                Artist = fakeArtist,
                Songs= new List<Song>()
            };

            Assert.That(() => logic.Create(album4), Throws.Nothing);
        }

        [Test]
        public void DeleteTest()
        {
            Assert.That(() => logic.Delete(1), Throws.Nothing);
        }

        [Test]
        public void UpdateTest()
        {
            album1 = new Album()
            {
                AlbumTitle = "AlbumTest",
                AlbumId = 1,
                Rating = 64,
                Release = 2009,
                Artist = fakeArtist,
                Songs = new List<Song>()
                {
                    new Song()
                    {
                        SongTitle = "A",
                        Length= 4,
                    }
                }
            };

            Assert.That(() => logic.Update(album1), Throws.Nothing);
        }
    }
}
