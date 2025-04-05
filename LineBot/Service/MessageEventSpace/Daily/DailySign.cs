using LineBot.Domain.MessageEventSpace.Daily.Sub;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using LineBot.Service.MessageEventSpace.Daily.Movie;
using LineBot.Service.MessageEventSpace.Monthes;

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
                        new Chickpt(),
                        new Feebee(),
                        new MagicHour(),
                    };
                    gifts.AsParallel().ForAll(gift => gift.GetDailyGift());

                    string nextMonth = new Month().GetMonth();
                    ReplyText(string.Join(Environment.NewLine, nextMonth));
                }
                catch (Exception ex)
                {

                    ReplyText(ex.ToString());
                }
                
            }
        }
    }
}