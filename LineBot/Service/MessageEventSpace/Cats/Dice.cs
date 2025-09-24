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

        public static int? LastResult { get; set; } = null;

        public void Result()
        {
            string inputText = EventObject.Message.Text;
            string type = inputText.Substring(0, 3);
            string counter = inputText.Substring(2);
            int.TryParse(counter, out int count);

            for (int i = 0; i < 5; i++)
            {
                int result = Enumerable.Range(0, count + 1).ToList().GetRandomOne();
                if (LastResult == null || (LastResult != result))
                {
                    // 跟上次不一樣的結果就結束
                    LastResult = result;
                    break;
                }
            }
            ReplyText(LastResult.ToString());
        }
    }
}