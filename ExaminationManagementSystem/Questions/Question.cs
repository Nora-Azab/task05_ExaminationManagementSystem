using ExaminationManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem.Questions
{
    internal class Question
    {
        public int Id { get; set; }//TODO: Guid?
        public string Header { get; set; }
        public int Mark { get; set; }
        public QuestionType Type { get; set; }//TODO: must be abstract to determine hte type at first?
        public Level Level { get; set; }
        public Answer Answer { get; set; }
        //-----------------------
        public virtual void DisplayQuestion()
        {
            //level:
            string message = "Enter Number [1:3] For Question Level (1. easy | 2. medium | 3. hard) : ";
            int number;
            do
            {
                number = Helper.ValidateInputNumber(message);
                if (number > 0 && number <= 3)//must be [1:3]
                    break;
                Console.WriteLine("invaild input, num must be [1:3] only :) ");

            } while (true);
            this.Level = (Level)number;//انا ضمنت من فوق انه جاي رقم من 1 ل 3 فقط
            Console.WriteLine($"you chose {Level} level :)");
            //------------
            //header:
            //------------
            //mark:
        }
        
    }
}
