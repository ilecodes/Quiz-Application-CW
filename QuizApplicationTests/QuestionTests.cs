using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApplication;
using System;

namespace QuizApplicationTests
{
    [TestClass]
    public class QuestionTests
    {
        //Default constructor should create a instance
        [TestMethod]
        public void DefaultConstructor_ShouldCreateQuestionInstance()
        {
            var question = new Question();
            Assert.IsNotNull(question, "Question instance should be created.");
        }

        // Custom constructor sets fields correctly
        [TestMethod]
        public void CustomConstructor_ShouldSetPropertiesCorrectly()
        {
            var options = new List<string> { "A", "B", "C" };
            string text = "What is 2+2?";
            string correct = "A";
            string difficulty = "Easy";

            var question = new Question(text, options, correct, difficulty);

            Assert.AreEqual(text, question.QuestionText);
            CollectionAssert.AreEqual(options, question.QuestionOptions);
            Assert.AreEqual(correct, question.QuestionCorrectAnswer);
            Assert.AreEqual(difficulty, question.QuestionDifficultLevel);
            Assert.IsTrue(question.QuestionID > 0, "QuestionID should be assigned automatically.");
        }

        // QuestionCount increments correctly
        [TestMethod]
        public void QuestionCount_ShouldIncrementWithEachNewQuestion()
        {
            var q1 = new Question("Q1", new List<string> { "A" }, "A", "Easy");
            var q2 = new Question("Q2", new List<string> { "B" }, "B", "Medium");

            Assert.IsTrue(q1.QuestionID > 0, "First question ID should be greater than 0.");
            Assert.IsTrue(q2.QuestionID > 0, "Second question ID should be greater than 0.");
            Assert.AreNotEqual(q1.QuestionID, q2.QuestionID, "IDs should be unique.");

            Assert.IsTrue(Question.QuestionCount > 0, "QuestionCount should be greater than 0.");
        }


        // UpdateQuestion updates fields correctly
        [TestMethod]
        public void UpdateQuestion_ShouldUpdatePropertiesCorrectly()
        {
            var options = new List<string> { "A", "B" };
            var question = new Question("OldText", options, "A", "Easy");

            var newOptions = new List<string> { "X", "Y", "Z" };
            question.UpdateQuestion("NewText", newOptions, "Y", "Hard");

            Assert.AreEqual("NewText", question.QuestionText);
            CollectionAssert.AreEqual(newOptions, question.QuestionOptions);
            Assert.AreEqual("Y", question.QuestionCorrectAnswer);
            Assert.AreEqual("Hard", question.QuestionDifficultLevel);
        }

        // UpdateQuestion ignores empty inputs
        [TestMethod]
        public void UpdateQuestion_ShouldIgnoreEmptyInputs()
        {
            var options = new List<string> { "A", "B" };
            var question = new Question("OldText", options, "A", "Easy");

            question.UpdateQuestion("", new List<string> { " " }, "", "  ");

            // Original values should remain
            Assert.AreEqual("OldText", question.QuestionText);
            CollectionAssert.AreEqual(options, question.QuestionOptions);
            Assert.AreEqual("A", question.QuestionCorrectAnswer);
            Assert.AreEqual("Easy", question.QuestionDifficultLevel);
        }

        // CheckAnswer returns true for correct answer 
        [TestMethod]
        public void CheckAnswer_ShouldReturnTrueForCorrectAnswer()
        {
            var question = new Question("Q", new List<string> { "A" }, "Answer", "Easy");
            Assert.IsTrue(question.CheckAnswer("Answer"));
            Assert.IsTrue(question.CheckAnswer("answer"));
        }

        // CheckAnswer returns false for incorrect answer
        [TestMethod]
        public void CheckAnswer_ShouldReturnFalseForIncorrectAnswer()
        {
            var question = new Question("Q", new List<string> { "A" }, "Answer", "Easy");
            Assert.IsFalse(question.CheckAnswer("WrongAnswer"));
        }

        //  LoadQuestion should not throw exception
        [TestMethod]
        public void LoadQuestion_ShouldNotThrowException()
        {
            var question = new Question("Q", new List<string> { "A", "B" }, "A", "Easy");

            try
            {
                question.LoadQuestion();
            }
            catch
            {
                Assert.Fail("LoadQuestion() should not throw exceptions.");
            }
        }
    }
}
