using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeTestMethod
{
    [TestClass]
    public class MenuRepoTests
    {
        private MenuRepo _repo;
        private MenuClass _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _content = new MenuClass(4, "Calzone", "Buttery and Crisp Calzone with 5 Ounces of Cheese and comes with Pepperoni, Sausage and Bacon", "Cheese, Bacon, Sausage, and Pepperoni", 10.50m);

            _repo.AddMenuToList(_content);
        }
        [TestMethod]
        public void AddToMenu_NotNull()
        {
            //Arrange
            MenuClass menu = new MenuClass();
            menu.ID = 4;
            MenuRepo _menuRepo = new MenuRepo();

            //Act
            _menuRepo.AddMenuToList(menu);
            MenuClass itemFromDirectory = _menuRepo.GetItemID(4);

            //Assert
            Assert.IsNotNull(itemFromDirectory);
        }

        [TestMethod]
        public void GetMenuList_NotNull()
        {
            //Arrange
            //Test Initialize
            //Act
            List<MenuClass> menuList = _repo.GetMenuList();

            //Assert
            Assert.IsNotNull(menuList);
        }

        [TestMethod]
        public void UpdateMenuItem_ReturnTrue()
        {
            //Arrange
            //Test Initialize
            MenuClass newMenuItem = new MenuClass(5, "Wings", "Traditional Bone-In Wings lathered in your choice of sauce.", "Chicken Wings, BBQ Sauce, Hot Sauce, Habanero Mango Sauce, Sweet Red Chili Sauce, Garlic Parm Sauce", 9.99m);

            //Act
            bool updateResult = _repo.UpdateMenuItem(4, newMenuItem);

            //Assert
            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void RemoveMenuItem_ReturnTrue()
        {
            //Arrange
            //Act
            bool deleteResult = _repo.RemoveMenuItem(_content.ID);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
