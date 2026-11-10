using ExaminationManagementSystem.Enums;
using ExaminationManagementSystem.Exams;
using ExaminationManagementSystem.Modes;
using ExaminationManagementSystem.Questions;
using System.Diagnostics;

//TODO vip: doctor add question to the exam quetions are added before already :)
//TODO: exit | return to  main menu at any time
//TODO: determine time and make exam finish when time end :)  
//done  TODO remember -> if doctor Questions is empty  -> still exam not ready:)
//done  TODO: how much time student take to solve?
namespace ExaminationManagementSystem;
internal class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        int choice;
        DoctorMode? doctorMode = null;
        while (!exit)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("========== Main Menu ==========");
                Console.WriteLine("1. Doctor Mode");
                Console.WriteLine("2. Student Mode");
                Console.WriteLine("3. Exit");
                Console.Write("Enter Your Choice : ");
                if (int.TryParse(Console.ReadLine(), out choice) && (choice>=1 && choice<=3))
                    break;
                Console.WriteLine("invalid choice, try again:)");
                Console.ReadKey();
            } while (true);
            //-------------------------------
            switch (choice)
            {
                case 1:
                    {
                        Console.Clear();
                        if(doctorMode is null)
                            doctorMode = new DoctorMode();
                        /// why create instance from "DoctorMode" this time only?
                        /// i need when the doctor choose many times to add questions
                        /// -> i need to add in one list
                        /// don't need to make a new obj from "DoctorMode" and each time -> "Questions" list become empty :)
                       
                        doctorMode.Start();
                        break;
                    }
                case 2:
                    {
                        if(doctorMode is null || doctorMode.Questions.Count == 0)
                        {
                            Console.WriteLine("No Questions Yet for exam :(");
                            break;
                        }

                        StudentMode studentMode = new StudentMode();//new StudentMode because it's a new exam with new result:)
                        studentMode.Start(doctorMode.Questions);
                        break;
                    }
                case 3:
                    {
                        exit = true;
                        Console.WriteLine("good bye :)");
                        break;
                    }
                default://no need for this..بس يلا
                    {
                        Console.WriteLine("invalid choice, try again:)");
                        break;
                    }

            }
            Console.ReadKey();

        }

    }
    
}
