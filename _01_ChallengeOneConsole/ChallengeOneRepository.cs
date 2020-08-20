using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _01_ChallengeOneConsole
{
    public class ChallengeOneRepository
    {
        private readonly List<ChallengeOneContent> _contentDirectory = new List<ChallengeOneContent>();

        // CRUD

        // Create
        public void AddContentToDirectory(ChallengeOneContent content)
        {
            _contentDirectory.Add(content);
        }

        // Read
        // Get all content
        public List<ChallengeOneContent> GetDirectory()
        {
            return _contentDirectory;
        }
        // Get content by meal name
        public ChallengeOneContent GetContentByMealName(string mealName)
        {
            foreach (ChallengeOneContent item in _contentDirectory)
            {
                if (item.MealName.ToLower() == mealName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }   

        // Update
        public bool UpdateExistingContent(ChallengeOneContent updateContent, string originalContent)
        {
            ChallengeOneContent content = GetContentByMealName(originalContent);
            if (content != null)
            {
                int itemIndex = _contentDirectory.IndexOf(content);
                _contentDirectory[itemIndex] = updateContent;
                return true;
            }
            return false;
        }

        // Delete
        public bool DeleteExistingContent(ChallengeOneContent content)
        {
            bool removed = _contentDirectory.Remove(content);
            return removed;
        }

        // Delete content by meal name

        public bool DeleteContentByMealName (string mealName)
        {
            ChallengeOneContent targetContent = GetContentByMealName(mealName);
            return DeleteExistingContent(targetContent);
        }


    }
}
