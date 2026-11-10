using ExaminationManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem.Exams
{
    internal class FinalExam:Exam
    {
        public override ExamType Type => ExamType.Final;

        public override void DisplayExam()
        {
            base.DisplayExam();
            DisplayExamQuestions(this.Questions.Count);//questionsCount = all 

        }
    }
}
