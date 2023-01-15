using LineBot.Domain.MessageEventSpace.Daily.Sub;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.MessageEventSpace
{
    public class DailySign : BaseResponse, IMessageEventSpace
    {
        public DailySign(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = @"^崩壞$";

        private static string Datetime = string.Empty;

        public void Result()
        {
            string dateTime = DateTime.Now.ToString("yyyyMMdd");
            if (Datetime.Equals(dateTime))
            {
                ReplyText("今日已經登入過了");
            }
            else
            {
                List<IDaily> gifts = new List<IDaily>
                {
                    new Bh3(),
                    new MagicHour(),
                    new OriginalGod(),
                    new Agentm(),
                    new Chickpt(),
                    new Feebee(),
                };
                gifts.AsParallel().ForAll(gift => gift.GetDailyGift());
                Datetime = dateTime;
                ReplyText("每日登入已完成");
            }
        }
    }
}