using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class FinalTitle : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = "^終極密碼$";
        public WebhookEventDto EventObject { get; set; }

        public void Result(WebhookEventDto eventObject)
        {
            EventObject = eventObject;
            if (FinalSetting.IsPlay)
            {
                // 出題
                GuessQuestion();
            }
            else
            {
                FinalSetting.IsPlay = true;
                GuessQuestion();
            }
        }

        /// <summary>
        /// 設定題目
        /// </summary>
        private void GuessQuestion()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int number = 100;

            // 初始設定 Next(99) 為 0-98 但應該是 1-99
            FinalSetting.Answer = random.Next(number - 1) + 1;
            FinalSetting.MinNumber = 0;
            FinalSetting.MaxNumber = number;

            var replyMessage = new ReplyMessageRequestDto<TextMessageDto>(EventObject)
            {
                Messages = new List<TextMessageDto>
                            {
                                new TextMessageDto
                                {
                                    Text = $@"終極密碼開始 0-{number}",
                                }
                            }
            };
            ReplyMessageHandler("text", replyMessage);
        }
    }
}