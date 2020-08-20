using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ChallengeOneConsole
{
    public class ChallengeOneContent
    {

        // Constructors
        public ChallengeOneContent() { }
        public ChallengeOneContent(int mealNum, string mealName, string mealDesc, string ingredients, decimal price)
        {
            MealNum = mealNum;
            MealName = mealName;
            MealDesc = mealDesc;
            Ingredients = ingredients;
            Price = price;
        }
        
        // POCO
        public int MealNum { get; set; }
        public string MealName { get; set; }
        public string MealDesc { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }
    }
}
