using LineBot.Domain;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using LineBot.Service.MessageEventSpace.Sexs;

namespace LineBot.Domain.MessageEventSpace
{
    public class Dice : BaseResponse, IMessageEventSpace
    {
        public Dice(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = $@"^骰子[\d]+$";

        public void Result()
        {
            string inputText = EventObject.Message.Text;
            string type = inputText.Substring(0, 3);
            string counter = inputText.Substring(2);
            int.TryParse(counter, out int count);

            ReplyText(string.Join(Environment.NewLine, Enumerable.Range(0, count + 1).ToList().GetRandomOne()));
        }
    }
}