using ExaminationManagementSystem.Enums;
using ExaminationManagementSystem.Exams;
using ExaminationManagementSystem.Questions;


//TODO: display the Q + thier correct answers:)  red , green
namespace ExaminationManagementSystem.Modes
{
    internal class StudentMode
    {
        public Student Student { get; set; }
        public StudentMode()
        {
            this.Student = new Student();
            //this.Student.Exam.Questions = questions;//assign exam Questions       with    doctor  Questions :)
            /// المكان غلط تماما لأنه لسه تحت هيشاور على نيو اوبجيكت اوف 
            /// from exam -> based on student choice
            /// and the Quections of the new exam will be empty
            /// 
            Student.Name = Helper.ValidateStringInput("Enter Your Name: ");
        }
        //-----------------------------
        public void Start(List<Question> questions)//ask doctor Questions:)
        {

            //1- determine exam type

            ExamType examType  = Helper.ValidateAndGetEnum<ExamType>("Choose Exam Type 'numbers | words' (1.Practical , 2.Final) : ");
            //--------------------------
            //2- create exam obj :)
            switch(examType)
            {
                case ExamType.Practical:
                {
                        /// هتعامل عموما من خلال :
                        /// i will deal with student -> exam .. not a new obj from exam class (but the exam of that student obj which i created it above) :)
                        /// 

                        Student.Exam = new PracticalExam();
                        break;
                }
                case ExamType.Final:
                {
                        Student.Exam = new FinalExam(); 
                        break;
                }
            }
            //--------------------------
            //3- assign exam Questions       with    doctor  Questions :)  =>   after determine the exam type the student will choose :)
            this.Student.Exam.Questions = questions;
            //--------------------------
            //4- display exam (display exam questions + take student answers)
            Console.WriteLine($"let's start your {Student.Exam.Type} exam. you have ({questions.Count}) question :)");
            Console.WriteLine("========================================");
            Student.Exam.DisplayExam();//polymorphism happened:)
            //--------------------------
            //5- check answers
            Student.CheckExamAnswers();
            //--------------------------
            //6- get exam grade
            Console.WriteLine($"{Student.Name} Result : {Student.ExamGrade} / {Student.Exam.FulMarkGradeExam}");
            Console.WriteLine($"Good Luck ya {Student.Name} :)");




        }
    }
}
