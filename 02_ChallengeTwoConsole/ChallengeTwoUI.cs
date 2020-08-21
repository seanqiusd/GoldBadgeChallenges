using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ChallengeTwoConsole
{
    public class ChallengeTwoUI
    {
        private bool _isRunning = true;
        private readonly ChallengeTwoRepository _challengeTwoRepo = new ChallengeTwoRepository();

        public void Start()
        {
            SeedContentList();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("Welcome Komodo Claims Management System.\n" +
                "Select from the following:\n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n" +
                "4. Modify an exisitng claim\n" +
                "5. Exit\n");
            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    ShowAllClaims();
                    break;
                case "2":
                    TakeCareOfNextClaim();
                    break;
                case "3":
                    EnterNewClaim();
                    break;
                case "4":
                    UpdateExistingClaim();
                    break;
                case "5":
                    _isRunning = false;
                    return;
                default:
                    return;
            }
            Console.WriteLine("Press a key to return to main menu...");
            Console.ReadKey();
        }

     
        // case 1: 
        private void ShowAllClaims()
        {
            Queue<ChallengeTwoContent> queOfClaims = _challengeTwoRepo.GetDirectory();
            foreach (ChallengeTwoContent content in queOfClaims)
            {
                ShowClaims(content);
            }
        }

        private void ShowClaims(ChallengeTwoContent content)
        {
            Console.WriteLine($"Claim ID: {content.ClaimID}\n" +
                $"Type: {content.ClaimType}\n" +
                $"Description: {content.Description}\n" +
                $"Amount: {content.ClaimAmount}\n" +
                $"DateOfIccident: {content.DateOfIncident}\n" +
                $"DateOfClaim: {content.DateOfClaim}\n" +
                $"IsValid: {content.IsValid}\n");
        }

        // case 2: take care of next claim
        private void TakeCareOfNextClaim()
        {
            ShowAllClaims();
            Console.Write("Do you want to take care of the next item?(y/n): ");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                _challengeTwoRepo.DeleteExistingContent();
                Console.WriteLine("Deleted");
            }

        }

        // case 3: enter a new claim
        private void EnterNewClaim()
        {
            Console.Write("Enter the claim id (only whole numbers): ");
            int claimID = int.Parse(Console.ReadLine());

            ClaimType claimType = GetClaimType();

            Console.Write("Enter a claim description: ");
            string description = Console.ReadLine();

            Console.Write("Amount of Damage: $");
            decimal claimAmount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Date of Incident (mm/dd/yyyy): ");
            DateTime dateofIncident = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of claim (mm/dd/yyyy): ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());
            

            ChallengeTwoContent newClaim = new ChallengeTwoContent(claimID, claimType, description, claimAmount, dateofIncident, dateOfClaim);

            _challengeTwoRepo.AddContentToDirectory(newClaim);
        }

        // case 4: modify an existing claim
        private void UpdateExistingClaim()
        {
            Console.Write("Enter the original claim number(use only whole numbers): ");
            int originalClaimNumber = int.Parse(Console.ReadLine());
            _challengeTwoRepo.GetContentByClaimID(originalClaimNumber);

            Console.Write("Enter the updated claim id (if same, enter that again; only whole numbers): ");
            int claimNumber = int.Parse(Console.ReadLine());

            ClaimType claimType = GetClaimType();

            Console.Write("Enter the udpated claim description: ");
            string description = Console.ReadLine();

            Console.Write("Enter the updated Amount of Damage: $"); // look into if commas and no decimals breaks code
            decimal claimAmount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter the updated Date of Incident (mm/dd/yyyy): ");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter the updated Date of Claim: ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            ChallengeTwoContent updatedClaim = new ChallengeTwoContent(claimNumber, claimType, description, claimAmount, dateOfIncident, dateOfClaim);

            _challengeTwoRepo.UpdateExistingContentByClaimID(updatedClaim, originalClaimNumber);

            Console.Write("Claim has been successfully updated.");

        }


        private void SeedContentList()
        {
            ChallengeTwoContent firstClaim = new ChallengeTwoContent(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));

            ChallengeTwoContent secondClaim = new ChallengeTwoContent(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));

            ChallengeTwoContent thirdClaim = new ChallengeTwoContent(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));

            _challengeTwoRepo.AddContentToDirectory(firstClaim);
            _challengeTwoRepo.AddContentToDirectory(secondClaim);
            _challengeTwoRepo.AddContentToDirectory(thirdClaim);

        }

        private ClaimType GetClaimType()
        {
            Console.WriteLine("Enter the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            while (true)
            {
                string claimTypeString = Console.ReadLine();
                bool parseResult = int.TryParse(claimTypeString, out int parsedNumber);
                if (parseResult && parsedNumber >= 1 && parsedNumber < 4)
                {
                    ClaimType claimType = (ClaimType)parsedNumber - 1;
                    return claimType;
                }
                Console.WriteLine("Not a valid selection. Please try again.");
            }
            
        }

    }
}
