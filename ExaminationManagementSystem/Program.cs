using ExaminationManagementSystem.Enums;
using ExaminationManagementSystem.Exams;
using ExaminationManagementSystem.Modes;
using ExaminationManagementSystem.Questions;
using System.Diagnostics;


//TODO: exit | return to  main menu at any time
namespace ExaminationManagementSystem;
internal class Program
{
    static void Main(string[] args)
    {
        DoctorMode d = new DoctorMode();
        d.Start();
        //d.Questions;
        //Exam ex = new Exam();
        //ex.DisplayExam();

        //TODO remember -> if doctor Questions is empty  -> still exam not ready:)

        StudentMode studentMode = new StudentMode();
        studentMode.Start(d.Questions);


    }
    //=======================================================
    //methods:
    
}
