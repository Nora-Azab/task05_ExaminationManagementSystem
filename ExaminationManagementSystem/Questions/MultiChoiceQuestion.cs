using ExaminationManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem.Questions
{
    internal class MultiChoiceQuestion : Question
    {
        public override QuestionType Type => QuestionType.MultiChoice;

        public override void DisplayQuestion()
        {
            base.DisplayQuestion();
            this.Answer.EnterChoices();
            //----------------------
            string? input;
            do
            {
                Console.Write("Enter Correct Answers (use comma as a seperator, eg: 1,3,4) : ");
                input = Console.ReadLine();
                this.Answer.CorrectChoicesIndexes = Helper.ValidateAndGetMultiChoices(input);//in this methode "Null" and "spaces" as values for "input" are handeled :)
                if (Answer.CorrectChoicesIndexes.Count != 0)
                    break;
                Console.WriteLine("invalid input for the choices, try again:)");

            } while (true);
            //foreach(var index in  this.Answer.CorrectChoicesIndexes)
            //{
            //    Console.Write($"{Answer.Choices[index]}  ");
            //}
            
        }
    }
}
