using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    /// <summary>
    /// Represents a subject that contains its information and is responsible
    /// for creating and assigning an exam.
    /// </summary>
    internal class Subject
    {
        #region Property
        public int SubjectID { get; set; }
        public string? SubjectName { get; set; }

        public Exam? subject { get; set; }

        #endregion


        #region Methods

        /// <summary>
        /// Creates an exam based on the selected exam type and user input.
        /// </summary>
        public void ExamCreation(int Option, TimeSpan time, int numQuestion)
        {


            if (Option == 1)
            {
                Question[] q = new Question[numQuestion];

                for (int i = 0; i < numQuestion; i++)
                {
                    q[i] = CreateMCQQuestion(i + 1);
                }

                subject = new PracticalExam(time, numQuestion);
                Console.Clear();
                subject.ExamFunctionality(q);


            }

            else if (Option == 2)
            {
                Question[] q = new Question[numQuestion];


                for (int i = 0; i < numQuestion; i++)
                {
                    int option;
                    bool valid;

                    do
                    {
                        Console.WriteLine($"Enter details for Question {i + 1}");
                        Console.WriteLine("1 for MCQ, 2 for True & False");

                        valid = int.TryParse(Console.ReadLine(), out option);

                    } while (!valid || (option != 1 && option != 2));

                    if (option == 1)
                    {
                        q[i] = CreateMCQQuestion(i + 1);
                    }
                    else
                    {
                        q[i] = CreateTrueFalseQuestion(i + 1);
                    }
                }

                subject = new FinalExam(time, numQuestion);
                Console.Clear();
                subject.ExamFunctionality(q);
            }

        }



        /// <summary>
        /// Creates and returns a multiple-choice question with its answers
        /// and correct answer ID.
        /// </summary>
        public McqQuestions CreateMCQQuestion(int questionNumber)
        {
            McqQuestions q = new McqQuestions();

            q.Header = $"Enter the body of Question {questionNumber}:";
            Console.WriteLine(q.Header);

            q.Body = Console.ReadLine();

            int mark;
            bool valid;

            do
            {
                Console.WriteLine("Enter Question mark:");
                valid = int.TryParse(Console.ReadLine(), out mark);

            } while (!valid || mark <= 0);

            q.Mark = mark;

           

            Console.WriteLine("Choices of Question:");

            for (int j = 0; j < q.AnswerList.Length; j++)
            {
                q.AnswerList[j] = new Answer()
                {
                    AnswerID = j + 1
                };

                Console.WriteLine($"Enter choice number {j + 1}:");
                q.AnswerList[j].AnswerText = Console.ReadLine();
            }

            int correctID;
            do
            {
                Console.WriteLine("Enter ID of correct answer (1 to 4):");

                valid = int.TryParse(Console.ReadLine(), out correctID);

            } while (!valid || correctID < 1 || correctID > 4);

            q.CorrectAnswerID = correctID;

            return q;
        }

        /// <summary>
        /// Creates and returns a true/false question with its correct answer ID.
        /// </summary>
        public TrueFalseQuestion CreateTrueFalseQuestion(int Qnum)
        {
            TrueFalseQuestion q = new TrueFalseQuestion();

            q.Header = $"Enter the body of Question {Qnum}:";
            Console.WriteLine(q.Header);

            q.Body = Console.ReadLine();

            int mark;
            bool valid;

            do
            {
                Console.WriteLine("Enter Question mark:");
                valid = int.TryParse(Console.ReadLine(), out mark);

            } while (!valid || mark <= 0);

            q.Mark = mark;

          

            int correctID;

            do
            {
                Console.WriteLine("Enter ID of correct answer (1 for True, 2 for False):");

                valid = int.TryParse(Console.ReadLine(), out correctID);

            } while (!valid || correctID < 1 || correctID > 2);

            q.CorrectAnswerID = correctID;

            return q;
        }

        #endregion
    }
}
