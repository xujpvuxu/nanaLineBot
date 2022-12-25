using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class ExitFinalr : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = @"^結束終極密碼$";
        public WebhookEventDto EventObject { get; set; }

        public void Result(WebhookEventDto eventObject)
        {
            EventObject = eventObject;
            if (FinalSetting.IsPlay)
            {
                FinalSetting.IsPlay = false;
                var replyMessage = new ReplyMessageRequestDto<TextMessageDto>(EventObject)
                {
                    Messages = new List<TextMessageDto>
                            {
                                new TextMessageDto
                                {
                                    Text = "終極密碼已結束",
                                }
                            }
                };
                ReplyMessageHandler("text", replyMessage);
            }
        }
    }
}