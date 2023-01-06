namespace LineBot.Service.TextEvent.Guess
{
    public interface IGuessCondition
    {
        (bool isInvalid, string replyText) Condition(string userNumber, List<(string count, string userAnswer)> history);
    }
}