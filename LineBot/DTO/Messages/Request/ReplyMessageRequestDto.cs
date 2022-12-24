using LineBot.DTO.Webhook;

namespace LineBot.DTO.Messages.Request
{
    /// <summary>
    /// 回傳到Line伺服器的基本內容
    /// </summary>
    /// <typeparam name="T"></typeparam>
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