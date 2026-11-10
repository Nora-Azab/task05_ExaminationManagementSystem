using ExaminationManagementSystem.Enums;
using ExaminationManagementSystem.Questions;


//TODO: clear consol for each quuestion 
//TODO: go to main menu

namespace ExaminationManagementSystem.Modes
{
    internal class DoctorMode
    {
        public List<Question> Questions { get; set; }
        /// i did this list -> to make the doctor put the questions he entered in,
        /// then when i call "StudentMode" in "Main" -> we can obtain these doctor questions to be displayed to the student :)
        public int QuestionsCount { get; set; }

        public DoctorMode()
        {
            /// wrong:
            /// Questions = new List<Question>(QuestionsCount);//capacity = QuestionsCount //حددتها من الاول عشان ميحصلش resize
            /// 

             Questions = new List<Question>();//to allow doctor add many times to one list "Questions" :) في حالة كل شوية بيختار المود مرة جديدة
        }

        //--------------------------
        public void Start()
        {
            //نقلتهم هنا عشان لو الدكتور أختار المود أكتر من مرة
            Console.WriteLine("=======================================");
            Console.WriteLine("Hi Doctor :)");
            QuestionsCount = Helper.ValidateInputNumber("How many questions do you want to add? ");
            QuestionType questionType;
            //----------------------------------------------------
            for (int i = 0; i < QuestionsCount; i++)
            {
                Console.WriteLine($"Adding question {i + 1} :");
                //==================
                //1- determine the question type:
                ///VIP:
                /// during displaying a msg to user to choose espicialy "words Not num" => and this choice will reflect on the enum => go to Enum and copy paste the same words :)
                /// upper | lower is not a problem  -> but the wrong spilling will give "invalid type" :)
                /// 
                questionType = Helper.ValidateAndGetEnum<QuestionType>("Select question type 'words | numbers' (1. TrueFalse , 2.ChooseOne , 3.MultiChoice) : ");
                //==================
                //2- create obj:
                switch (questionType)
                {
                    case QuestionType.TrueFalse:
                        {
                            Questions.Add(new TrueFalseQuestion());
                            break;
                        }
                    case QuestionType.ChooseOne:
                        {
                            Questions.Add(new ChooseOneQuestion());
                            break;
                        }
                    case QuestionType.MultiChoice:
                        {
                            Questions.Add(new MultiChoiceQuestion());
                            break;
                        }
                        //no need to default => i'm sure questionType has value in the enum only :)
                }
                //==================
                //3- display Q:
                Questions[i].EnterQuestion();
                ///يا للروعة
                /// polymorphism will happen in [Compile Time] => compiler will attach with "DisplayQuestion" of Question class
                /// then in [Run Time] => will override the "DisplayQuestion" of Question to "DisplayQuestion" of the type which user is chose :) [child class from question] :)
                
            }
           Console.WriteLine($"merci ya doctor, now become {this.Questions.Count} Question :)");
        }
        //--------------------------

    }
}
