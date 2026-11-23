using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    /// <summary>
    /// Represents a question in an exam, including its header, body, mark,
    /// available answers, and correct answer ID.
    /// </summary>
    internal class Question
    {
        #region Property
        public string Header {  get; set; }
        public  string Body {  get; set; }
        public  int Mark {  get; set; }

        public Answer[] AnswerList { get; set; }

        public int CorrectAnswerID { get; set; }

        #endregion



    }
}
