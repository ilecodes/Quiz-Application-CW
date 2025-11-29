using System;

namespace QuizApplication
{
    public class Category
    {
        private int categoryID = 1;
        private string categoryName;
        private string categoryDescription;
        private static int categoryCount = 1;

        public int CategoryID
        {
            get { return categoryID; }
            private set { categoryID = value; }
        }
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }
        public string CategoryDescription
        {
            get { return categoryDescription; }
            set { categoryDescription = value; }
        }
        public static int CategoryCount
        {
            get { return categoryCount; }
        }

        public Category() { }
        public Category(string categoryName, string categoryDescription)
        {
            this.categoryName = categoryName;
            this.categoryDescription = categoryDescription;
            this.categoryID = categoryCount++;
        }
        public void LoadCategory()
        {
            try {
                Console.WriteLine($"Category ID: {categoryID}");
                Console.WriteLine($"Category Name: {categoryName}");
                Console.WriteLine($"Category Description: {categoryDescription}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading category: {ex.Message}");
            }
           
        }
        public void UpdateCategory(string newName, string newDescription)
        {
            try {
                if (!string.IsNullOrWhiteSpace(newName)) { this.categoryName = newName; }
                if (!string.IsNullOrWhiteSpace(newDescription)) { this.categoryDescription = newDescription; }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating category: {ex.Message}");
            }

        }
    }
}
