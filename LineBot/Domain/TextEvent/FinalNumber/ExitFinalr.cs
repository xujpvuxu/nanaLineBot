using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class ExitFinalr : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = @"^結束終極密碼$";

        public ExitFinalr(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (FinalSetting.IsPlay)
            {
                FinalSetting.IsPlay = false;
                ReplyText("終極密碼已結束");
            }
        }
    }
}