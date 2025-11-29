using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizApplication
{
    public class Question
    {
        private int questionID;
        private string questionText;
        private List<string> questionOptions;
        private string questionCorrectAnswer;
        private string questionDifficultLevel;
        private static int questionCount = 1;

        public int QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
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
            get { return questionCount; }
        }
        public Question() { }
        public Question(string qText, List<string> qOptions, string qCorrect, string qDifficulty)
        {
            this.questionText = qText;
            this.questionOptions = new List<string>();
            foreach (string q in qOptions)
            {
                questionOptions.Add(q);
            }
            this.questionCorrectAnswer = qCorrect;
            this.questionDifficultLevel = qDifficulty;
            this.questionID = questionCount++;
        }
        public void LoadQuestion()
        {
            try
            {
                Console.WriteLine($"Question ID: {questionID}");
                Console.WriteLine($"Question text: {questionText}");
                string choices = string.Join(",", questionOptions);
                Console.WriteLine($"Question options: {choices}");
                Console.WriteLine($"Question answer: {questionCorrectAnswer}");
                Console.WriteLine($"Difficulty level: {questionDifficultLevel}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading question: {ex.Message}");

            }
        }
        public void UpdateQuestion(string newText, List<string> newOptions, string newAnswer, string newDifficulty)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(newText)) { this.questionText = newText; }
                // erm?
                if (!newOptions.Any(s => string.IsNullOrWhiteSpace(s)))
                {
                    this.questionOptions = new List<string>();
                    foreach (string q in newOptions)
                    {
                        questionOptions.Add(q);
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
        public bool CheckAnswer(string answer)
        {
            try
            {
                return string.Equals(answer, questionCorrectAnswer, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking answer: {ex.Message}");
                return false;
            }
        }
    }
}
