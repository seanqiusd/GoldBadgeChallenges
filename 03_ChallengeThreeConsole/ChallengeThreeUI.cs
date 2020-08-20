using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _03_ChallengeThreeConsole
{
    public class ChallengeThreeUI
    {
        private bool _isRunning = true;
        public void Start()
        {
            //SeedContentList();
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
                "3. List all Badges" +
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
                    //method
                    break;
                case "2":
                    //method
                    break;
                case "3":
                    //method
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

        // case 1 add a badge
        private void AddBadge()
        {
            Console.Write("What is the number on the badge(use whole numbers): ");
            int badgeID = int.Parse(Console.ReadLine());


        }




        /*
         *  "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all Badges" +
         * 
         */


    }
}
