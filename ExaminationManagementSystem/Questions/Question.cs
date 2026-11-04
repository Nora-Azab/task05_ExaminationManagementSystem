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
    }
}
