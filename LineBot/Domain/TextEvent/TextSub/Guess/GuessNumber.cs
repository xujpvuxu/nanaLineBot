using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class ExitGuessNumber : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = @"^[\d]{4}$";

        public WebhookEventDto EventObject { get; set; }

        public void Result(WebhookEventDto eventObject)
        {
            EventObject = eventObject;
            if (GuessNumberSetting.IsPlay)
            {
                string userNumber = eventObject.Message.Text;
                string answer = GuessNumberSetting.Answer;
                // 有相同的數字 = ? B
                int b = answer.Select(data => data.ToString()).Intersect(userNumber.Select(data => data.ToString()).ToList()).Count();
                // 位置相同 = ?A
                int a = 0;
                for (int i = 0; i < answer.Length; i++)
                {
                    if (userNumber[i] == answer[i])
                    {
                        a++;
                    }
                }

                // B = B-A = 真正的B
                b = b - a;

                bool isMatchAnswer = a == answer.Length;

                // 猜對答案
                if (isMatchAnswer)
                {
                    // 關閉遊戲
                    GuessNumberSetting.IsPlay = false;
                }

                var replyMessage = new ReplyMessageRequestDto<TextMessageDto>(EventObject)
                {
                    Messages = new List<TextMessageDto>
                            {
                                new TextMessageDto
                                {
                                    Text = isMatchAnswer?
                                                $@"恭喜你猜對了 答案為{answer}":
                                                $@"{userNumber}　{a}A{b}B",
                                }
                            }
                };
                ReplyMessageHandler("text", replyMessage);
            }
        }
    }
}