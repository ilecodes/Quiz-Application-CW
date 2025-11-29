using System;

namespace QuizApplication
{
    // Category class to represent quiz categories
    public class Category
    {
        //private attributes of Category class
        private int categoryID;
        private string categoryName;
        private string categoryDescription;
        private static int categoryCount = 1; // static counter to assign unique IDs, its initialized to 1

        // public properties to access private attributes
        public int CategoryID
        {
            get { return categoryID; }
            private set { categoryID = value; } // private set to prevent external modification
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
            // read-only property

        }
        // default constructor
        public Category() { }
        // custom constructor to initialize category attributes
        public Category(string categoryName, string categoryDescription)
        {
            this.categoryName = categoryName;
            this.categoryDescription = categoryDescription;
            this.categoryID = categoryCount++; // assign unique ID and increment counter
        }
        // method to display category details
        public void LoadCategory()
        {
            // try-catch block to handle potential exceptions and output appropriate error message
            try
            {
                // output category details to console
                Console.WriteLine($"Category ID: {categoryID}");
                Console.WriteLine($"Category Name: {categoryName}");
                Console.WriteLine($"Category Description: {categoryDescription}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading category: {ex.Message}");
            }
           
        }
        // method to update category details, passing parameters holding the new data
        public void UpdateCategory(string newName, string newDescription)
        {
            // try-catch block to handle potential exceptions and output appropriate error message
            try
            {
                // once again, only update the attributes if the corresponding parameters are not null or whitespace
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
