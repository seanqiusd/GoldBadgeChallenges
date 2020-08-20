using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ChallengeTwoConsole
{
    public class ChallengeTwoContent
    {
        // Constructors
        public ChallengeTwoContent() { }
        public ChallengeTwoContent(int claimID, ClaimType claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        // POCO
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; } // Make sure to instruct user to enter as dd/mm//yyyy or reverse
        public DateTime DateOfClaim { get; set; }
   
        public bool IsValid
        {
            get
            {
                TimeSpan timeFrame = DateOfClaim - DateOfIncident;
             
               
                //double totalTimeFrameInDays = timeFrame.TotalDays;
                //int daysTimeFrame = Convert.ToInt32(totalTimeFrameInDays);
                //int daysTimeFrame = Convert.ToInt32(Math.Floor(totalTimeFrameInDays));
                if (timeFrame.TotalDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }


    }

    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }
}
