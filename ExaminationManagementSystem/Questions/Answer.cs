namespace ExaminationManagementSystem.Questions
{
    internal class Answer
    {
        //public string[] Choices { get; set; } = new string[4];
        public List<string> Choices { get; set; } = [];//TODO: list is better (t|F question has 2 choices only and others have 4 )
        public List<int> CorrectChoices { get; set; } = [];

        
    }
}
