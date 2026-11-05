using ExaminationManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem.Questions
{
    internal class ChooseOneQuestion : Question
    {
        public override QuestionType Type => QuestionType.ChooseOne;
        public override void DisplayQuestion()
        {
            base.DisplayQuestion();
            this.Answer.EnterChoices();
            int correctAnswerIndex = Helper.ValidateNumberInRange("Enter Correct Choice Number [1-4] : ", 1,4);
            this.Answer.CorrectChoices.Add(correctAnswerIndex);//one choice only is correct :)
        }
    }
}
