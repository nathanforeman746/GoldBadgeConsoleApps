using Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadgesRepoTests
{
    [TestClass]
    public class BadgesRepoTests
    {
        private BadgesRepo _repo;
        private Badge _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepo();

            List<string> doors1 = new List<string>();
            doors1.Add("A1");
            doors1.Add("A2");
            doors1.Add("A3");

            _content = new Badge(2000, doors1);

            _repo.AddToAccessList(_content);
        }
        [TestMethod]
        public void AddToAccessList_NotNull()
        {
            //Arrange
            //Test Initialize
            //Act
            Badge badgeFromDictionary = _repo.GetBadgeID(2000);

            //Assert
            Assert.IsNotNull(badgeFromDictionary);
        }

        [TestMethod]
        public void GetAccessList_NotNull()
        {
            //Arrange
            //Test Initialize
            //Act
            Dictionary<int, List<string>> badgeDictionary = _repo.GetAccessList();

            //Assert
            Assert.IsNotNull(badgeDictionary);
        }

        [TestMethod]
        public void AddDoor_AreEqual()
        {

            //Arrange
            //Test Initialize

            //Act
            int id = _content.BadgeID;
            string door = ("A4");

            _repo.AddDoor(id, door);

            //Assert
            Assert.AreEqual(4, _content.Doors.Count);
        }

        [TestMethod]
        public void DeleteDoor_AreEqual()
        {
            //Arrange
            //Test Initialize

            //Act
            int id = _content.BadgeID;
            string door = "A3";

            _repo.DeleteDoor(id, door);

            //Assert
            Assert.AreEqual(2, _content.Doors.Count);
        }
    }
}
