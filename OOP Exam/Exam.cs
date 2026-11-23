using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    /// <summary>
    /// Provides the base functionality and common properties for different exam types.
    /// </summary>
    internal abstract class Exam
    {
        #region fields
        private TimeSpan timeExam;
        #endregion

        #region Property
        public TimeSpan TimeExam 
        {  
            get { return timeExam; }

            set
            {
                if(value.TotalMinutes>=30 && value.TotalMinutes <= 180)
                {
                    timeExam = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Exam Time");
                }
            }
        
        }

        public int NumberOfQuestions { get; set; }

        #endregion

        #region Constructor
        public Exam(TimeSpan _timeExam,int _numberOfQuestions) 
        {
            TimeExam = _timeExam;
            NumberOfQuestions = _numberOfQuestions;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Displays the exam and handles the exam-taking process.
        /// </summary>
        /// <param name="quest">The array of questions included in the exam.</param>
        public abstract void ExamFunctionality(Question[] quest);

        #endregion

    }
}
