namespace LineBot.Service.TextEvent.Guess
{
    public class RepeatGuessNumber : IGuessCondition
    {
        public string ReplyText => "腦霧還是眼ㄆㄧㄚˊ！不能重複啦！！！";

        public (bool isInvalid, string replyText) Condition(string userNumber, List<(string count, string userAnswer)> history)
        {
            (string count, string userAnswer) = history.FirstOrDefault(data => data.userAnswer.Split('　').First().Equals(userNumber));
            if (count == null)
            {
                return (false, string.Empty);
            }
            else
            {
                return (true, $@"腦霧還是眼ㄆㄧㄚˊ！第{count}次就猜過了！！！");
            }
        }
    }
}