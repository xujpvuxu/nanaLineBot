using LineBot.Domain.MessageEventSpace.Daily.Sub;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using LineBot.Service.MessageEventSpace.Daily.Movie;

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
                try
                {
                    List<IDaily> gifts = new List<IDaily>
                    {
                        new Bh3(),
                        new OriginalGod(),
                        new BStreet(),
                        new Agentm(),
                        new Chickpt(),
                        new Feebee(),
                        new MagicHour(),
                    };
                    gifts.AsParallel().ForAll(gift => gift.GetDailyGift());

                    ReplyText(string.Join(Environment.NewLine, "日報告"));
                }
                catch (Exception ex)
                {

                    ReplyText(ex.ToString());
                }
                
            }
        }
    }
}