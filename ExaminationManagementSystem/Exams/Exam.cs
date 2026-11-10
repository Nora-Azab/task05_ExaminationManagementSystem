using ExaminationManagementSystem.Enums;
using ExaminationManagementSystem.Questions;
using System.Diagnostics;


//done  TODO VIP : clockkkkk :)                                                        
//TODO: clear consol for each question    => DisplayExamQuestions()
//TODO done تقريبا: DisplayExamQuestions => seperate the mission inside :))))
//TODO bouns: عايزة اطلع اعدل السؤال ال فوق ال أخد اجابته الكونسل

namespace ExaminationManagementSystem.Exams
{
    internal abstract class Exam
    {
        public int Id { get; set; }
        public Level Level { get; set; }
        public abstract ExamType Type { get; }
        public List<Question> Questions { get; set; } = [];
        public double FulMarkGradeExam 
        {
            get
            {
                double total = 0;
                for (int i = 0; i < Questions.Count; i++)
                {
                    total += Questions[i].Mark;
                }
                return total;


            }
        }
        protected Stopwatch Stopwatch { get; set; } = new Stopwatch();//i did it as a properity
                                                                      //-> because i will start it in this class but stop it in the child class :)
        //---------------------
        //methods:
        public virtual void DisplayExam()
        {
            this.Level = Helper.ValidateAndGetEnum<Level>("Enter The Exam Level 'words | numbers' as u like (1. easy | 2. medium | 3. hard) : ");
            this.Questions = Question.Filter(this.Questions, question => question.Level == this.Level);
            //---------------
            //clock
            Console.Clear();
            Console.WriteLine($"let's start your {this.Type} exam. you have ({this.Questions.Count}) question :)");
            Console.WriteLine("========================================");
            //Console.WriteLine("============================");
            Console.WriteLine($"Exam starts at {DateTime.Now:t}");
            this.Stopwatch.Start();
            //---------------
            /// DisplayExamQuestions   -> practical  half questions     &    final all questions :)
            ///مش حابه انادي الميثود دي هنا عشان  seperation of concern
            /// will call "DisplayExamQuestions" in the "practical" & "final" classes:)
        }
        //---------------------
        public/*Protected*/ void DisplayExamQuestions(int questionsCount)//TODO: Protected? ولا عادي عشان لو حب الدكتور يشوف الاأسءلة بردو
        /// GetExamQuestions(int? questionsCount = this.Questions?.Count)  => wrong
        /// default values for arguments must be constant :)
        /// 
        {
            int choicesCnt; int myMax=4;
            for (int i = 0; i < questionsCount; i++)
            {
                
                //Console.WriteLine("==================================");
                //Console.WriteLine($"Question {i+1} from {questionsCount}");
                Console.WriteLine("==================================");
                Console.WriteLine($"{Questions[i].Type} Question");
                Console.WriteLine("==================================");
                Console.WriteLine($"Q{i + 1})- {Questions[i].Header}\t\t\tMark: {Questions[i].Mark}");

                //-----------------
                //1- display  Q choices:
                for (int j = 0; j < Questions[i].Answer.Choices.Count; j++)
                {
                    Console.WriteLine($"{j+1}. {Questions[i].Answer.Choices[j]}");
                }
                //-----------------
                //2- display choices of each question :)
                Console.WriteLine("===============");
                choicesCnt = Questions[i].Answer.Choices.Count;
                Console.WriteLine($"choose [1:{choicesCnt}]");
                //-----------------
                //3 - take student ans &validate it:)

                if (Questions[i].Type == QuestionType.TrueFalse)
                    myMax = 2;
                do
                {
                    //هنا هيستقبل اراي عشان المالتبل اتشويز
                    Console.Write("Your Answer: ");
                    Questions[i].Answer.studentAnswersForOneQuestion = Helper.ValidateAndGetMultiChoices(Console.ReadLine(),max:myMax);
                    if (Questions[i].Answer.studentAnswersForOneQuestion.Count != 0)
                        break;
                    Console.WriteLine("invalid answer, try again:)");
                } while (true);
                //-----------------
                /// ليه مكملتش هنا الكود ال تحت ؟
                /// بصي يا نورا ... لو وقفتي لحد هنا في العرض بدون ما تشوفي كمان كل سؤال صح ولا غلط 
                /// كده معناه الطال بيمتحن والامتحان بيتعلم في نفس الوقت 
                /// انا مش مع الابروتش ده
                /// الطريقة التانية ان هنا الامتحان يتعرض الاسءلة وتدخل الاجابة 
                /// وبعدين أعدي على كل سؤال اصححه
                /// ------------
                /// اول طريقة دي .. ازاي هسمع في نتيجة الطالب لما يجاوب صح 
                /// كده هعمل داخل الكلاس بتاع الامتحان اوبجيكت من الطالب 
                /// وانا أشعر ان ده غلطططط خالص ي نور منطقيا
                /// لأن مش كل امتحان خاص بطالب معين 
                ///



                ////4- check answer:
                //Questions[i].Answer.CheckAnswer(studentAnswersForOneQuestion);
                ////no need for the return of "CheckAnswer", only call it:)
                ////عشان تسمع في نتيجة الطالب
                //Console.WriteLine("==================================");
            }
        }
    }
}
