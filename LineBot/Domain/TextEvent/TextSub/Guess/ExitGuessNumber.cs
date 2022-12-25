using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class GuessNumber : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = @"^結束猜數字$";
        public WebhookEventDto EventObject { get; set; }

        public void Result(WebhookEventDto eventObject)
        {
            EventObject = eventObject;
            if (GuessNumberSetting.IsPlay)
            {
                GuessNumberSetting.IsPlay = false;
                var replyMessage = new ReplyMessageRequestDto<TextMessageDto>(EventObject)
                {
                    Messages = new List<TextMessageDto>
                            {
                                new TextMessageDto
                                {
                                    Text = "猜數字已結束",
                                }
                            }
                };
                ReplyMessageHandler("text", replyMessage);
            }
        }
    }
}