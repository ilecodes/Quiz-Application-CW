using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizApplication
{
    // Question Class represents the questions within the quiz application
    public class Question
    {
        // private attributes for the class
        private int questionID;
        private string questionText;
        private List<string> questionOptions; // list of strings made to contain the options of answers
        private string questionCorrectAnswer;
        private string questionDifficultLevel;
        private static int questionCount = 1; // static counter to assign unique IDs, its initialized to 1

        //public properties to access private attributes
        public int QuestionID
        {
            get { return questionID; }
            private set { questionID = value; } // private set to prevent external modification
        }
        
        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; }
        }
        public List<string> QuestionOptions
        {
            get { return questionOptions; }
            set { questionOptions = value; }
        }
        public string QuestionCorrectAnswer
        {
            get { return questionCorrectAnswer; }
            set { questionCorrectAnswer = value; }
        }
        public string QuestionDifficultLevel
        {
            get { return questionDifficultLevel; }
            set { questionDifficultLevel = value; }
        }
        public static int QuestionCount
        {
            get { return questionCount; } // read-only property
        }
        //default constructor
        public Question() { }
        // custom constructor to initialize Question attributes
        public Question(string qText, List<string> qOptions, string qCorrect, string qDifficulty)
        {
            this.questionText = qText;
            this.questionOptions = new List<string>(); // new list of strings initialized
            // loop through the string of options passed as a parameter
            foreach (string q in qOptions)
            {
                // each corresponding option, is added to questionsOptions list within the Question object
                questionOptions.Add(q);
            }
            this.questionCorrectAnswer = qCorrect;
            this.questionDifficultLevel = qDifficulty;
            this.questionID = questionCount++; // assign unique ID and increment counter
        }
        // method that displays the question details
        public void LoadQuestion()
        {
            // try-catch block to handle potential exceptions and output appropriate error message
            try
            {
                // output the question details to the console
                Console.WriteLine($"Question ID: {questionID}");
                Console.WriteLine($"Question Text: {questionText}");
                // because question options is a list, and i would like them to be outputted in one line, the method Join in string class is used
                // the list is compressed and each element is joined by a comma and the list is transformed into one string (one line output)
                // stored in a local variable called choices
                string choices = string.Join(",", questionOptions);
                Console.WriteLine($"Question Options: {choices}");
                Console.WriteLine($"Question Answer: {questionCorrectAnswer}");
                Console.WriteLine($"Difficulty Level: {questionDifficultLevel}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading question: {ex.Message}");

            }
        }
        // method that update the details of the question, passes parameters holding the new data
        public void UpdateQuestion(string newText, List<string> newOptions, string newAnswer, string newDifficulty)
        {
            //try-catch block to handle potential exceptions and output appropriate error message
            try
            {
                // once again, if the parameter is empty or just whitespace, the corresponding attribute does not need an update/change
                if (!string.IsNullOrWhiteSpace(newText)) { this.questionText = newText; }
                // since the new options are passed as list, a separate method is called
                // Any() method found in system Linq, calls the string method is Null or whitespace and checks if any element is empty or whitespace
                if (!newOptions.Any(s => string.IsNullOrWhiteSpace(s)))
                {
                    // the list is not empty so
                    this.questionOptions = new List<string>(); // new list is initialized to remove the old content and write new data
                    // loop through each option in the list
                    foreach (string q in newOptions)
                    {
                        // each new option is added to the question options list
                        this.questionOptions.Add(q);
                    }
                }
                if (!string.IsNullOrWhiteSpace(newAnswer)) { this.questionCorrectAnswer = newAnswer; }
                if (!string.IsNullOrWhiteSpace(newDifficulty)) { this.questionDifficultLevel = newDifficulty; }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating question: {ex.Message}");
            }

            }
        // method that checks if the answer inputted by the user is correct and returns boolean
        public bool CheckAnswer(string answer)
        {
            // try-catch block to handle potential exceptions and output appropriate error message
            try
            {
                // using the Equals() method in string class, the passed parameter is compared to the question correct answer attribute and also it ignores if the cases are different
                // returns true if they match , false if they don't
                return string.Equals(answer, questionCorrectAnswer, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking answer: {ex.Message}");
                return false; // you must return something in every path of a method to avoid error
            }
        }
    }
}
