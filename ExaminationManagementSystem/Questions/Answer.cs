namespace ExaminationManagementSystem.Questions
//TODO: make the choices unique => if(hashSet.add())
//TODO:CorrectChoicesIndexes & Choices => must be readonly :)
{
    internal class Answer
    {
        //public string[] Choices { get; set; } = new string[4];
        public List<string> Choices { get; set; } = [];//list is better (t|F question has 2 choices only and others have 4 )
        public List<int> CorrectChoicesIndexes { get; set; } = [];//الاجابات الصحيحة
        public List<int> studentAnswersForOneQuestion { get; set; } = [];//اجابات الطال للسؤال الواحد .. اّراي عشان في حالة بيختار أكتر من اجابة لسؤال المالتبل اتشويسز

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
        public bool CheckAnswer(List<int> studentAnswer)
        {
            ///CorrectChoicesIndexes & studentAnswer   can be not sorted ex: 3,1   [in case multiChoices] :)
            CorrectChoicesIndexes.Sort();//1,3,4
            studentAnswer.Sort();
            //return CorrectChoicesIndexes.SequenceEqual(studentAnswer);

            if(CorrectChoicesIndexes.Count != studentAnswer.Count) return false;
            for(int i = 0; i < CorrectChoicesIndexes.Count; i++) 
                if(CorrectChoicesIndexes[i] != studentAnswer[i] )
                    return false;

            return true;

        }
        //---------------------
    }
}
