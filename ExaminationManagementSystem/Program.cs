using ExaminationManagementSystem.Enums;

namespace ExaminationManagementSystem;
internal class Program
{
    static void Main(string[] args)
    {
        #region test ValidateAnswerChoices method :)
        //string input;
        //List<int> indexes = [];
        //do
        //{
        //    input = Console.ReadLine();
        //    indexes = ValidateAnswerChoices(input);
        //    if (indexes.Count != 0)
        //        break;
        //    Console.WriteLine("invalid input for the choices, try again:)");

        //} while(true);
        //List<string> choices = ["1.nour" , "2.fareda" , "3.shefaa" , "4.rawda"];
        //foreach (var index in indexes)
        //{
        //    Console.WriteLine(choices[index]);
        //} 
        #endregion


    }
    //=======================================================
    //methods:
    public static List<int> ValidateAnswerChoices(string input)
    {
        int num;
        bool converted;
        List<int> result = [];
        //------------
        string[] inputs = input.Split(",");

        if (inputs.Length == 0 || inputs.Length > 4)//1:4 choices only allowed
            return result;//which is empty
        foreach(var item in inputs)
        {
            converted= int.TryParse(item, out num) && num > 0 && num<=4;// 0 => not allowed (1.true..1.choice one ....etc) i will start numbering the choices from 1 :)
            if (converted)
                result.Add(num-1);// -1  => because list is zero indexed
            else
                return [];//one of choices is not allowed

        }
        return result;
    }
}
