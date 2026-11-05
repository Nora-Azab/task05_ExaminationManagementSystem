namespace ExaminationManagementSystem.Questions
{
    internal class Answer
    {
        //public string[] Choices { get; set; } = new string[4];
        public List<string> Choices { get; set; } = [];//TODO: list is better (t|F question has 2 choices only and others have 4 )
        public List<int> CorrectChoices { get; set; } = [];

        //---------------------
        public void EnterChoices()//for [chooseOne question   &  multiChoice Question] only :)
        {
            string msg;
            string choice;
            int i = 1;
            while (i <= 4)
            {
                msg = $"{i++}. ";
                choice = Helper.ValidateStringInput(msg);
                this.Choices.Add(choice);
            }
        }
        //---------------------
    }
}
