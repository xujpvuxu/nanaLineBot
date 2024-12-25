using LineBot.Domain;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using LineBot.Service.MessageEventSpace.Sexs;

namespace LineBot.Domain.MessageEventSpace
{
    public class SexIndex : BaseResponse, IMessageEventSpace
    {
        public SexIndex(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = $@"^ss[\d][\d]$";

        public void Result()
        {
            string inputText = EventObject.Message.Text;
            string type =inputText.Substring(0, 3);
            string counter = inputText.Substring(3);
            int.TryParse(counter, out int count);

            string result = string.Empty;
            switch (type)
            {
                case "ss1":

                    result = new SexIndexOne().GetResult(count);
                    break;
                case "ss2":
                    result = new SexIndexTwo().GetResult(count);
                    break;
                default:
                    break;
            
            }

            ReplyText(string.Join(Environment.NewLine, result));
        }
    }
}