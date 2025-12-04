using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApplication;
using System;

namespace QuizApplicationTests
{
    [TestClass]
    public class QuizTests
    {
        // Default constructor should create instance
        [TestMethod]
        public void DefaultConstructor_ShouldCreateQuizInstance()
        {
            var quiz = new Quiz();
            Assert.IsNotNull(quiz);
        }
        
        // Custom constructor should initialize properties
        [TestMethod]
        public void CustomConstructor_ShouldSetPropertiesCorrectly()
        {
            var category = new Category("Math", "Math related quizzes");
            var questions = new List<Question>
        {
            new Question("Q1", new List<string>{"A","B"}, "A", "Easy"),
            new Question("Q2", new List<string>{"X","Y"}, "X", "Medium")
        };

            var quiz = new Quiz("QuizTitle", "QuizDesc", category, questions);

            Assert.AreEqual("QuizTitle", quiz.QuizTitle);
            Assert.AreEqual("QuizDesc", quiz.QuizDescription);
            Assert.AreEqual(category, quiz.QuizCategory);
            CollectionAssert.AreEqual(questions, quiz.QuizQuestions);
            Assert.IsTrue(quiz.QuizID > 0);
            Assert.IsTrue((DateTime.Now - quiz.QuizDate).TotalSeconds < 5); // quiz date is recent
        }

        // Quiz IDs are umique 
        [TestMethod]
        public void QuizCount_ShouldIncrementWithEachNewQuiz()
        {
            var category = new Category("Cat1", "Desc1");
            var q1 = new Quiz("Quiz1", "Desc1", category, new List<Question>());
            var q2 = new Quiz("Quiz2", "Desc2", category, new List<Question>());

            Assert.AreEqual(q1.QuizID + 1, q2.QuizID);

            Assert.IsTrue(Quiz.QuizCount >= q2.QuizID, "Static counter should be >= last quiz ID");
        }

        // questions should be added 
        [TestMethod]
        public void AddQuestion_ShouldAddQuestionToQuiz()
        {
            var quiz = new Quiz();

            quiz.QuizQuestions = new List<Question>();

            var question = new Question("Sample Q", new List<string> { "A", "B" }, "A", "Easy");

            // Add the question
            quiz.AddQuestion(question);

            Assert.AreEqual(1, quiz.QuizQuestions.Count);
            Assert.AreEqual(question, quiz.QuizQuestions[0]);
        }

        // Question should be removed 
        [TestMethod]
        public void RemoveQuestion_ShouldRemoveQuestionFromQuiz()
        {
            var question = new Question("Q", new List<string> { "A" }, "A", "Easy");
            var quiz = new Quiz();
            quiz.QuizQuestions = new List<Question> { question };

            quiz.RemoveQuestion(question.QuestionID);

            Assert.IsFalse(quiz.QuizQuestions.Contains(question));
        }

        // Chnages should appear 
        [TestMethod]
        public void UpdateQuizQuestions_ShouldUpdateTargetQuestion()
        {
            var question = new Question("OldQ", new List<string> { "A", "B" }, "A", "Easy");
            var quiz = new Quiz();
            quiz.QuizQuestions = new List<Question> { question };

            var newOptions = new List<string> { "X", "Y" };
            quiz.updateQuizQuestions(question.QuestionID, "NewQ", newOptions, "Y", "Hard");

            Assert.AreEqual("NewQ", question.QuestionText);
            CollectionAssert.AreEqual(newOptions, question.QuestionOptions);
            Assert.AreEqual("Y", question.QuestionCorrectAnswer);
            Assert.AreEqual("Hard", question.QuestionDifficultLevel);
        }

        // LoadQuiz should not throw exceptions
        [TestMethod]
        public void LoadQuiz_ShouldNotThrowException()
        {
            var quiz = new Quiz();
            quiz.QuizCategory = new Category("Test", "Desc");

            try
            {
                quiz.LoadQuiz();
            }
            catch
            {
                Assert.Fail("LoadQuiz() should not throw exceptions.");
            }
        }

        // LoadQuizqs should not throw exceptions
        [TestMethod]
        public void LoadQuizQs_ShouldNotThrowException()
        {
            var question = new Question("Q", new List<string> { "A" }, "A", "Easy");
            var quiz = new Quiz();
            quiz.QuizQuestions = new List<Question> { question };

            try
            {
                quiz.LoadQuizQs();
            }
            catch
            {
                Assert.Fail("LoadQuizQs() should not throw exceptions.");
            }
        }
    }
}
