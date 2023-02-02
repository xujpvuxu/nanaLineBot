using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.MessageEventSpace
{
    public class PublicTitle : BaseResponse, IMessageEventSpace
    {
        public string Pattern { get; set; } = "^猜數字$";

        public PublicTitle(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (!GuessNumber.Setting_IsPlay)
            {
                GuessNumber.Setting_IsPlay = true;
            }
            GuessQuestion();
        }

        /// <summary>
        /// 設定題目
        /// </summary>
        private void GuessQuestion()
        {
            GuessNumber.Setting_Ansert = string.Join(string.Empty, Enumerable.Range(0, 10).ToRandomList().Take(4));
            GuessNumber.HistoryRecord = new List<(string, string)>();
            ReplyText("請猜數字 0000-9999");
        }
    }
}