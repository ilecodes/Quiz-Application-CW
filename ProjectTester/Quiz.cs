using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    // Quiz class represents a quiz in the quiz application, with a collection of questions
    public class Quiz
    {
        // private attributes of Quiz class
        private int quizID;
        private string quizTitle;
        private string quizDescription;
        private Category quizCategory; // references the Category class
        private DateTime quizDate;
        private static int quizCount = 1; // static counter to assign unique quiz IDs
        private List<Question> quizQuestions; // list to hold questions in the quiz, referencing Question class

        // public properties to access private attributes
        public List<Question> QuizQuestions
        {
            get { return quizQuestions; }
            set { quizQuestions= value; }
        }
        public int QuizID
        {
            get { return quizID; }
            private set { quizID = value; } // private set to prevent external modification
        }
        public string QuizTitle
        {
            get { return quizTitle; }
            set { quizTitle = value; }
        }
        public string QuizDescription
        {
            get { return quizDescription; }
            set { quizDescription = value; }
        }
        public Category QuizCategory
        {
            get { return quizCategory; }
            set { quizCategory = value; }
        }
        
        public DateTime QuizDate
        {
            get { return quizDate; }
            set { quizDate = value; }
        }
        public static int QuizCount
        {
            get { return quizCount; } // read-only property
        }
        // default constructor
        public Quiz() {
            this.quizID = quizCount++;
            this.quizQuestions = new List<Question>();
            this.quizDate = DateTime.Now;
        }
        // custom constructor to initialize quiz attributes
        public Quiz(string qTitle,string qDesc, Category qCategory,List<Question> QuizQs) {
            this.quizTitle = qTitle;
            this.quizDescription = qDesc;
            this.quizCategory = qCategory; 
            this.quizID = quizCount++; // assign unique ID and increment counter
            this.quizQuestions = new List<Question>(); // initialize the list of questions objects
            // loop through the passed list of questions and add them to the quizQuestions list
            foreach (Question questions in QuizQs)
            {
                // add each question to the quizQuestions list, by appending it
                this.quizQuestions.Add(questions);
            }
            this.quizDate = DateTime.Now;

        }
        // method to display quiz details
        public void LoadQuiz()
        {
            // try-catch block to handle potential exceptions and output appropriate error message
            try
            {
                // output quiz details to console
                Console.WriteLine($"Quiz ID: {quizID}");
                Console.WriteLine($"Quiz Title: {quizTitle}");
                Console.WriteLine($"Quiz Description: {quizDescription}");
                // get category name from the Category object, thats the only info we need here
                string cName = quizCategory.CategoryName;
                Console.WriteLine($"Quiz Category: {cName}");
                Console.WriteLine($"Quiz Date: {quizDate}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading quiz: {ex.Message}");
            }
        }
        // method to display all questions in the quiz
        public void LoadQuizQs()
        {
            // try-catch block to handle potential exceptions and output appropriate error message
            try
            {
                // loop through each question in the quizQuestions list 
                foreach (Question quizQ in quizQuestions)
                {
                    // call LoadQuestion method of Question class to display question details
                    quizQ.LoadQuestion();
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading quiz questions: {ex.Message}");
            }
        }
        // method to add a question to the quiz
        public void AddQuestion(Question question)
        {
            // try-catch block to handle potential exceptions and output appropriate error message
            try
            {
                // add the passed question object to the quizQuestions list, this method is already part of system linq
                quizQuestions.Add(question);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding question to the quiz: {ex.Message}");
            }
           
        }
        // method to remove a question from the quiz , question ID is passed as parameter to know which question to remove
        public void RemoveQuestion(int questionId)
        {
            // try-catch block to handle potential exceptions and output appropriate error message
            try
            {
                // remove the question with the matching questionId from the quizQuestions list, using the method from system linq
                quizQuestions.RemoveAll(q => q.QuestionID == questionId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing question from the quiz: {ex.Message}");
            }
        }
        // method to update a question in the quiz, question ID is passed to identify which question to update, and all its new details
        public void updateQuizQuestions(int questionId, string questionText, List<string> newOptions, string newAnswer, string newDifficulty)
        {
            // try-catch block to handle potential exceptions and output appropriate error message
            try
            {
                // Loop through each questions in QuizQuestions list
                foreach (Question q in quizQuestions)
                {
                    // We are looking for the question with the matching Question ID passed
                    if (q.QuestionID == questionId)
                    {
                        // once question is found, the UpdateQuestion method is called carrying the parameters holding the new data
                        q.UpdateQuestion(questionText, newOptions, newAnswer, newDifficulty);
                        break; // we break since there is only one question, no need to look further
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating the question in the quiz: {ex.Message}");
            }
        }
    }
}
