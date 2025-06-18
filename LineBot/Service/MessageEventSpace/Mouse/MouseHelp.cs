using LineBot.Domain;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.MessageEventSpace
{
    public class MouseHelp : BaseResponse, IMessageEventSpace
    {
        public string Pattern { get; set; } = "^MHelp$";

        public MouseHelp(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            string url = "URL:https://docs.google.com/spreadsheets/d/1jTchAMN4sLJQlR5RCJiYh7lxCuf52_0mP_gIv-k3P14/edit?gid=0#gid=0";
            ReplyText(url);
        }
    }
}
