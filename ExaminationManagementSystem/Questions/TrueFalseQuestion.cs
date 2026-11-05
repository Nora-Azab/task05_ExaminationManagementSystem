using ExaminationManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem.Questions
{
    internal class TrueFalseQuestion:Question
    {
        public override QuestionType Type
        {
            get
            {
                return QuestionType.TrueFalse;
            }

        }

        public override void DisplayQuestion()
        {
            base.DisplayQuestion();
            //-----
            //EnterChoices
            this.Answer.Choices.Add("True");
            this.Answer.Choices.Add("False");
            //-----
            int correctAnswerIndex = Helper.ValidateNumberInRange("Enter Correct Answer (1. True | 2. False) : ", 1, 2);
            this.Answer.CorrectChoicesIndexes.Add(correctAnswerIndex);



        }
    }
}
