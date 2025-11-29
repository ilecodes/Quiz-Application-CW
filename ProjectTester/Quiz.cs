using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTester
{
    public class Quiz
    {
        private int quizID;
        private string quizTitle;
        private string quizDescription;
        private Category quizCategory;
        private DateTime quizDate;
        private static int quizCount = 1;
        private List<Question> quizQuestions;

        public List<Question> QuizQuestions
        {
            get { return quizQuestions; }
            set { quizQuestions= value; }
        }
        public int QuizID
        {
            get { return quizID; }
            private set { quizID = value; }
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
            get { return quizCount; }
        }
        public Quiz() { }
        public Quiz(string qTitle,string qDesc, Category qCategory,List<Question> QuizQs) {
            this.quizTitle = qTitle;
            this.quizDescription = qDesc;
            this.quizCategory = qCategory;
            this.quizID = quizCount++;
            this.quizQuestions = new List<Question>();
            foreach (Question questions in QuizQs)
            {
                this.quizQuestions.Add(questions);
            }
            this.quizDate = DateTime.Now;

        }
        //public void CreateQuizQuestions()
        //{
        //    quizQuestions.Add(new Questions());

        //}
        public void LoadQuiz () {
            Console.WriteLine($"Quiz ID: {quizID}");
            Console.WriteLine($"Quiz Title: {quizTitle}");
            Console.WriteLine($"Quiz Description: {quizDescription}");
            string cName = quizCategory.CategoryName;
            Console.WriteLine($"Quiz Category: {cName}");
            Console.WriteLine($"Quiz Date: {quizDate}");
        }
        public void LoadQuizQs()
        {
            foreach(Question quizQ in quizQuestions)
            {
                quizQ.LoadQuestion();
                Console.WriteLine();
            }
        }
        public void AddQuestion(Question question)
        {
            quizQuestions.Add(question);
        }
        public void RemoveQuestion(int questionId)
        {
            quizQuestions.RemoveAll(q => q.QuestionID == questionId);
        }
        
        public void updateQuizQuestions(int questionId,string questionText, List<string> newOptions, string newAnswer, string newDifficulty)
        {
            foreach(Question q in quizQuestions)
            {
                if (q.QuestionID == questionId)
                {
                    q.UpdateQuestion(questionText,newOptions,newAnswer,newDifficulty);
                    break;
                }
            }
        }
    }
}
