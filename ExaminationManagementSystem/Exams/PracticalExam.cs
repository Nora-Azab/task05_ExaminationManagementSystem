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
            Console.WriteLine("=====================================");
            this.Stopwatch.Stop();
            Console.WriteLine($"Time token: {this.Stopwatch.Elapsed.Hours:D2}:{this.Stopwatch.Elapsed.Minutes:D2}:{this.Stopwatch.Elapsed.Seconds:D2}");

        }
    }
}
