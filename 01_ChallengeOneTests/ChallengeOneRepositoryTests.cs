using System;
using System.Collections.Generic;
using _01_ChallengeOneConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_ChallengeOneTests
{
    [TestClass]
    public class ChallengeOneRepositoryTests
    {
        private ChallengeOneRepository _repo;
        private ChallengeOneContent _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ChallengeOneRepository();
            _content = new ChallengeOneContent(15, "BLT Sandwich", "Cannot go wrong with a classic and bacon", "bacon, lettuce, tomato, rye bread, mayo", 9.99m);

            _repo.AddContentToDirectory(_content);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            // arrange
            ChallengeOneRepository repo = new ChallengeOneRepository();

            ChallengeOneContent item = new ChallengeOneContent();
            repo.AddContentToDirectory(item);

            // act
            List<ChallengeOneContent> directory = repo.GetDirectory();

            bool directoryHasItem = directory.Contains(item);

            // assert
            Assert.IsTrue(directoryHasItem);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            // arrange
            // act
            bool removeResult = _repo.DeleteExistingContent(_content);

            // assert
            Assert.IsTrue(removeResult);
        }

        [DataTestMethod]
        [DataRow("blt sandwich", true)]
        [DataRow("king blt", false)]
        public void DeleteContentByMealName_ShouldReturnCorrectBool(string mealName, bool expectedResult)
        {
            // arrange
            // act
            bool actualResult = _repo.DeleteContentByMealName(mealName);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }


    }
}
