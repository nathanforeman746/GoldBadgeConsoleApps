using Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsRepoTests
{
    [TestClass]
     public class ClaimsRepoTests
     {
        private ClaimsRepo _repo;
        private Claim _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _content = new Claim(787, ClaimType.Car, "High Speed Crash", 3599.99m, new DateTime(2021, 11, 4), new DateTime(2021, 11, 5), true);

            _repo.AddClaim(_content);
        }
        [TestMethod]
        public void AddClaim_NotNull()
        {
            //Arrange
            //Test Init
            //Act
            //Assert
            Assert.IsNotNull(_repo.ViewClaimList());
            bool containsContent = _repo.ViewClaimList().Contains(_content);
            Assert.IsTrue(containsContent);
        }
    }
}
