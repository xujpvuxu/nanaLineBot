using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class ExitGuessNumber : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = @"^結束猜數字$";

        public ExitGuessNumber(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (GuessNumber.Setting_IsPlay)
            {
                GuessNumber.Setting_IsPlay = false;
                ReplyText("猜數字已結束");
            }
        }
    }
}