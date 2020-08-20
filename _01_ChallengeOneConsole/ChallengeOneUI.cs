using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ChallengeOneConsole
{
    public class ChallengeOneUI
    {

		private bool _isRunning = true;

		private readonly ChallengeOneRepository _challengeOneRepo = new ChallengeOneRepository();

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
			Console.WriteLine("Welcome to the Komodo Cafe Management System!\n" +
				"Select From The Following:\n" +
				"1. Show All Menu Items\n" +
				"2. Find Menu Item by the Meal Name\n" +
				"3. Add a New Menu Item\n" +
				"4. Update an Exisitng Menu Item by Meal Name\n" +
				"5. Remove an Existing Menu Item by Meal Name\n" +
				"6. Exit\n");
			string userInput = Console.ReadLine();
			return userInput;
		}

		private void OpenMenuItem(string userInput)
		{
			Console.Clear();
			switch (userInput)
			{
				case "1":
					ShowAllMenuItems();
					break;
				case "2":
					ShowMenuItemByMealName();
					break;
				case "3":
					CreateNewMenuItem();
					break;
				case "4":
					UpdateExistingMenuItem();
					break;
				case "5":
					RemoveMenuItemByName();
					break;
				case "6":
					_isRunning = false;
					return;
				default:
					return;
			}
			Console.WriteLine("Press a key to return to main menu...");
			Console.ReadKey();
		}

		// case 1: Show all menu items
		private void ShowAllMenuItems()
		{
			List<ChallengeOneContent> listOfMenuItems = _challengeOneRepo.GetDirectory();
			// Display content
			foreach (ChallengeOneContent content in listOfMenuItems)
			{
				ShowItems(content);
			}
		}

		private void ShowItems(ChallengeOneContent content)
		{
			Console.WriteLine($"Meal Number: {content.MealNum}\n" + 
				$"Meal Name: {content.MealName}\n" +
				$"Meal Description: {content.MealDesc}\n" + 
				$"Ingredients: {content.Ingredients}\n" + 
				$"Price: {content.Price}\n");
		}

		// case 2: show menu item by meal name
		private void ShowMenuItemByMealName()
		{
			Console.Write("Enter the meal name: ");
			string mealName = Console.ReadLine();
			ChallengeOneContent searchResult = _challengeOneRepo.GetContentByMealName(mealName);
			if (searchResult != null)
			{
				ShowItems(searchResult);
			}
			else
			{
				Console.WriteLine("Could not find anything with that meal name. Please make sure you've spelt it correctly.");
			}
		}

		// case 3: Add new menu item
		private void CreateNewMenuItem()
		{
			// Gather values for all properties for ChallengeOneContent POCOs
			Console.Write("Enter the Meal Number: ");
			int mealNum = int.Parse(Console.ReadLine());

			Console.Write("Enter the Meal Name: ");
			string mealName = Console.ReadLine();

			Console.Write("Enter a description: ");
			string mealDesc = Console.ReadLine();

			Console.Write("Enter the ingredients, separating each with a comma and space: ");
			string ingredients = Console.ReadLine();

			Console.Write("Enter the Price: $");
			decimal price = Convert.ToDecimal(Console.ReadLine());

			// Construct a ChallengeOneContent object given the above values
			ChallengeOneContent newMenuItem = new ChallengeOneContent(mealNum, mealName, mealDesc, ingredients, price);

			// Add ChallengeOneContent object to the repository ("saves" the content)
			_challengeOneRepo.AddContentToDirectory(newMenuItem);
		}

		// case 4: updating an existing menu item
		private void UpdateExistingMenuItem()
		{
			Console.Write("Enter the original meal name: ");
			string originalMealName = Console.ReadLine();
			_challengeOneRepo.GetContentByMealName(originalMealName);

			Console.Write("Enter the updated meal number, use a whole number: ");
			int mealNum = int.Parse(Console.ReadLine());

			Console.Write("Enter the updated meal name: ");
			string mealName = Console.ReadLine();

			Console.Write("Enter an updated description: ");
			string mealDesc = Console.ReadLine();

			Console.Write("Enter the ingredients, separating each with a comma and space: ");
			string ingred = Console.ReadLine();

			Console.Write("Enter an updated price: $");
			decimal price = Convert.ToDecimal(Console.ReadLine());

			// instantiate a new instance passing through the parameters established above
			ChallengeOneContent updatedMenuItem = new ChallengeOneContent(mealNum, mealName, mealDesc, ingred, price);

			_challengeOneRepo.UpdateExistingContent(updatedMenuItem, originalMealName);

			Console.Write("Menu item has been successfully updated.");
		}

		// case 5: deleting menu item by name
		private void RemoveMenuItemByName()
		{
			Console.Write("Enter the meal name: ");
			string mealName = Console.ReadLine();

			_challengeOneRepo.DeleteContentByMealName(mealName);

			Console.WriteLine("Item has been successfully deleted.");
		}

		private void SeedContentList()
		{
			ChallengeOneContent richMansMacNCheese = new ChallengeOneContent(1, "Rich Man's Mac N Cheese", "A flavorful, upscaled classic", "shard cheddar, organic shell pasta, white wine, basil", 15.99m);
			ChallengeOneContent chickenCordonBleauSandwich = new ChallengeOneContent(6, "Chicken Cordon Bleau Sandwich", "A traditional cordon bleau reimagined as a pan-seared delight", "parsley, bean sprouts, jalapeno cheese, oven roasted chicken breast, mayo, thousand island dressing, ciabatta bread", 13.99m);
			ChallengeOneContent bLTSandwich = new ChallengeOneContent(15, "BLT Sandwich", "Cannot go wrong with a classic", "bacon, lettuce, tomato, rye bread, mayo", 9.99m);

			_challengeOneRepo.AddContentToDirectory(richMansMacNCheese);
			_challengeOneRepo.AddContentToDirectory(chickenCordonBleauSandwich);
			_challengeOneRepo.AddContentToDirectory(bLTSandwich);
		}

	}
}
