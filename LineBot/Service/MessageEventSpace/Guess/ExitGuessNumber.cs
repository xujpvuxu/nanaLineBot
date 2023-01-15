using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.MessageEventSpace
{
    public class ExitGuessNumber : BaseResponse, IMessageEventSpace
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