using ExaminationManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem.Exams
{
    internal class PracticalExam:Exam
    {
        public override ExamType Type => ExamType.Practical;

        public override void DisplayExam()
        {
            base.DisplayExam();
            DisplayExamQuestions(this.Questions.Count/2);//questionsCount = 1/2
        }
    }
}
