using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OOP_Exam
{
    /// <summary>
    /// Represents a final exam that supports both MCQ and true/false questions
    /// and displays the student's answers and final grade.
    /// </summary>
    internal class FinalExam : Exam
    {
        #region Constructor
        public FinalExam(TimeSpan _timeExam, int _numberOfQuestions) : base(_timeExam, _numberOfQuestions) { }
        #endregion

        #region Method

        /// <summary>
        /// Displays the Final exam, allows the student to answer the questions,
        /// and shows the correct answers and final grade after completion.
        /// </summary>
        /// <param name="quest">The array of questions included in the practical exam.</param>
        public override void ExamFunctionality(Question[] quest)
        {
            char decision;
            bool valid = false;
            do
            {
                Console.WriteLine("Do you want to start Exam ( Y | N ):");
                valid = char.TryParse(Console.ReadLine(), out decision);

            } while (!valid || (decision != 'Y' && decision != 'y'
                 && decision != 'N' && decision != 'n'));

            Console.Clear();

            if (decision == 'Y' || decision == 'y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                Console.WriteLine("Final Exam\n");
                Answer[] userAnswer = new Answer[NumberOfQuestions];


                for (int j = 0; j < NumberOfQuestions; j++)
                {
                    userAnswer[j] = new Answer();
                    Console.WriteLine($"Question {j + 1}: {quest[j].Body}");
                    Console.WriteLine($" Question    Mark {quest[j].Mark}");

                    for (int i = 0; i < quest[j].AnswerList.Length; i++)
                    {   
                        
                        Console.WriteLine($"{i + 1}- {quest[j].AnswerList[i].AnswerText}");
                    }

                    int num = userAnswer[j].AnswerID;

                    do
                    {
                        Console.WriteLine("\nEnter your answer ID:");

                        valid = int.TryParse(Console.ReadLine(), out num);

                    } while (!valid || num < 1 ||
                     num > quest[j].AnswerList.Length);

                    userAnswer[j].AnswerID = num;


                }
                sw.Stop();
                Console.Clear();
                FinalExamResult(userAnswer, quest, sw);
            }
            else 
            {
                return;
            }
            

        }

        /// <summary>
        /// Calculates and displays the student's results, including their answers,
        /// the correct answers, the total grade, and the elapsed exam time.
        /// </summary>
        /// <param name="userAnswer">The answers submitted by the student.</param>
        /// <param name="quest">The questions included in the practical exam.</param>
        /// <param name="sw">The stopwatch used to measure the time taken to complete the exam.</param>
        public void FinalExamResult(Answer[] userAnswer, Question[] quest, Stopwatch sw)
        {
            Console.WriteLine("Final Exam Results:");
            
            int TotalMarks = 0;

            int Grade = 0;

            for (int i = 0; i < NumberOfQuestions; i++)
            {

                Console.WriteLine($"\nQuestion{i + 1}: {quest[i].Body}");
                Console.WriteLine($"Your answer ID: {quest[i].AnswerList[userAnswer[i].AnswerID-1].AnswerText}");
                Console.WriteLine($"Correct answer is: {quest[i].AnswerList[quest[i].CorrectAnswerID - 1].AnswerText} ");

                TotalMarks += quest[i].Mark;

                if (userAnswer[i].AnswerID == quest[i].CorrectAnswerID)
                {

                    Grade += quest[i].Mark;

                }


            }

            Console.WriteLine($"\nYour Grade is {Grade} out of {TotalMarks}");
            Console.WriteLine($"Time= {sw.Elapsed}");
            Console.WriteLine("Thank You!");
        }

        #endregion
    }
}

