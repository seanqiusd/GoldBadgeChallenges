using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ChallengeThreeConsole
{
   
    public class ChallengeThreeRepository
    {
        private readonly ChallengeThreeBadge _badge = new ChallengeThreeBadge();
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        // CRUD
        // create 
        public void AddBadgeToDictionary(ChallengeThreeBadge item)
        {
            _badgeDictionary.Add(item.BadgeID, item.ListOfDoorNames);
        }

        // read
        public Dictionary<int, List<string>> GetBadgesFromDictionary()
        {
            return _badgeDictionary;
        }

        // read: get badge by badge id
        public ChallengeThreeBadge GetBadgeByID(int id)
        {
            for (int i = 0; i < _badgeDictionary.Count; i++) // use Elementat() to retrive key-value pair using index (i)
            {
                var item = _badgeDictionary.ElementAt(i);
                if (item.Key == id)
                {
                    ChallengeThreeBadge badge = new ChallengeThreeBadge(item.Key, item.Value);
                    return badge;
                }
            }
            return null;
        }

        // update a badge
        public void UpdateABadge(string oldDoorName, string newDoorName, int badgeID)
        {
            ChallengeThreeBadge badge = GetBadgeByID(badgeID);
            List<string> listOfDoors = badge.ListOfDoorNames;
            foreach (string item in listOfDoors)
            {
                if (item == oldDoorName)
                {
                    oldDoorName = newDoorName; // oldDoorName is a list of strings so can set like with like
                }
            }
        }

        // delete badge
        public void DeleteBadge(ChallengeThreeBadge badge)
        {
            _badgeDictionary.Remove(badge.BadgeID);
        }

        // delete by badge by id
        public void DeleteBadgeByID(int badgeID)
        {
            ChallengeThreeBadge targetBadgeID = GetBadgeByID(badgeID);
            DeleteBadge(targetBadgeID);
        }
    }
}
