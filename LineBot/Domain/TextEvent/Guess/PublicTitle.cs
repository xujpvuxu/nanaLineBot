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
            if (GuessNumberSetting.IsPlay)
            {
                // 出題
                GuessQuestion();
            }
            else
            {
                GuessNumberSetting.IsPlay = true;
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
            GuessNumberSetting.Answer = string.Join(string.Empty, question.Take(4).Select(x => x.ToString()));

            ReplyText("請猜數字 0000-9999");
        }
    }
}