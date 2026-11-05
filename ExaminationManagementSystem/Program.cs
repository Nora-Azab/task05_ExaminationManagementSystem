using ExaminationManagementSystem.Enums;
using ExaminationManagementSystem.Questions;

namespace ExaminationManagementSystem;
internal class Program
{
    static void Main(string[] args)
    {
        #region test ValidateMultiChoices method :)
        string? input;
        List<int> indexes = [];
        do
        {
            input = Console.ReadLine();
            indexes = Helper.ValidateAndGetMultiChoices(input);
            if (indexes.Count != 0)
                break;
            Console.WriteLine("invalid input for the choices, try again:)");

        } while (true);
        List<string> choices = ["1.nour", "2.fareda", "3.shefaa", "4.rawda"];
        foreach (var index in indexes)
        {
            Console.WriteLine(choices[index]);
        }
        #endregion

        //Question question = new Question();
        //question.DisplayQuestion();
        //Answer ans = new Answer();
        //ans.EnterChoices();

    }
    //=======================================================
    //methods:
    
}
