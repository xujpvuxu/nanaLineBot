using LineBot.Domain.MessageEventSpace.Base;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.MessageEventSpace
{
    public class Eat : BasePicture, IMessageEventSpace
    {
        public Eat(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = $@"zz (?<counter>[\d.]+) (?<hot>[\d.]+) (?<egg>[\d.]+) (?<mi>[\d.]+)$";

        public void Result()
        {
            string inputText = EventObject.Message.Text;
            string pat = $@"zz (?<counter>[\d.]+) (?<hot>[\d.]+) (?<egg>[\d.]+) (?<mi>[\d.]+)$";
            var regex = Regex.Match(inputText, pat); // 使用修正後的正則表達式
            decimal counter = decimal.Parse(regex.Groups["counter"].Value);
            decimal hot = decimal.Parse(regex.Groups["hot"].Value);
            decimal egg = decimal.Parse(regex.Groups["egg"].Value);
            decimal mi = decimal.Parse(regex.Groups["mi"].Value);

            // 澱粉份數
            decimal miCounter = Math.Round(mi / 15, 2) * counter;

            // 澱粉蛋白質
            decimal miEgg = miCounter * 1.5m;

            decimal eggCounter = (egg - miEgg) * counter > 0 
                                    ?(egg - miEgg) * counter:
                                    0;

            // 總熱量計算
            decimal totalCalories = hot * counter;

            List<string> source = new List<string>
            {
                $"總熱量：{totalCalories} kcal",
                $"五穀澱粉份數：{miCounter}份 (9)",
                //$"五穀蛋白質克數：{miEgg}g",
                $"蛋豆魚肉份數：{eggCounter}份(4)",
                $"蔬菜：(3)",
                $"水果：(2)",
                $"鈉：建議一天 1200mg-2000mg",
            };
            ReplyText(string.Join(Environment.NewLine, source));
        }
    }
}