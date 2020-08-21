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
        public void AddContentToDirectory_ShouldAddContent()
        {
            // arrange
            ChallengeOneRepository repo = new ChallengeOneRepository();

            ChallengeOneContent content = new ChallengeOneContent();
            repo.AddContentToDirectory(content);

            // act
            List<ChallengeOneContent> directory = repo.GetDirectory();

            bool directoryHascontent = directory.Contains(content);

            // assert
            Assert.IsTrue(directoryHascontent);
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
    
        [DataTestMethod]
        [DataRow("BLT Sandwich", true)]
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue(string name, bool expectedResult)
        {
            // arrange
            // act
            bool updateContent = _repo.UpdateExistingContent(_content, name);

            // assert
            Assert.AreEqual(expectedResult, updateContent);
        }


        [TestMethod]
        public void DeleteExistingContent_ShouldReturnFalse()
        {
            
            bool removedResult = _repo.DeleteExistingContent(_content);
            Assert.IsTrue(removedResult);

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
