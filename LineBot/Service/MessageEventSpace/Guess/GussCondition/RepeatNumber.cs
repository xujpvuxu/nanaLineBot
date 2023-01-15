namespace LineBot.Service.MessageEventSpace.Guess
{
    public class RepeatNumber : IGuessCondition
    {
        public (bool isInvalid, string replyText) Condition(string userNumber, List<(string count, string userAnswer)> history)
        {
            bool isInvalid = userNumber.GroupBy(data => data).Where(data => data.ToList().Count > 1).Any();
            return (isInvalid, "靠腰喔！不能重複啦！！！");
        }
    }
}