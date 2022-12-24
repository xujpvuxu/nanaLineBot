using LineBot.DTO.Webhook;

namespace LineBot.DTO.Messages.Request
{
    public class ReplyMessageRequestDto<T>
    {
        public ReplyMessageRequestDto(WebhookEventDto eventObject)
        {
            ReplyToken = eventObject.ReplyToken;
        }
        public string ReplyToken { get; set; }
        public List<T> Messages { get; set; }
        public bool? NotificationDisabled { get; set; }
    }
}
