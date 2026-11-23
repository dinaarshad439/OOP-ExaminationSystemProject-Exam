using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    /// <summary>
    /// Represents an answer option with a unique ID and answer text.
    /// </summary>
    internal class Answer
    {
        #region Property

        public int AnswerID {  get; set; }
        public string? AnswerText { get; set; }

        #endregion
    }
}
