using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class ExitGuessNumber : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = @"^[\d]{4}$";

        public ExitGuessNumber(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (GuessNumberSetting.IsPlay)
            {
                string userNumber = EventObject.Message.Text;
                string answer = GuessNumberSetting.Answer;

                // 位置相同 = ?A
                int a = answer.Where((data, i) => data == userNumber[i]).Count();

                if (a == answer.Length)
                {
                    // 猜對答案
                    GuessNumberSetting.IsPlay = false;
                    ReplyText($@"恭喜你猜對了 答案為{answer}");
                }
                else
                {
                    // 有相同的數字 = ? B
                    int b = answer.Select(data => data.ToString()).Intersect(userNumber.Select(data => data.ToString()).ToList()).Count();
                    // B = B-A = 真正的B
                    ReplyText($@"{userNumber}　{a}A{b - a}B");
                }
            }
        }
    }
}