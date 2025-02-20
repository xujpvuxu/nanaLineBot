using LineBot.Domain;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.MessageEventSpace
{
    public class CatHelp : BaseResponse, IMessageEventSpace
    {
        public string Pattern { get; set; } = "^CatHelp$";

        public CatHelp(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            string url = "URL:https://docs.google.com/spreadsheets/d/1sV2UFlX5K2hM9Jat8roymkAs6zWwPOTf8zugJS2xwOc/edit?gid=970359765#gid=970359765";
            ReplyText(url);
        }
    }
}
