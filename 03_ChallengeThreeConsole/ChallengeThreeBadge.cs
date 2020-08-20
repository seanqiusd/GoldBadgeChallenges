using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ChallengeThreeConsole
{
    public class ChallengeThreeBadge
    {
        // constructors
        public ChallengeThreeBadge() { }
        public ChallengeThreeBadge(int badgeID, List<string> listofDoorNames)
        {
            BadgeID = badgeID;
            ListOfDoorNames = listofDoorNames;
        }

        // properties 
        public int BadgeID { get; set; }
        public List<string> ListOfDoorNames { get; set; }

    }
}
