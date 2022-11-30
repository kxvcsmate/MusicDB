using C8N5NZ_HFT_2022231.Logic.Classes;
using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Models.DTOs;
using C8N5NZ_HFT_2022231.Repository.Intefaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Test
{
    [TestFixture]
    public class ArtistLogicTester
    {
        ArtistLogic logic;
        Mock<IRepository<Artist>> mockRepo;
        Artist fakeArtist1;
        Artist fakeArtist2;
        Album album1;
        Album album2;
        Album album3;

        [SetUp]
        public void Init()
        {
            mockRepo = new Mock<IRepository<Artist>>();

            album1 = new Album();
            album1.AlbumId = 1;
            album1.AlbumTitle = "FakeAlbum1";

            album2 = new Album();
            album2.AlbumId = 2;
            album2.AlbumTitle = "FakeAlbum2";

            album3 = new Album();
            album3.AlbumId = 3;
            album3.AlbumTitle = "FakeAlbum3";

            fakeArtist1 = new Artist()
            {
                Name = "Eminem",
                ArtistId = 1,
                Albums = new List<Album>()
                {
                    album1,
                    album2,
                }
            };

            fakeArtist2 = new Artist()
            {
                Name = "Rihanna",
                ArtistId = 2,
                Albums = new List<Album>()
                {
                    album3,
                }
            };

            var artist = new List<Artist>()
            {
                fakeArtist1 , fakeArtist2
            }.AsQueryable();

            mockRepo.Setup(t => t.ReadAll())
                .Returns(artist);

            logic = new ArtistLogic(mockRepo.Object);
        }

        [Test]
        public void NumberOfAlbumsByArtist()
        {
            ArtistStat artistStat = new ArtistStat()
            {
                ArtistName = fakeArtist1.Name,
                AlbumCount = fakeArtist1.Albums.Count,
            };

            var result = logic.NumberOfAlbumsByArtist();

            Assert.That(result.First(), Is.EqualTo(artistStat));
        }

        [Test]
        public void CreateTest()
        {
            Artist fakeArtsit3 = new Artist()
            {
                Name = "Test",
                ArtistId = 3,
                Albums= new List<Album>()
            };

            Assert.That(() => logic.Create(fakeArtsit3), Throws.Nothing);
        }

        [Test]
        public void DeleteTest()
        {
            Assert.That(() => logic.Delete(3), Throws.Nothing);
        }

        [Test]
        public void UpdateTest()
        {
            fakeArtist1 = new Artist()
            {
                Name = "Sia",
                ArtistId = 1,
                Albums = new List<Album>()
                {
                    album1,
                    album2,
                }
            };

            Assert.That(() => logic.Update(fakeArtist1), Throws.Nothing);
        }
    }
}
