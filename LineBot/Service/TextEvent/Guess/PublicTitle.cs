using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class PublicTitle : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = "^猜數字$";

        public PublicTitle(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (GuessNumber.Setting_IsPlay)
            {
                // 出題
                GuessQuestion();
            }
            else
            {
                GuessNumber.Setting_IsPlay = true;
                GuessQuestion();
            }
        }

        /// <summary>
        /// 設定題目
        /// </summary>
        private void GuessQuestion()
        {
            int[] question = Enumerable.Range(0, 10).ToArray();

            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < question.Length; i++)
            {
                int randomNumber = random.Next(question.Length);
                int tempPosition = question[i];

                question[i] = question[randomNumber];
                question[randomNumber] = tempPosition;
            }
            GuessNumber.Setting_Ansert = string.Join(string.Empty, question.Take(4).Select(x => x.ToString()));
            GuessNumber.HistoryRecord = new List<(string, string)>();
            ReplyText("請猜數字 0000-9999");
        }
    }
}