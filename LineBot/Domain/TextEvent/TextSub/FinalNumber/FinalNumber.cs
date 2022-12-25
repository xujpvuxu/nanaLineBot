using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class FinalNumber : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = @"^[\d]{1,2}$";
        public WebhookEventDto EventObject { get; set; }

        public void Result(WebhookEventDto eventObject)
        {
            EventObject = eventObject;
            if (FinalSetting.IsPlay)
            {
                int.TryParse(eventObject.Message.Text, out int userNumber);

                int minNumber = FinalSetting.MinNumber;
                int maxNumber = FinalSetting.MaxNumber;
                int answerNumber = FinalSetting.Answer;
                if (userNumber <= minNumber || userNumber >= maxNumber)
                {
                    SendResult($@"眼殘嗎！！！！  {minNumber}-{maxNumber}");
                }
                else if (userNumber == answerNumber)
                {
                    FinalSetting.IsPlay = false;
                    SendResult($@"蹦！！炸死你！！ 答案{answerNumber}");
                }
                else
                {
                    if (minNumber < userNumber && userNumber < answerNumber)
                    {
                        // 最小數字 及 答案之間
                        FinalSetting.MinNumber = userNumber;
                    }
                    else
                    {
                        // 答案 及 最大之間
                        FinalSetting.MaxNumber = userNumber;
                    }
                    SendResult($@"{FinalSetting.MinNumber}-{FinalSetting.MaxNumber}");
                }
            }
        }

        private void SendResult(string content)
        {
            var replyMessage = new ReplyMessageRequestDto<TextMessageDto>(EventObject)
            {
                Messages = new List<TextMessageDto>
                            {
                                new TextMessageDto
                                {
                                    Text = content,
                                }
                            }
            };
            ReplyMessageHandler("text", replyMessage);
        }
    }
}