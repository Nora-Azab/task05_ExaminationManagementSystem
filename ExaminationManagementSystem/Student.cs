using ExaminationManagementSystem.Exams;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ExamGrade { get; set; } = 0; //"double" -> because exam marks "double"
        public Exam Exam { get; set; }
        //-------------------------
        public void CheckExamAnswers()
        {
            for (int i = 0; i < Exam.Questions.Count; i++)
            {
                if (Exam.Questions[i].Answer.CheckAnswer(Exam.Questions[i].Answer.studentAnswersForOneQuestion))
                    this.ExamGrade += Exam.Questions[i].Mark;
            }
            Console.WriteLine("==================================");
        }



    }
}
