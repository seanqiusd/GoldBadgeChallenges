using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _03_ChallengeThreeConsole
{
    public class ChallengeThreeUI
    {
        private bool _isRunning = true;
        private readonly ChallengeThreeRepository _challengeThreeRepo = new ChallengeThreeRepository();
        public void Start()
        {
            SeedContentData();
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
            Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all Badges\n" +
                "4. Exit");
            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    AddBadge();
                    break;
                case "2":
                    UpdateExistingBadge();
                    break;
                case "3":
                    DisplayAllBadges();
                    break;
                case "4":
                    _isRunning = false;
                    break;
                default:
                    return;
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }


        // case 1: add a badge
        private void AddBadge()
        {
            Console.Write("What is the number on the badge(use whole numbers): ");
            int badgeID = int.Parse(Console.ReadLine());

            Console.Write("List a door that it needs access to(use an Uppercase letter followed by a whole number; no space between): ");
            string firstDoor = Console.ReadLine();
            List<string> listDoor = new List<string>();
            listDoor.Add(firstDoor);
            bool addDoor = true;
            while (addDoor)
            {
                Console.Write("Any other doors(y/n): ");
                string userAnswerTwo = Console.ReadLine();
                if (userAnswerTwo == "y")
                {
                    Console.Write("List a door that it needs access to(use an Uppercase letter followed by a whole number; no space between): ");
                    string addDoorInput = Console.ReadLine();
                    listDoor.Add(addDoorInput);
                }
                else if(userAnswerTwo == "n")
                {
                    addDoor = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            _challengeThreeRepo.AddBadgeToDictionary(badgeID, listDoor);


        }


        // case 2: edit a badge
        private void UpdateExistingBadge()
        {
            Console.Write("What is the badge number to update(enter a whole number): ");
            int badgeID = int.Parse(Console.ReadLine());
            DisplayDoorsByID(badgeID);
            //_challengeThreeRepo.GetBadgeByID(badgeID);
            Console.Write("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n" +
                "3. Remove all doors from badge");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.Write("Which door would you like to remove: ");
                    string doorInput = Console.ReadLine();
                    _challengeThreeRepo.RemoveADoor(badgeID, doorInput);
                    break;
                case "2":
                    Console.Write("Which door would like to add: ");
                    string doorInputAnother = Console.ReadLine();
                    _challengeThreeRepo.AddADoor(badgeID, doorInputAnother);
                    break;
                case "3":
                    Console.WriteLine("What is the badge id you wish to remove all doors from: ");
                    int id = int.Parse(Console.ReadLine());
                    _challengeThreeRepo.DeleteBadgeByID(id);
                    break;
                default:
                    return;
            }

        }


        private void DisplayDoorsByID(int badgeID)
        {
            Console.WriteLine($"Badge ID: {badgeID}");
            List<string> doorsAccessed = _challengeThreeRepo.GetDoorAccessViaBadgeID(badgeID);
            foreach (var item in doorsAccessed)
            {
                Console.WriteLine("Doors Accessed: " + item);
            }
        }

        // case 3: list all badges
        private void DisplayAllBadges()
        {
            _challengeThreeRepo.GetBadgesFromDictionary();

        }


        /*
         *    public ChallengeThreeBadge GetBadgeByID(int id)
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
         * 
         */
        // seeded data
        private void SeedContentData()
        {
            List<string> badgeOneDoors = new List<string> { "A7" };
            List<string> badgeTwoDoors = new List<string> { "A1", "A4", "B1", "B2" };
            List<string> badgeThreeDoors = new List<string> { "A4", "A5" };

            _challengeThreeRepo.AddBadgeToDictionary(12345, badgeOneDoors);
            _challengeThreeRepo.AddBadgeToDictionary(22345, badgeTwoDoors);
            _challengeThreeRepo.AddBadgeToDictionary(32345, badgeThreeDoors);
        }

        



    }
}
