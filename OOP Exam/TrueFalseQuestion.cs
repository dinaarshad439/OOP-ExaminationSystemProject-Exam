using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    /// <summary>
    /// Represents a true/false question with two possible answers.
    /// </summary>
    internal class TrueFalseQuestion:Question
    {
        public TrueFalseQuestion()
        {
            AnswerList = new Answer[]
            {
                new Answer{AnswerID=1,AnswerText="true"},
                new Answer{AnswerID=2,AnswerText="false"}

            };
        }
    }
}
