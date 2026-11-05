using ExaminationManagementSystem.Enums;

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
        public virtual void DisplayQuestion()
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
            Level l;
            do
            {
                Console.Write("Enter The Level 'words | numbers' as u like (1. easy | 2. medium | 3. hard) : ");
                //if (Enum.TryParse(Console.ReadLine(), out Level l))//"this.Level" instead of "l"   wrong -> it's not "out"
                /// 1 | easy       -> l = easy
                /// 2 | medium     -> l = medium
                /// 3 | hard       -> l = hard
                /// 4              -> l = 4       => which is wrong :(
                /// Easy           -> invalid     => case sensitive
                ///

                //if (Enum.TryParse(Console.ReadLine(),ignoreCase: true, out Level l))
                /// EaSy -> l=easy
                /// easy -> l=easy
                /// 

                //عايزة احل مشكلة انه بيقبل ارقام مش متمثلة في الاينم اصلا
                if (Enum.TryParse(Console.ReadLine(), ignoreCase: true, out l) && Enum.IsDefined(l))//وطبعا لازم الترتيب ده عشان القيمة ال طلعت في الأوت الاول 
                {
                    //Console.WriteLine($"level = {l}");
                    break;
                }
                Console.WriteLine("invalid level :(");

            } while (true);
            this.Level = l;

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
    }
}
