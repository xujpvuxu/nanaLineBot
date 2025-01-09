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

        public string Pattern { get; set; } = $@"zz (?<counter>[\d.]+) (?<hot>[\d.]+) (?<egg>[\d.]+) (?<mi>[\d.]+) (?<na>[\d.]+)$";

        public void Result()
        {
            string inputText = EventObject.Message.Text;
            var regex = Regex.Match(inputText, Pattern); // 使用修正後的正則表達式
            decimal counter = decimal.Parse(regex.Groups["counter"].Value);
            decimal hot = decimal.Parse(regex.Groups["hot"].Value);
            decimal egg = decimal.Parse(regex.Groups["egg"].Value);
            decimal mi = decimal.Parse(regex.Groups["mi"].Value);
            decimal na = decimal.Parse(regex.Groups["na"].Value);

            // 澱粉份數
            decimal miCounter = Math.Round(mi / 15, 2) * counter;

            // 澱粉蛋白質
            decimal miEgg = miCounter * 1.5m;

            // 蛋豆魚肉份數
            decimal eggCounter = (egg - miEgg) * counter > 0
                                    ? (egg - miEgg) * counter :
                                    0;

            decimal hotPercent = 100 / hot;
            decimal eggPercent = egg * hotPercent;
            string eggGood = eggPercent <= 1 ? "好" : "不好";
            decimal naPercent = na * hotPercent;
            string naGood = naPercent <= 100 ? "好" : "不好";

            List<string> source = new List<string>
            {
                $"總熱量：{hot * counter} kcal",
                $"五穀澱粉份數：{miCounter}份 (9)",
                //$"五穀蛋白質克數：{miEgg}g",
                $"蛋豆魚肉份數：{eggCounter}份(4)",
                $"蔬菜：(3)",
                $"水果：(2)",
                $"鈉：建議一天 1200mg-2000mg",
                string.Empty,
                "低蛋白澱粉",
                $"蛋白質比例:{eggPercent}",
                $"蛋白質:{eggGood}(<=1)",
                $"鈉比例:{naPercent}",
                $"鈉:{naGood}(<=100)",
            };

            ReplyText(string.Join(Environment.NewLine, source));
        }
    }
}