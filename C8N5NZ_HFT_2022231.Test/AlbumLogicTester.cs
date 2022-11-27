using C8N5NZ_HFT_2022231.Logic.Classes;
using C8N5NZ_HFT_2022231.Models;
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

        [SetUp]
        public void Init()
        {
            mockRepo = new Mock<IRepository<Album>>();
            mockRepo.Setup(m => m.ReadAll()).Returns(new List<Album>()
            {
                new Album("1#AlbumA#1#2008#75,2"),
                new Album("2#AlbumB#1#2009#66,7"),
                new Album("3#AlbumC#1#2009#70,1"),
                new Album("4#AlbumD#1#2010#82,3"),
            }.AsQueryable());
            logic = new AlbumLogic(mockRepo.Object);
        }

        [Test]
        public void AlbumWithTheMostSongsTester()
        {
            var result = logic.AlbumWithTheMostSongs();

            Assert.That(result, Is.EqualTo("Ultraviolence"));
        }

    }
}
