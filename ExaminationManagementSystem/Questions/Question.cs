using ExaminationManagementSystem.Enums;
//TODO: حاسة مكنش في داعي للabstract type
namespace ExaminationManagementSystem.Questions
{
    internal abstract class Question
    {
        public int Id { get; set; }//TODO: Guid?
        public string Header { get; set; }
        public double Mark { get; set; }
        public abstract QuestionType Type
        {
            get;
        }//TODO done: must be abstract to determine hte type at first?
         //and i removed set -> عشان محدش يعدل فيها من بره
        public Level Level { get; set; }
        public Answer Answer { get; set; } = new Answer(); // must init with creating an obj to avoid null exception when u need to access Answer class :)
        //-----------------------
        public virtual void EnterQuestion()
        {

            #region level:

            #region native code :)
            //string message = "Enter Number [1:3] For Question Level (1. easy | 2. medium | 3. hard) : ";
            //int number;
            //do
            //{
            //    number = Helper.ValidateInputNumber(message);
            //    if (number > 0 && number <= 3)//must be [1:3]
            //        break;
            //    Console.WriteLine("invaild input, num must be [1:3] only :) ");

            //} while (true);
            //this.Level = (Level)number;//انا ضمنت من فوق انه جاي رقم من 1 ل 3 فقط
            ////Console.WriteLine($"you chose {Level} level :)"); 
            #endregion

            #region use Enum.TryParse()
            this.Level = Helper.ValidateAndGetEnum<Level>("Enter The Question Level 'words | numbers' as u like (1. easy | 2. medium | 3. hard) : ");

            #endregion 

            #endregion
            //------------
            #region header:
            do
            {
                Console.WriteLine("Enter Question Header : ");
                this.Header = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(Header) && Header?.Length > 4)
                    break;
                Console.WriteLine("invalid header, (the header can't be spaces and its length must be > 4 characters) try again:)");
            } while (true);
            #endregion
            //------------
            #region mark:

            do
            {
                string msg = "Enter The Question Mark : ";
                this.Mark = Helper.ValidateDoubleNumber(msg);
                if (Mark > 0)//pos num
                    break;
                Console.WriteLine("invalid value, mark must be positive :)");

            } while (true);

            #endregion
        }
        
        //-----------------------
        public static List<Question> Filter(List<Question> questions , Func<Question , bool> filter)// general filter : (type | level | .....)
        ///delegate                                (q)        ->   q.Level=="easy"   |  q.Type == "ChooseOne" ...etc
        ///delegate                                (Question) ->   bool
        ///Predigate<Q , bool> | Func<Q , bool>    (Question) ->   bool
        ///if( filter(questions[i] )   -> invoking for the delegate which point to the method the user will pass (ex :  (q)=> q.Level=="easy" ) وهكذا:)
        ///
        {
            List<Question> filteredQuestions = new List<Question>();
            for (int i = 0; i < questions.Count; i++)
                if (filter(questions[i]))//invoking :)
                    filteredQuestions.Add(questions[i]);

            return filteredQuestions;
        }
        //-----------------------
    }
}
