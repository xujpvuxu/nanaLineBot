using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class FinalNumber : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = @"^[\d]{1,2}$";

        public static bool Setting_IsPlay = false;
        public static int Setting_MinNumber = 0;
        public static int Setting_MaxNumber = 100;
        public static int Setting_Answer = 100;

        public FinalNumber(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (Setting_IsPlay)
            {
                int.TryParse(EventObject.Message.Text, out int userNumber);

                int minNumber = Setting_MinNumber;
                int maxNumber = Setting_MaxNumber;
                int answerNumber = Setting_Answer;
                if (userNumber <= minNumber || userNumber >= maxNumber)
                {
                    ReplyText($@"眼殘嗎！！！！  {minNumber}-{maxNumber}");
                }
                else if (userNumber == answerNumber)
                {
                    Setting_IsPlay = false;
                    ReplyText($@"蹦！！炸死你！！ 答案{answerNumber}");
                }
                else
                {
                    if (minNumber < userNumber && userNumber < answerNumber)
                    {
                        // 最小數字 及 答案之間
                        Setting_MinNumber = userNumber;
                    }
                    else
                    {
                        // 答案 及 最大之間
                        Setting_MaxNumber = userNumber;
                    }
                    ReplyText($@"{Setting_MinNumber}-{Setting_MaxNumber}");
                }
            }
        }
    }
}