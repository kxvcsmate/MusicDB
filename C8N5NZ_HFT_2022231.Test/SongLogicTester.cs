using C8N5NZ_HFT_2022231.Logic.Classes;
using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Models.DTOs;
using C8N5NZ_HFT_2022231.Repository.Intefaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Test
{
    [TestFixture]
    public class SongLogicTester
    {
        SongLogic logic;
        Mock<IRepository<Song>> mockRepo;
        Album fakeAlbum1;
        Album fakeAlbum2;
        Song song1;
        Song song2;
        Song song3;
        Song song4;
        Song song5;

        [SetUp]
        public void Init()
        {
            mockRepo = new Mock<IRepository<Song>>();

            fakeAlbum1 = new Album();
            fakeAlbum1.AlbumId = 1;
            fakeAlbum1.AlbumTitle = "FakeAlbum1";

            fakeAlbum2 = new Album();
            fakeAlbum2.AlbumId = 2;
            fakeAlbum2.AlbumTitle = "FakeAlbum2";

            song1 = new Song()
            {
                SongTitle ="FakeTitle1",
                SongId = 1,
                Length = 3,
                Album = fakeAlbum1
            };

            song2 = new Song()
            {
                SongTitle = "FakeTitle2",
                SongId= 2,
                Length = 4,
                Album = fakeAlbum1
            };

            song3 = new Song()
            {
                SongTitle = "FakeTitle3",
                SongId= 3,
                Length = 5,
                Album = fakeAlbum1
            };

            song4 = new Song()
            {
                SongTitle = "FakeTitle4",
                SongId= 4,
                Length = 2,
                Album = fakeAlbum2
            };

            song5 = new Song()
            {
                SongTitle = "FakeTitle5",
                SongId= 5,
                Length = 6,
                Album = fakeAlbum2
            };

            var songs = new List<Song>()
            {
                song1, song2, song3, song4, song5
            }.AsQueryable();

            mockRepo.Setup(t => t.ReadAll())
                .Returns(songs);

            logic = new SongLogic(mockRepo.Object);
        }
        [Test]
        public void AlbumByLengthTest()
        {
            var result = logic.AlbumByLength();
            var expectedResult = new Dictionary<string, int> { { "FakeAlbum1", 12 }, { "FakeAlbum2", 8 } };

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetSongsByLengthTest()
        {
            int length = 3;

            var songs = logic.GetSongsByLength(length);

            mockRepo.Verify(mockRepo => mockRepo.ReadAll(), Times.Once());
            Assert.That(songs, Has.Exactly(1).Items);
            Assert.That(songs.First(), Is.EqualTo(song1));
        }

        [Test]
        public void CreateTest()
        {
            Song song6 = new Song()
            {
                SongTitle = "Test",
                SongId= 6,
                Length = 4,
                Album = fakeAlbum1
            };

            Assert.That(() => logic.Create(song6), Throws.Nothing);
        }

        [Test]
        public void DeleteTest()
        {
            Assert.That(() => logic.Delete(1), Throws.Nothing);
        }

        [Test]
        public void UpdateTest()
        {
            song1 = new Song()
            {
                SongTitle = "Test",
                SongId = 1,
                Length = 3,
                Album = fakeAlbum1
            };

            Assert.That(() => logic.Update(song1), Throws.Nothing);
        }
    }
}
