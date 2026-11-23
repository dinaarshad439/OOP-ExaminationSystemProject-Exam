using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    /// <summary>
    /// Represents a multiple-choice question that contains multiple possible answers.
    /// </summary>
    internal class McqQuestions:Question
    {
        public McqQuestions()
        {
            AnswerList = new Answer[4];
        }
    }
}
