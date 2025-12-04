using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApplication;
using System;
using System.Collections.Generic;
using System.IO;

namespace QuizApplicationTests
{
    [TestClass]
    public class QuizSystemTests
    {
        // onstructing QuizSystem should initialize public lists 
        [TestMethod]
        public void Constructor_ShouldInitializeEmptyLists()
        {
            var system = new QuizSystem();

            Assert.IsNotNull(system.admins, "admins list should be initialized.");
            Assert.IsNotNull(system.students, "students list should be initialized.");
            Assert.IsNotNull(system.categories, "categories list should be initialized.");
            Assert.IsNotNull(system.quizzes, "quizzes list should be initialized.");

            Assert.AreEqual(0, system.admins.Count, "admins list should start empty.");
            Assert.AreEqual(0, system.students.Count, "students list should start empty.");
            Assert.AreEqual(0, system.categories.Count, "categories list should start empty.");
            Assert.AreEqual(0, system.quizzes.Count, "quizzes list should start empty.");
        }

        // CreateAdmins should add the expected admin entries and set role to "admin"
        [TestMethod]
        public void CreateAdmins_ShouldPopulateFourAdmins_WithAdminRole()
        {
            var system = new QuizSystem();
            var admins = new List<Admin>();

            system.CreateAdmins(admins);

            Assert.AreEqual(4, admins.Count, "CreateAdmins should add 4 admins.");

            // spot check values and that role is set to admin
            Assert.AreEqual("Fatima", admins[0].UserName, "First admin username should be 'Fatima'.");
            Assert.AreEqual("admin", admins[0].UserRole, "Admin UserRole should be 'admin'.");
            Assert.AreEqual("James", admins[1].UserName);
            Assert.AreEqual("Sophie", admins[2].UserName);
            Assert.AreEqual("Liam", admins[3].UserName);
        }

        // createStudents should add the expected student entries and set role to "student"
        [TestMethod]
        public void CreateStudents_ShouldPopulateFiveStudents_WithStudentRole()
        {
            var system = new QuizSystem();
            var students = new List<Student>();

            system.CreateStudents(students);

            Assert.AreEqual(5, students.Count, "CreateStudents should add 5 students.");

            // spot check values and that role is set to student
            Assert.IsTrue(students.Exists(s => s.UserName == "Leanne"), "Should contain student 'Leanne'.");
            Assert.IsTrue(students.Exists(s => s.UserName == "Guest"), "Should contain student 'Guest'.");
            // ensure role is student for at least one
            Assert.AreEqual("student", students[0].UserRole, "Student UserRole should be 'student'.");
        }

        // CreateCategories should add the expected categories n set names/descriptions
        [TestMethod]
        public void CreateCategories_ShouldPopulateExpectedCategories()
        {
            var system = new QuizSystem();
            var categories = new List<Category>();

            system.CreateCategories(categories);

            Assert.AreEqual(7, categories.Count, "CreateCategories should add 7 categories.");

            // check first and a couple others for correctness
            Assert.AreEqual("Programming Concepts", categories[0].CategoryName);
            Assert.IsTrue(categories[0].CategoryDescription.Contains("object-oriented"), "First category description should mention concepts.");
            Assert.AreEqual("Web Development", categories[3].CategoryName);
            Assert.AreEqual("Computer Networks", categories[6].CategoryName);
        }

        // loadAdmins should write admin header and admin details to console
        [TestMethod]
        public void LoadAdmins_ShouldWriteAdminHeaderAndDetailsToConsole()
        {
            // Arrange
            var system = new QuizSystem();
            var admins = new List<Admin>();
            system.CreateAdmins(admins);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); 

                // Act
                system.LoadAdmins(admins);

                // Assert
                string output = sw.ToString();

