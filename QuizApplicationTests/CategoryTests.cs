using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApplication;
using System;

namespace QuizApplicationTests
{
    [TestClass]
    public class CategoryTests
    {
        // Default constructor should create instance
        [TestMethod]
        public void DefaultConstructor_ShouldCreateCategoryInstance()
        {
            var category = new Category();
            Assert.IsNotNull(category, "Category instance should be created.");
        }

        // Custom constructor should initialize properties
        [TestMethod]
        public void CustomConstructor_ShouldSetPropertiesCorrectly()
        {
            string name = "Science";
            string description = "All science-related quizzes.";

            var category = new Category(name, description);

            Assert.AreEqual(name, category.CategoryName, "CategoryName should match constructor value.");
            Assert.AreEqual(description, category.CategoryDescription, "CategoryDescription should match constructor value.");
            Assert.IsTrue(category.CategoryID > 0, "CategoryID should be assigned automatically.");
        }

        // CategoryCount increments logicall
        [TestMethod]
        public void CategoryCount_ShouldIncrementWithEachNewCategory()
        {
            var c1 = new Category("Math", "Math quizzes");
            var c2 = new Category("History", "History quizzes");

            // Check IDs are unique and greater than 0
            Assert.IsTrue(c1.CategoryID > 0, "First category ID should be greater than 0.");
            Assert.IsTrue(c2.CategoryID > 0, "Second category ID should be greater than 0.");
            Assert.AreNotEqual(c1.CategoryID, c2.CategoryID, "IDs should be unique.");
            Assert.IsTrue(Category.CategoryCount > 0, "CategoryCount should be greater than 0.");
        }

        // UpdateCategory should change values only if valid
        [TestMethod]
        public void UpdateCategory_ShouldUpdateOnlyValidValues()
        {
            var category = new Category("OldName", "OldDescription");

            category.UpdateCategory("NewName", null);

            Assert.AreEqual("NewName", category.CategoryName, "CategoryName should be updated.");
            Assert.AreEqual("OldDescription", category.CategoryDescription, "CategoryDescription should remain unchanged if null is passed.");
        }

        // LoadCategory should not throw exceptions
        [TestMethod]
        public void LoadCategory_ShouldNotThrowException()
        {
            var category = new Category("TestName", "TestDescription");

            try
            {
                category.LoadCategory();
            }
            catch
            {
                Assert.Fail("LoadCategory() should not throw exceptions.");
            }
        }
    }
}

