using LineBot.Domain;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.MessageEventSpace
{
    public class SexHelp : BaseResponse, IMessageEventSpace
    {
        public string Pattern { get; set; } = "^ssHelp$";

        public SexHelp(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            List<string> source = new List<string>
            {
                "ss1x:動作x次",
                "ss2x:色色x次",
                $@"URL:https://docs.google.com/spreadsheets/d/1co08s6FapFHaV9L4eLET4zb9jqq2DGra7NH9j_vj0p0/edit"
            };
            ReplyText(string.Join(Environment.NewLine, string.Join(Environment.NewLine, source)));
        }
    }
}