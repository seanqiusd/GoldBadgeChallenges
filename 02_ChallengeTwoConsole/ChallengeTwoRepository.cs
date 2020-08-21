using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ChallengeTwoConsole
{
    public class ChallengeTwoRepository
    {
        private readonly Queue<ChallengeTwoContent> _contentDirectory = new Queue<ChallengeTwoContent>();

        // CRUD 
        // create new claim
        public void AddContentToDirectory(ChallengeTwoContent content)
        {
            _contentDirectory.Enqueue(content);
        }
        
        // read: get all content/claims
        public Queue<ChallengeTwoContent> GetDirectory()
        {
            return _contentDirectory;
        }

        // get one customer file content by claim id
        public ChallengeTwoContent GetContentByClaimID(int claimID)
        {
            foreach (ChallengeTwoContent item in _contentDirectory)
            {
                if (item.ClaimID == claimID)
                {
                    return item;

                }
            }
            return null;
        }

        // update claim by claim id
        public bool UpdateExistingContentByClaimID(ChallengeTwoContent updateContent, int originalClaimID)
        {
            //ChallengeTwoContent content = GetContentByClaimID(originalClaimID);
            foreach ( ChallengeTwoContent item in _contentDirectory)
            {
                if (item.ClaimID.Equals(originalClaimID))
                {
                    item.ClaimID = updateContent.ClaimID;
                    item.ClaimType = updateContent.ClaimType;
                    item.Description = updateContent.Description;
                    item.ClaimAmount = updateContent.ClaimAmount;
                    item.DateOfIncident = updateContent.DateOfIncident;
                    item.DateOfClaim = updateContent.DateOfClaim;

                    return true;
                }
            }
            return false;
        }

        // delete claim // find out if this is correct Do you need to pass anything in? Marquese said no
        public void DeleteExistingContent()
        {
            _contentDirectory.Dequeue();
        }



        



    }
}
