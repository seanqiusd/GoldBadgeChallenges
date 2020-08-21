using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using _03_ChallengeThreeConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_ChallengeThreeTests
{
    [TestClass]
    public class ChallengeThreeRepositoryTests
    {

        private ChallengeThreeRepository _repo;
        private ChallengeThreeBadge _badge;
        private Dictionary<int, List<string>> _dictionary;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ChallengeThreeRepository();
            _dictionary = new Dictionary<int, List<string>>();

            _dictionary.Add(1, new List<string> { "A5", "A7" });
            _badge = new ChallengeThreeBadge();
        }


        [TestMethod]
        public void AddBadgeToDictionary_ShouldReturnCorrect()
        {
            // arrange 

            ChallengeThreeRepository repo = new ChallengeThreeRepository();
            List<string> stringOfDoors = new List<string> { "A1", "B5", "C15" };
            Dictionary<int, List<string>> badge = new Dictionary<int, List<string>>();
            repo.AddBadgeToDictionary(1, stringOfDoors);
            int count = _repo.GetBadgesFromDictionary().Count;

            Assert.AreEqual(1, count);

        }

        [DataTestMethod]
        [DataRow(12345, true)]
        public void DeleteExistingDoor_ShouldReturnTrue(string listDoor, bool expectedResult)
        {

            bool deleteDoor = _repo.RemoveADoor(12345, listDoor); // Dont know why this is erroring out

            Assert.AreEqual(expectedResult, deleteDoor);
        }

        [DataTestMethod]
        [DataRow(12345, false)]
        public void AddExistingDoor_ShouldReturnFalse(string listDoor, bool expectedResult)
        {

            bool AddDoor = _repo.AddADoor(12345, listDoor); // Dont know why this is erroring out

            Assert.AreEqual(expectedResult, AddDoor);
        }

      










    }
}
