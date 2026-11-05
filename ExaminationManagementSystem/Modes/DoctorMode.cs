using ExaminationManagementSystem.Enums;
using ExaminationManagementSystem.Questions;


//TODO: clear consol for each quuestion 
//TODO: go to main menu

namespace ExaminationManagementSystem.Modes
{
    internal class DoctorMode
    {
        public void Start()
        {
            int questionsCount = Helper.ValidateInputNumber("How many questions do you want to add? ");
            Question[] questions = new Question[questionsCount];
            QuestionType questionType;
            //----------------------------------------------------
            for (int i = 0; i < questionsCount; i++)
            {
                Console.WriteLine($"Adding question {i + 1} :");
                //==================
                //1- determine the question type:
                do
                {
                    ///VIP:
                    /// during displaying a msg to user to choose espicialy "words Not num" => and this choice will reflect on the enum => go to Enum and copy paste the same words :)
                    /// upper | lower is not a problem  -> but the wrong spilling will give "invalid type" :)
                    /// 
                    Console.Write("Select question type 'words | numbers' (1. TrueFalse , 2.ChooseOne , 3.MultiChoice) : ");
                    if (Enum.TryParse(Console.ReadLine(), ignoreCase: true, out questionType) && Enum.IsDefined(questionType))
                    //added "IsDefined" -> to avoid numbers outside the enum which is accepted for Enum.TryParse :)
                    {
                        Console.WriteLine("===============================");
                        Console.WriteLine($"{questionType} Question :");
                        break;
                    }
                    Console.WriteLine("invalid type, try again:)");
                } while (true);
                //==================
                //2- create obj:
                switch (questionType)
                {
                    case QuestionType.TrueFalse:
                        {
                            questions[i] = new TrueFalseQuestion();
                            break;
                        }
                    case QuestionType.ChooseOne:
                        {
                            questions[i] = new ChooseOneQuestion();
                            break;
                        }
                    case QuestionType.MultiChoice:
                        {
                            questions[i] = new MultiChoiceQuestion();
                            break;
                        }
                        //no need to default => i'm sure questionType has value in the enum only :)
                }
                //==================
                //3- display Q:
                questions[i].DisplayQuestion();
                ///يا للروعة
                /// polymorphism will happen in [Compile Time] => compiler will attach with "DisplayQuestion" of Question class
                /// then in [Run Time] => will override the "DisplayQuestion" of Question to "DisplayQuestion" of the type which user is chose :) [child class from question] :)

            }
        }
    }
}
