using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using LineBot.Service.TextEvent.Guess;

namespace LineBot.Domain.TextEvent
{
    public class GuessNumber : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = @"^[\d]{4}$";

        public static string Setting_Ansert { get; set; } = string.Empty;
        public static bool Setting_IsPlay { get; set; } = false;
        public static List<(string count, string userAnswer)> HistoryRecord = new List<(string, string)>();

        public GuessNumber(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (Setting_IsPlay)
            {
                string userNumber = EventObject.Message.Text;

                List<IGuessCondition> conditions = new List<IGuessCondition>
                {
                   new RepeatNumber(),
                   new RepeatGuessNumber()
                };

                List<string> replyTexts = conditions.Select(data => data.Condition(userNumber, HistoryRecord))
                                                                       .Where(data => data.isInvalid)
                                                                       .Select(data => data.replyText)
                                                                       .ToList();

                if (replyTexts.Any())
                {
                    ReplyText(replyTexts.First());
                }
                else
                {
                    // 位置相同 = ?A
                    int a = Setting_Ansert.Where((data, i) => data == userNumber[i]).Count();

                    int currentCount = HistoryRecord.Count + 1;
                    if (a == Setting_Ansert.Length)
                    {
                        // 猜對答案
                        Setting_IsPlay = false;
                        ReplyText($@"恭喜第{currentCount}次你猜對了　答案為{Setting_Ansert}");
                    }
                    else
                    {
                        // 有相同的數字 = ? B
                        int b = Setting_Ansert.Select(data => data.ToString()).Intersect(userNumber.Select(data => data.ToString()).ToList()).Count();
                        // B = B-A = 真正的B
                        HistoryRecord.Add((currentCount.ToString("00"), $@"{userNumber}　{a}A{b - a}B"));
                        ReplyText(string.Join(Environment.NewLine, HistoryRecord.Select(data => $"{data.count}　{data.userAnswer}")));
                    }
                }
            }
        }
    }
}