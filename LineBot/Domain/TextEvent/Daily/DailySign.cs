using LineBot.Domain.TextEvent.Daily.Sub;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class DailySign : BaseResponse, ITextEvent
    {
        public DailySign(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = @"^崩壞$";

        public void Result()
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
            gifts.ForEach(gift => gift.GetDailyGift());
            ReplyText("每日登入已完成");
        }
    }
}