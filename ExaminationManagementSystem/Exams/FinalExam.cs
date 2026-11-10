using ExaminationManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine("=====================================");
            this.Stopwatch.Stop();
            Console.WriteLine($"Time token: {this.Stopwatch.Elapsed.Hours:D2}:{this.Stopwatch.Elapsed.Minutes:D2}:{this.Stopwatch.Elapsed.Seconds:D2}");

        }
    }
}
