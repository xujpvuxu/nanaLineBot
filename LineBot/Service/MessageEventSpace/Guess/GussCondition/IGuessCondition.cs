namespace LineBot.Service.MessageEventSpace.Guess
{
    public interface IGuessCondition
    {
        (bool isInvalid, string replyText) Condition(string userNumber, List<(string count, string userAnswer)> history);
    }
}