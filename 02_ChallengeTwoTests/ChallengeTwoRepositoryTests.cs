using System;
using _02_ChallengeTwoConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ChallengeTwoTests
{
    [TestClass]
    public class ChallengeTwoRepositoryTests
    {
        private ChallengeTwoRepository _repo;
        private ChallengeTwoContent _challengeTwoContent;

        [TestInitialize]
        public void arrange()
        {
            _repo = new ChallengeTwoRepository();

            ChallengeTwoContent dateofFirstIncident = new ChallengeTwoContent();

            dateofFirstIncident.DateOfIncident = new DateTime(2020, 08, 01);

            ChallengeTwoContent dateofFirstClaim = new ChallengeTwoContent();

            dateofFirstClaim.DateOfClaim = new DateTime(2020, 08, 25);

            _challengeTwoContent = new ChallengeTwoContent(2, ClaimType.Home, "House fire in kitchen", 4000.00m, dateofFirstIncident.DateOfIncident, dateofFirstClaim.DateOfClaim);

            _repo.AddContentToDirectory(_challengeTwoContent);
        }

        [TestMethod]
        public void AddContentToDirectory_ShouldReturnContent()
        {
            ChallengeTwoRepository repo = new ChallengeTwoRepository();

            ChallengeTwoContent dateOfIncident = new ChallengeTwoContent();
            dateOfIncident.DateOfIncident = new DateTime(2020, 08, 01);

            ChallengeTwoContent dateOfClaim = new ChallengeTwoContent();
            dateOfClaim.DateOfClaim = new DateTime(2020, 08, 01);

            ChallengeTwoContent content = new ChallengeTwoContent(6, ClaimType.Car, "Hail damaged", 2300.00m, dateOfIncident.DateOfIncident, dateOfClaim.DateOfClaim);

            repo.AddContentToDirectory(content);

            Assert.AreEqual(content.ClaimID, 6);
        }

        [TestMethod]
        public void GetContentByClaimID_ShouldReturnContent()
        {
            ChallengeTwoContent content = _repo.GetContentByClaimID(2);

            Assert.AreEqual(content.ClaimType, ClaimType.Home);
        }

        [DataTestMethod]
        [DataRow(2, true)]
        public void UpdateExistingContentByClaimID_ShouldReturnAsTrue(int id, bool expectedOutcome)
        {
            bool updatedContent = _repo.UpdateExistingContentByClaimID(_challengeTwoContent, id);

            Assert.AreEqual(expectedOutcome, updatedContent);
        }

        [DataTestMethod]
        [DataRow(2, false)]
        public void DeleteExistingContent_ShouldReturnAsFalse(int id, bool expectedOutcome)
        {
            bool updatedContent = _repo.UpdateExistingContentByClaimID(_challengeTwoContent, id);

            Assert.AreNotEqual(expectedOutcome, updatedContent);
        }






    }
}
