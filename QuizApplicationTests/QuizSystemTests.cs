using QuizApplication;
using System;

namespace QuizApplicationTests
{
    [TestClass]
    public class QuizSystemTests
    {
        // constructing QuizSystem should initialize public lists 
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

                // Determine expected printed strings - look for Quiz ID in formatted output
                string matchText = $"Quiz ID: {matching.QuizID}";
                string nonMatchText = $"Quiz ID: {nonMatching.QuizID}";

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

                QuizTitle = "Test Quiz",
                QuizDescription = "Test Description",

                QuizCategory = new Category
                {
                    CategoryName = "Math"
                },

                QuizQuestions = new List<Question>
                {
                    new Question
                    {
                        QuestionText = "2 + 2 = ?",
                        QuestionOptions = new List<string> { "3", "4", "5" },
                        QuestionCorrectAnswer = "4",
                        QuestionDifficultLevel= "Hard"
                    }
                }
            };

            // User selects option 2, presses enter for next screen, then exit prompt
            Console.SetIn(new StringReader("2"));
            var output = new StringWriter();


            Console.SetOut(output);


            // Act
            quizSystem.PlayQuiz(quiz);

            // Assert
            string console = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(console);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            Assert.IsTrue(console.Contains("Correct!"), "Expected quiz to mark answer as correct.");
            Assert.IsTrue(console.Contains("4"), "Expected correct answer to be shown.");
            Assert.IsFalse(console.Contains("NOOOOO an error occurred"),
        $"Exception thrown during quiz:\n{console}");
            Assert.IsTrue(console.Contains("Quiz completed! Your score: 1/1"), "Expected score to be 1/1 for correct answer.");

        }


        // should tell student answer was incorrect when wrong answer chosen
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
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(console);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");


            Assert.IsTrue(console.Contains("Wrong!"), "Expected 'Wrong!' message.");
            Assert.IsTrue(console.Contains("Paris"), "Expected correct answer to be shown.");
            Assert.IsFalse(console.Contains("NOOOOO an error occurred"),
       $"Exception thrown during quiz:\n{console}");
            Assert.IsTrue(console.Contains("Quiz completed! Your score: 0/1"), "Expected score to be 0/1 for wrong answer.");
        }
        public class MockExitHandler : IExitHandler
        {
            public bool ExitCalled { get; private set; } = false;

            public void Exit()
            {
                ExitCalled = true; // record the call instead of killing the process
            }
        }

        // Helper method to create mock data
        private void SetupMockData(out List<Admin> admins, out List<Student> students,
                                   out List<Category> categories, out List<Quiz> quizzes)
        {
            admins = new List<Admin>
        {
            new Admin("admin1", "pass123", "admin1@test.com")
        };

            students = new List<Student>
        {
            new Student("student1", "pass456", "student1@test.com")
        };

            categories = new List<Category>
        {
            new Category("Math", "Mathematics questions"),
            new Category("Science", "Science questions")
        };

            quizzes = new List<Quiz>
        {
            new Quiz
            {

                QuizTitle = "Math Quiz",
                QuizDescription = "Basic Math",
                QuizDate = DateTime.Now,
                QuizCategory = categories[0],
                QuizQuestions = new List<Question>
                {
                    new Question
                    {

                        QuestionText = "2 + 2 = ?",
                        QuestionOptions = new List<string> { "3", "4", "5" },
                        QuestionCorrectAnswer = "4",
                        QuestionDifficultLevel = "Easy"
                    }
                }
            }
        };
        }


        // invalid error message when invalid option chosen 

        [TestMethod]
        public void StudentMenu_ShouldShowInvalidOptionMessage()
        {
            // Arrange
            var quizSystem = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Act
            // First input invalid option "9", then exit "0"
            Console.SetIn(new StringReader("9\n"));
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();

            //Console.SetOut(output);
            // We catch Environment.Exit so the test doesn't close
            
                quizSystem.StudentMenu(students, "student1", quizzes, categories, mockExit);
            

            // Assert
            string console = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(console);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            Assert.IsTrue(console.Contains("Invalid option."), "Expected invalid option message.");
            
        }
        [TestMethod]
        public void StudentMenu_TerminatesOptionMessage()
        {
            // Arrange
            var quizSystem = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);
            // Act
            // just 0 as input to GET OUT
            Console.SetIn(new StringReader("0\n"));
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();

            // Act


            quizSystem.StudentMenu(students, "student1", quizzes, categories, mockExit);



            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Goodbye!"),
                "Should display goodbye message");
            Assert.IsTrue(mockExit.ExitCalled, "Exit should be triggered");


        }
        [TestMethod]
        public void AdminMenu_TerminatesOptionMessage()
        {
            // Arrange
            var quizSystem = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);
            // Act
            // just 0 as input to GET OUT
            Console.SetIn(new StringReader("0\n"));
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();

            // Act


            quizSystem.AdminMenu(admins,"admin1", quizzes, categories,students,mockExit);



            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Goodbye!"),
                "Should display goodbye message");
            Assert.IsTrue(mockExit.ExitCalled, "Exit should be triggered");


        }
        [TestMethod]
        public void AdminMenu_ShouldDisplayManagementOptions()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            var input = new StringReader("0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act
            
            
                system.AdminMenu(admins, "admin1", quizzes, categories, students,mockExit);
            

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");
            // Assert
            Assert.IsTrue(result.Contains("1. Users"), "Should display Users option");
            Assert.IsTrue(result.Contains("2. Categories"), "Should display Categories option");
            Assert.IsTrue(result.Contains("3. Quiz Questions"), "Should display Quiz Questions option");
        }
        [TestMethod]
        public void AdminMenu_UsersOption_ShouldDisplayUserManagementMenu()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: manage users (1), then back (0), then exit (0)
            var input = new StringReader("1\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act
            
            system.AdminMenu(admins, "admin1", quizzes, categories, students,mockExit);
            

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Select an option:"), "provide the options");
            Assert.IsTrue(result.Contains("Remove Admin") || result.Contains("Add Admin"),
                "Should display user management options");
        }
        [TestMethod]
        public void AdminMenu_CategoriesOption_ShouldDisplayCategoryManagementMenu()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: categories (2), back (0), exit (0)
            var input = new StringReader("2\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act

            system.AdminMenu(admins, "admin1", quizzes, categories, students, mockExit);
            

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Select an option:"), "provide the options");
            Assert.IsTrue(result.Contains("Remove Category") || result.Contains("Add Category"),
                "Should display category management options");
        }
        [TestMethod]
        public void AdminMenu_QuizQuestionsOption_ShouldDisplayQuestionManagementMenu()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: quiz questions (3), back (0), exit (0)
            var input = new StringReader("3\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act
           
                system.AdminMenu(admins, "admin1", quizzes, categories, students,mockExit);
           

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");
            // Assert
            Assert.IsTrue(result.Contains("Select an option:"), "provide the options");
            Assert.IsTrue(result.Contains("Remove a quiz question") || result.Contains("Add a quiz question"),
                "Should display question management options");
        }

        [TestMethod]
        public void AdminMenu_WithInvalidOption_ShouldDisplayErrorMessage()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: invalid option (9), then exit (0)
            var input = new StringReader("9\n\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act
            
                system.AdminMenu(admins, "admin1", quizzes, categories, students,mockExit);
            

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");
            // Assert
            Assert.IsTrue(result.Contains("Invalid option"),
                "Should display invalid option message");
        }
        [TestMethod]
        public void AdminMenu_AddStudent_ShouldPromptForStudentInfo()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: users (1), add student (4), details, confirm (yes), back (0), exit (0)
            var input = new StringReader("1\n4\nnewstudent\npass789\nstudent@test.com\nyes\n\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act
            
                system.AdminMenu(admins, "admin1", quizzes, categories, students,mockExit);
           

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Student's Username:") && result.Contains("Student added"),
                "Should prompt for student info and confirm addition");
        }
        [TestMethod]
        public void AdminMenu_AddAdmin_ShouldPromptForAdminInfo()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: users (1), add student (4), details, confirm (yes), back (0), exit (0)
            var input = new StringReader("1\n3\nnewAdmin\npass709\nsAdmin@test.com\nyes\n\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act

            system.AdminMenu(admins, "admin1", quizzes, categories, students, mockExit);


            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Admin's Username:") && result.Contains( "Admin added"),
                "Should prompt for admin info and confirm addition");
        }
        [TestMethod]
        public void AdminMenu_RemoveAdmin_ShouldDisplayAdminList()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Add another admin so we can remove one
            admins.Add(new Admin("admin2", "pass", "admin2@test.com"));

            // Simulate: users (1), remove admin (1), go back (0), back (0), exit (0)
            var input = new StringReader("1\n1\n1\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();

            // Act
            
                system.AdminMenu(admins, "admin1", quizzes, categories, students,mockExit);
           

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Enter Admin ID to remove:") && result.Contains("Press 0 to GO BACK"),
                "Should display admin removal prompt");
            Assert.IsTrue(result.Contains("Admin removed"), "shows that admin has been removed a new list");
        }

        [TestMethod]
        public void AdminMenu_RemoveStudent_ShouldDisplayStudentList()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Add another admin so we can remove one
            students.Add(new Student("std2", "pass4", "stud2@test.com"));

            // Simulate: users (1), remove student (1), go back (0), back (0), exit (0)
            var input = new StringReader("1\n2\n2\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();

            // Act

            system.AdminMenu(admins, "admin1", quizzes, categories, students, mockExit);


            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Enter Student ID to remove:") && result.Contains("Press 0 to GO BACK"),
                "Should display admin removal prompt");
            Assert.IsTrue(result.Contains("Student removed"), "shows that student has been removed a new list");
        }
        [TestMethod]
        public void AdminMenu_EditStudent_ShouldDisplayStudentList()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: users (1), edit student (6), go back (0), back (0), exit (0)
            var input = new StringReader("1\n6\n2\nnewstudent\npass789\nstudent@test.com\n\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act
            
            system.AdminMenu(admins, "admin1", quizzes, categories, students,mockExit);
            // DEBUG: Print the actual output
           

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Enter Student ID to edit:") || result.Contains("Press 0 to GO BACK"),
                "Should display student edit prompt");
            Assert.IsTrue(result.Contains("Student updated"), "inform us that student has been changed");

        }
        [TestMethod]
        public void AdminMenu_editAdmin_ShouldDisplayAdminList()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: users (1), edit admin (5), go back (0), back (0), exit (0)
            var input = new StringReader("1\n5\n1\nnewadmin\npass789\nadmin@test.com\n\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act

            system.AdminMenu(admins, "admin1", quizzes, categories, students, mockExit);
            // DEBUG: Print the actual output


            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Enter Admin ID to edit:") || result.Contains("Press 0 to GO BACK"),
                "Should display admin edit prompt");
            Assert.IsTrue(result.Contains("Admin updated"), "inform us that admin has been changed");

        }
        [TestMethod]
        public void AdminMenu_ManageStudentStatusWell()
        {
            //Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: users (1), manage student status (7), go back (0), back (0), exit (0)
            var input = new StringReader("1\n7\n2\nactive\n\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act

            system.AdminMenu(admins, "admin1", quizzes, categories, students, mockExit);
            // DEBUG: Print the actual output


            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Enter Student ID to manage status:") || result.Contains("Press 0 to GO BACK"),
                "Should display student manage prompt");
            Assert.IsTrue(result.Contains("status updated"), "inform us that student has their status changed");

        }
        [TestMethod]
        public void AdminMenu_AddCategory_ShouldPromptForCategoryInfo()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: categories (2), add category (2), details, confirm (yes), back (0), exit (0)
            var input = new StringReader("2\n2\nHistory\nHistory questions\nyes\n\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();

            // Act
            
                system.AdminMenu(admins, "admin1", quizzes, categories, students,mockExit);
            

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");
            // Assert
            Assert.IsTrue(result.Contains("Category Name:") && result.Contains("Category added"),
                "Should prompt for category info or confirm addition");
        }
        [TestMethod]
        public void AdminMenu_RemoveCategory_ShouldPromptForCategoryID()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);
            categories.Add(new Category("History", "Historical Aspects"));
            // Simulate: categories (2), remove category (1), back (0), exit (0)
            var input = new StringReader("2\n1\n1\n0\n0\n"); 
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();

            // Act

            system.AdminMenu(admins, "admin1", quizzes, categories, students, mockExit);


            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");
            // Assert
            Assert.IsTrue(result.Contains("Enter Category ID to remove:") && result.Contains("Category removed"),
                "Should prompt for category info or confirm removal");
        }
        [TestMethod]
        public void AdminMenu_EditCategory_ShouldPromptForCategoryID() { 
            //Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: categories (2), edit category (3), details,  back (0), exit (0)
            var input = new StringReader("2\n3\n1\nCalc\nHard stats\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act

            system.AdminMenu(admins, "admin1", quizzes, categories, students, mockExit);


            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");
            // Assert
            Assert.IsTrue(result.Contains("Enter Category ID to edit:") && result.Contains("Category updated"),
                "Should prompt for category info and confirm edits");
        }
        [TestMethod]
        public void AdminMenu_RemoveQuizQuestion_ShouldRemoveSuccessfully()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            quizzes.Add(new Quiz
            {

                QuizTitle = "Math Quiz 2",
                QuizDescription = "Basic Math 2",
                QuizDate = DateTime.Now,
                QuizCategory = categories[0],
                QuizQuestions = new List<Question>
                {
                    new Question
                    {

                        QuestionText = "2 + 2 = ?",
                        QuestionOptions = new List<string> { "3", "4", "5" },
                        QuestionCorrectAnswer = "4",
                        QuestionDifficultLevel = "Easy"
                    }
                }
            });


            // Simulate input:
            //quizzes questions(3), remove quiz question(1), details,  back(0), exit(0)
            var input = new StringReader("3\n1\n1\n1\n\n0\n0\n");
            Console.SetIn(input);
            

            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act

            system.AdminMenu(admins, "admin1", quizzes, categories, students, mockExit);

            string result = output.ToString();

            // DEBUG: Print captured output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Question removed!"),
                "Should display confirmation message after removing a question");
        }
        [TestMethod]
        public void AdminMenu_AddQuizQuestion_ShouldAddSuccessfully()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            


            // Simulate input:
            //quizzes questions(3), add quiz question(2), details,  back(0), exit(0)
            var input = new StringReader("3\n2\n1\nhow long can i survive\ntoo long,too short,sure\nsure\nHard\n\n0\n0\n");
            Console.SetIn(input);


            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act

            system.AdminMenu(admins, "admin1", quizzes, categories, students, mockExit);

            string result = output.ToString();

            // DEBUG: Print captured output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Question added!"),
                "Should display confirmation message after adding a question");
        }
        [TestMethod]
        public void AdminMenu_EditQuizQuestion_ShouldEditSuccessfully()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);




            // Simulate input:
            //quizzes questions(3), edit quiz question(3), details,  back(0), exit(0)
            var input = new StringReader("3\n3\n1\n1\nhow long can i survive\ntoo long,too short,sure\nsure\nHard\n\n0\n0\n");
            Console.SetIn(input);


            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act

            system.AdminMenu(admins, "admin1", quizzes, categories, students, mockExit);

            string result = output.ToString();

            // DEBUG: Print captured output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Question updated!"),
                "Should display confirmation message after editing a question");
        }
        // when student logs in categories should be loaded  
        [TestMethod]
        public void StudentMenu_ShouldDisplayCategoriesandQuizzes()
        {
            // Arrange
            var quizSystem = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            Console.SetIn(new StringReader("1\n135\n0\n1\n\n0\n"));
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();



            quizSystem.StudentMenu(students, "student1", quizzes, categories, mockExit);


            // Assert
            string console = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(console);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(console.Contains("Available Categories:"),
                "Should display available categories");
            Assert.IsTrue(console.Contains("Available Quizzes:"),
               "Should display available quizzes");


        }
        [TestMethod]
        public void MainMenu_WithValidAdminCredentials_ShouldLoginSuccessfully()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: choose admin login (1), enter credentials, then exit admin menu (0), exit system (0)
            var input = new StringReader("1\nadmin1\npass123\n\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act
            
                system.MainMenu(admins, students, categories, quizzes,mockExit);
           

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");
            // Assert
            Assert.IsTrue(result.Contains("Welcome to the Quiz System!"),
                "Should display welcome message");
            Assert.IsTrue(result.Contains("WELCOME ADMIN") || result.Contains("Press Enter to continue"),
                "Should proceed to admin menu after successful login");
        }
        [TestMethod]
        public void MainMenu_WithInvalidAdminCredentials_ShouldPromptRetry()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: admin login (1), wrong credentials, then correct credentials, exit
            var input = new StringReader("1\nwrong\nwrong\nadmin1\npass123\n\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act
            
                system.MainMenu(admins, students, categories, quizzes,mockExit);
           

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Enter admin username:"),
                "Should prompt for admin username");
        }
        [TestMethod]
        public void MainMenu_WithValidStudentCredentials_ShouldLoginSuccessfully()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: student login (2), credentials, exit student menu (0)
            var input = new StringReader("2\nstudent1\npass456\n\n0\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();
            // Act
            
                system.MainMenu(admins, students, categories, quizzes,mockExit);
           

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("WELCOME STUDENT"),
                "Should display student welcome message");
        }
        [TestMethod]
        public void MainMenu_WithExitOption_ShouldExitSystem()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            var input = new StringReader("0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();

            // Act & Assert
           
                system.MainMenu(admins, students, categories, quizzes,mockExit);
            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            Assert.IsTrue(mockExit.ExitCalled, "Exit should be triggered");

        }
        [TestMethod]
        public void MainMenu_WithInvalidOption_ShouldPromptRetry()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: invalid option (9), then exit (0)
            var input = new StringReader("9\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();

            // Act
            
                system.MainMenu(admins, students, categories, quizzes,mockExit);
           

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");
            // Assert
            Assert.IsTrue(result.Contains("Invalid option"),
                "Should display invalid option message");
        }


        [TestMethod]
        public void StudentMenu_WithInvalidCategoryId_ShouldPromptRetry()
        {
            // Arrange
            var system = new QuizSystem();
            SetupMockData(out var admins, out var students, out var categories, out var quizzes);

            // Simulate: play quiz (1), invalid category (999), valid category (1), quiz (1), answer, exit
            var input = new StringReader("1\n999\n149\n15\n1\n\n0\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var mockExit = new MockExitHandler();

            // Act
            
            
                system.StudentMenu(students, "student1", quizzes, categories, mockExit);
            
            

            string result = output.ToString();
            // DEBUG: Print the actual output
            System.Diagnostics.Debug.WriteLine("=== ACTUAL OUTPUT ===");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("=== END OUTPUT ===");

            // Assert
            Assert.IsTrue(result.Contains("Invalid Category ID"),
                "Should display invalid category message");
        }



    }
}