                StringAssert.Contains(output, "ADMINS");
                StringAssert.Contains(output, "Fatima");
                StringAssert.Contains(output, "James");
                StringAssert.Contains(output, "Sophie");
                StringAssert.Contains(output, "Liam");
            }
        }

        // Methods should not throw when passed initialized lists
        [TestMethod]
        public void CreateAndLoadMethods_ShouldNotThrow_WhenCalledWithLists()
        {
            var system = new QuizSystem();

            var admins = new List<Admin>();
            var students = new List<Student>();
            var categories = new List<Category>();
            var quizzes = new List<Quiz>();

            try
            {
                system.CreateAdmins(admins);
                system.CreateStudents(students);
                system.CreateCategories(categories);
                
            }
            catch (Exception ex)
            {
                Assert.Fail("Create methods threw an unexpected exception: " + ex);
            }
        }

        // 7CreateAdmins/CreateStudents/CreateCategories together populate respective lists
        [TestMethod]
        public void CreateAllEntities_ShouldPopulateAllLists()
        {
            var system = new QuizSystem();

            system.CreateAdmins(system.admins);
            system.CreateStudents(system.students);
            system.CreateCategories(system.categories);

            Assert.AreEqual(4, system.admins.Count, "system.admins should contain 4 entries after CreateAdmins.");
            Assert.AreEqual(5, system.students.Count, "system.students should contain 5 entries after CreateStudents.");
            Assert.AreEqual(7, system.categories.Count, "system.categories should contain 7 entries after CreateCategories.");
        }

        // Helper, prepare system with categories
        private QuizSystem PrepareSystemWithCategories()
        {
            var system = new QuizSystem();
            system.CreateCategories(system.categories); 
            return system;
        }

        // CreateQuizzes should populate list with 14 quizzes
        [TestMethod]
        public void CreateQuizzes_ShouldPopulateExpectedNumberOfQuizzes()
        {
            var system = PrepareSystemWithCategories();
            var quizzes = new List<Quiz>();

            system.CreateQuizzes(quizzes);

            Assert.IsNotNull(quizzes);
            Assert.AreEqual(14, quizzes.Count, "CreateQuizzes should add 14 quizzes.");
        }

        // First quiz should have correct title, category, and questions
        [TestMethod]
        public void FirstQuiz_ShouldHaveCorrectTitleCategoryAndQuestions()
        {
            var system = PrepareSystemWithCategories();
            var quizzes = new List<Quiz>();

            system.CreateQuizzes(quizzes);

            var first = quizzes[0];

            Assert.AreEqual("OOP fundamentals", first.QuizTitle);
            Assert.IsNotNull(first.QuizCategory);
            Assert.AreSame(system.categories[0], first.QuizCategory);

            Assert.IsNotNull(first.QuizQuestions);
            Assert.IsTrue(first.QuizQuestions.Count >= 1);
        }

        // All quizzes should contain valid questions and correct answers must appear in options
        [TestMethod]
        public void AllQuizzes_ShouldContainValidQuestions_AndCorrectAnswers()
        {
            var system = PrepareSystemWithCategories();
            var quizzes = new List<Quiz>();

            system.CreateQuizzes(quizzes);

            foreach (var quiz in quizzes)
            {
                Assert.IsNotNull(quiz.QuizQuestions);
                Assert.IsTrue(quiz.QuizQuestions.Count >= 1, $"Quiz '{quiz.QuizTitle}' must contain at least one question.");

                foreach (var q in quiz.QuizQuestions)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(q.QuestionText));
                    Assert.IsNotNull(q.QuestionOptions);
                    Assert.IsTrue(q.QuestionOptions.Count >= 1);

                    CollectionAssert.Contains(
                        q.QuestionOptions,
                        q.QuestionCorrectAnswer,
                        $"Correct answer must appear in options for question '{q.QuestionText}'."
                    );
                }
            }
        }

        // CreateQuizzes should set a recent date (within 10 seconds)
        [TestMethod]
        public void CreatedQuizzes_ShouldHaveRecentQuizDates()
        {
            var system = PrepareSystemWithCategories();
            var quizzes = new List<Quiz>();

            system.CreateQuizzes(quizzes);

            Assert.IsTrue((DateTime.Now - quizzes[0].QuizDate).TotalSeconds < 10);
            Assert.IsTrue((DateTime.Now - quizzes[quizzes.Count - 1].QuizDate).TotalSeconds < 10);
        }

        // CreateQuizzes should not throw when categories exist
        [TestMethod]
        public void CreateQuizzes_ShouldNotThrow_WhenCategoriesAreValid()
        {
            var system = PrepareSystemWithCategories();
            var quizzes = new List<Quiz>();

            try
            {
                system.CreateQuizzes(quizzes);
            }
            catch (Exception ex)
            {
                Assert.Fail("CreateQuizzes threw unexpected exception: " + ex);
            }
        }

        // Remove category quiz
        [TestMethod]
        public void RemoveCategory_ShouldRemoveCategory_AndAssociatedQuizzes()
        {
            // Arrange
            var system = new QuizSystem();
            system.CreateCategories(system.categories);
            system.CreateQuizzes(system.quizzes);

            int targetCategoryId = system.categories[0].CategoryID;
            int quizzesBefore = system.quizzes.Count;

            // Act
            system.RemoveCategory(system.categories, targetCategoryId, system.quizzes);

            // Assert
            Assert.IsFalse(system.categories.Exists(c => c.CategoryID == targetCategoryId),
                "Category should be removed.");

            Assert.IsFalse(system.quizzes.Exists(q => q.QuizCategory.CategoryID == targetCategoryId),
                "All quizzes for that category must be removed.");

            Assert.IsTrue(system.quizzes.Count < quizzesBefore,
                "Quiz count must decrease after category removal.");
        }

        // Nothing happens  if cate does not exist
        [TestMethod]
        public void RemoveCategory_ShouldDoNothing_WhenCategoryNotFound()
        {
            var system = new QuizSystem();
            system.CreateCategories(system.categories);
            system.CreateQuizzes(system.quizzes);

            int originalCategoryCount = system.categories.Count;
            int originalQuizCount = system.quizzes.Count;

            system.RemoveCategory(system.categories, 9999, system.quizzes);

            Assert.AreEqual(originalCategoryCount, system.categories.Count);
            Assert.AreEqual(originalQuizCount, system.quizzes.Count);
        }

        // Should remove correct student 
        [TestMethod]
        public void RemoveStudent_ShouldRemoveCorrectStudent()
        {
            var system = new QuizSystem();
            system.CreateStudents(system.students);

            int idToRemove = system.students[0].UserId;

            system.RemoveStudent(system.students, idToRemove);

            Assert.IsFalse(system.students.Exists(s => s.UserId == idToRemove));
        }

        // does not remove if Id does not exist 
        [TestMethod]
        public void RemoveStudent_ShouldNotRemove_WhenIdNotFound()
        {
            var system = new QuizSystem();
            system.CreateStudents(system.students);

            int before = system.students.Count;

            system.RemoveStudent(system.students, -1);

            Assert.AreEqual(before, system.students.Count);
        }

        // Should remove correct admin 
        [TestMethod]
        public void RemoveAdmin_ShouldRemoveCorrectAdmin()
        {
            var system = new QuizSystem();
            system.CreateAdmins(system.admins);

            int idToRemove = system.admins[1].UserId;

            system.RemoveAdmin(system.admins, idToRemove);

            Assert.IsFalse(system.admins.Exists(a => a.UserId == idToRemove));
        }

        // does not remove if Id does not exist 
        [TestMethod]
        public void RemoveAdmin_ShouldNotRemove_WhenIdDoesNotExist()
        {
            var system = new QuizSystem();
            system.CreateAdmins(system.admins);

            int before = system.admins.Count;

            system.RemoveAdmin(system.admins, -50);

            Assert.AreEqual(before, system.admins.Count);
        }

        // Save quiz to CSV file
        [TestMethod]
        public void SaveQuizToCSV_ShouldCreateCSV_WithCorrectHeadersAndContent()
        {
            var system = new QuizSystem();
            system.CreateCategories(system.categories);
            system.CreateQuizzes(system.quizzes);

            string tempPath = Path.Combine(Path.GetTempPath(), "quiz_export_" + Guid.NewGuid() + ".csv");

            system.SaveQuiztoCSV(system.quizzes, tempPath);

            Assert.IsTrue(File.Exists(tempPath), "CSV file must be created.");

            string csv = File.ReadAllText(tempPath);

            // Basic header checks
            StringAssert.Contains(csv, "Quiz ID");
            StringAssert.Contains(csv, "Question ID");
            StringAssert.Contains(csv, "Correct Answer");

            // Ensure at least one quiz entry exists
            var firstQuiz = system.quizzes[0];
            StringAssert.Contains(csv, firstQuiz.QuizID.ToString());

            File.Delete(tempPath);
        }

        // Load individual quizes for associated cate 
        [TestMethod]
        public void LoadQuizForCategory_ShouldPrintOnlyQuizzesFromSelectedCategory()
        {
            // Arrange
            var system = new QuizSystem();
            system.CreateCategories(system.categories);
            system.CreateQuizzes(system.quizzes);

            Assert.IsTrue(system.categories.Count >= 2, "Need at least 2 categories.");
            Assert.IsTrue(system.quizzes.Count >= 2, "Need at least 2 quizzes.");

            int targetCategoryId = system.categories[0].CategoryID;

            var matching = system.quizzes
                .FirstOrDefault(q => q.QuizCategory != null &&
                                     q.QuizCategory.CategoryID == targetCategoryId);
            Assert.IsNotNull(matching, "No quiz found in the target category.");

            var nonMatching = system.quizzes
                .FirstOrDefault(q => q.QuizCategory != null &&
                                     q.QuizCategory.CategoryID != targetCategoryId);
            Assert.IsNotNull(nonMatching, "No quiz found in another category.");

            // Capture output
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                system.LoadQuizforCategory(system.quizzes, targetCategoryId);

                string output = sw.ToString();

                // Determine expected printed strings
                string matchText = string.IsNullOrWhiteSpace(matching.QuizTitle)
                    ? matching.QuizID.ToString()
                    : matching.QuizTitle;

                string nonMatchText = string.IsNullOrWhiteSpace(nonMatching.QuizTitle)
                    ? nonMatching.QuizID.ToString()
                    : nonMatching.QuizTitle;

                // Assert
                Assert.IsTrue(output.Contains(matchText),
                    $"Expected output to contain quiz '{matchText}'. Output:\n{output}");

                Assert.IsFalse(output.Contains(nonMatchText),
                    $"Did not expect output to contain quiz '{nonMatchText}'. Output:\n{output}");
            }
        }
        
        // Load students 
        [TestMethod]
        public void LoadStudents_ShouldOutputAllStudentNames()
        {
            var system = new QuizSystem();
            system.CreateStudents(system.students);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                system.LoadStudents(system.students);

                string output = sw.ToString();

                foreach (var s in system.students)
                    StringAssert.Contains(output, s.UserName);
            }
        }

        // Load categories names
        [TestMethod]
        public void LoadCategories_ShouldOutputAllCategoryNames()
        {
            var system = new QuizSystem();
            system.CreateCategories(system.categories);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                system.LoadCategories(system.categories);

                string output = sw.ToString();

                foreach (var c in system.categories)
                    StringAssert.Contains(output, c.CategoryName);
            }
        }

        // VerifyAdminLogin valid credentials returns true
        [TestMethod]
        public void VerifyAdminLogin_ReturnsTrue_ForValidCredentials()
        {
            var system = new QuizSystem();
            var admins = new List<Admin>
            {
                new Admin { UserName = "admin1", UserPassword = "pass1" },
                new Admin { UserName = "admin2", UserPassword = "pass2" }
            };

            bool result = system.VerifyAdminLogin(admins, "admin1", "pass1");

            Assert.IsTrue(result, "Expected VerifyAdminLogin to return true for valid credentials.");
        }

        // VerifyAdminLogin invalid credentials returns false
        [TestMethod]
        public void VerifyAdminLogin_ReturnsFalse_ForInvalidCredentials()
        {
            var system = new QuizSystem();
            var admins = new List<Admin>
            {
                new Admin { UserName = "adminA", UserPassword = "pwA" }
            };

            bool result = system.VerifyAdminLogin(admins, "wrongUser", "wrongPw");

            Assert.IsFalse(result, "Expected VerifyAdminLogin to return false for invalid credentials.");
        }

        // VerifyAdminLogin null admin list returns false
        [TestMethod]
        public void VerifyAdminLogin_ReturnsFalse_WhenAdminsListIsNull()
        {
            var system = new QuizSystem();
            List<Admin> admins = null;

            bool result = system.VerifyAdminLogin(admins, "any", "any");

            Assert.IsFalse(result, "Expected VerifyAdminLogin to return false when admins list is null.");
        }

        // VerifyStudentLogin valid credentials returns true
        [TestMethod]
        public void VerifyStudentLogin_ReturnsTrue_ForValidCredentials()
        {
            var system = new QuizSystem();
            var students = new List<Student>
            {
                new Student { UserName = "stu1", UserPassword = "s1" },
                new Student { UserName = "stu2", UserPassword = "s2" }
            };

            bool result = system.VerifyStudentLogin(students, "stu2", "s2");

            Assert.IsTrue(result, "Expected VerifyStudentLogin to return true for valid credentials.");
        }

        // VerifyStudentLogin invalid credentials returns false
        [TestMethod]
        public void VerifyStudentLogin_ReturnsFalse_ForInvalidCredentials()
        {
            var system = new QuizSystem();
            var students = new List<Student>
            {
                new Student { UserName = "sA", UserPassword = "pA" }
            };

            bool result = system.VerifyStudentLogin(students, "unknown", "badpw");

            Assert.IsFalse(result, "Expected VerifyStudentLogin to return false for invalid credentials.");
        }

        // VerifyStudentLogin null student list returns false
        [TestMethod]
        public void VerifyStudentLogin_ReturnsFalse_WhenStudentsListIsNull()
        {
            var system = new QuizSystem();
            List<Student> students = null;

            bool result = system.VerifyStudentLogin(students, "any", "any");

            Assert.IsFalse(result, "Expected VerifyStudentLogin to return false when students list is null.");
        }

        [TestMethod]
        public void PlayQuiz_ShouldIncreaseScore_OnCorrectAnswers()
        {
            // Arrange
            var quizSystem = new QuizSystem();
            var quiz = new Quiz
            {
                QuizQuestions = new List<Question>
                {
                    new Question
                    {
                        QuestionText = "2 + 2 = ?",
                        QuestionOptions = new List<string> { "3", "4", "5" },
                        QuestionCorrectAnswer = "4"
                    }
                }
            };

            // User selects option 2, presses enter for next screen, then exit prompt
            var input = new StringReader("2\n\n");
            var output = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(output);

            // Act
            quizSystem.PlayQuiz(quiz);

            // Assert
            string console = output.ToString();

            Assert.IsTrue(console.Contains("Correct!"), "Expected quiz to mark answer as correct.");
            Assert.IsTrue(console.Contains("Your score: 1/1"), "Expected score to be 1/1.");
        }

        // should tell student answer was incorrect when wrong aswer chosen
        [TestMethod]
        public void PlayQuiz_ShouldShowWrongMessage_OnIncorrectAnswer()
        {
            // Arrange
            var quizSystem = new QuizSystem();
            var quiz = new Quiz
            {
                QuizQuestions = new List<Question>
                {
                    new Question
                    {
                        QuestionText = "Capital of France?",
                        QuestionOptions = new List<string> { "Berlin", "Paris", "Rome" },
                        QuestionCorrectAnswer = "Paris"
                    }
                }
            };

            // User selects option 1 (wrong), press enter twice
            Console.SetIn(new StringReader("1\n\n"));
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            quizSystem.PlayQuiz(quiz);

            // Assert
            string console = output.ToString();

            Assert.IsTrue(console.Contains("Wrong!"), "Expected 'Wrong!' message.");
            Assert.IsTrue(console.Contains("Paris"), "Expected correct answer to be shown.");
        }

        // invalid error message when invalid option chosen 
        [TestMethod]
        public void StudentMenu_ShouldShowInvalidOptionMessage()
        {
            // Arrange
            var quizSystem = new QuizSystem();
            var students = new List<Student>();
            var quizzes = new List<Quiz>();
            var categories = new List<Category>();
            string username = "testUser";

            // First input invalid option "9", then exit "0"
            Console.SetIn(new StringReader("9\n0\n"));
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            // We  catch Environment.Exit so the test doesn't close
            try
            {
                quizSystem.StudentMenu(students, username, quizzes, categories);
            }
            catch { }

            // Assert
            string console = output.ToString();

            Assert.IsTrue(console.Contains("Invalid option"), "Expected invalid option message.");
        }

        // when student logs in categories should be loaded  
        [TestMethod]
        public void StudentMenu_ShouldDisplayCategories()
        {
            // Arrange
            var quizSystem = new QuizSystem();
            var students = new List<Student>();
            var quizzes = new List<Quiz>();
            var categories = new List<Category>
            {
                new Category { CategoryID = 1, CategoryName = "Math" },
                new Category { CategoryID = 2, CategoryName = "Science" }
            };
            string username = "testUser";

            Console.SetIn(new StringReader("1\n1\n0\n"));
            var output = new StringWriter();
            Console.SetOut(output);

            try
            {
                quizSystem.StudentMenu(students, username, quizzes, categories);
            }
            catch { }

            // Assert
            string console = output.ToString();

            Assert.IsTrue(console.Contains("Math"));
            Assert.IsTrue(console.Contains("Science"));
        }

        [TestMethod]
        public void StudentMenu_ShouldShowQuizzesForCategory()
        {
            // Arrange
            var quizSystem = new QuizSystem();

            var cat = new Category { CategoryID = 1, CategoryName = "Programming" };

            var quizzes = new List<Quiz>
    {
        new Quiz { QuizID = 10, QuizTitle = "Basics", QuizCategory = cat },
        new Quiz { QuizID = 20, QuizTitle = "Advanced", QuizCategory = cat }
    };

            var categories = new List<Category> { cat };
            var students = new List<Student>();
            string username = "stud";

            Console.SetIn(new StringReader("1\n1\n10\n\n0\n"));
            var output = new StringWriter();
            Console.SetOut(output);

            try
            {
                quizSystem.StudentMenu(students, username, quizzes, categories);
            }
            catch { }

            // Assert
            string console = output.ToString();

            Assert.IsTrue(console.Contains("Basics"));
            Assert.IsTrue(console.Contains("Advanced"));
        }

    }
}
