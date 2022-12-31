using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class DrawStraws : BaseResponse, ITextEvent
    {
        public DrawStraws(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = "^抽籤$";

        public static List<(string type, string describe)> Lots = new List<(string, string)>();

        public void Result()
        {
            if (!Lots.Any())
            {
                Lots = LotTypes.SelectMany(data => Enumerable.Repeat((data.type, data.describe), data.count))
                               .ToList();
            }
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            (string type, string describe) lot = Lots[rand.Next(0, Lots.Count)];

            ReplyText(new List<string> { lot.type, lot.describe });
        }

        public List<(int count, string type, string describe)> LotTypes = new List<(int, string, string)>
        {
            (3, "大吉","萬人之上，老鼠之下。"),
            (10,"上上","當我眼睛閉上時，我就會什麼都看不到。"),
            (13,"上吉","在美國就連小學生都會說流利的美語，而你什麼都不會。"),
            (1, "上平","當你正在努力工作的時候，地球另一半邊的人正在努力睡覺。"),
            (9 ,"中吉","如果你沒有努力過，就會發現你真的什麼都做不到。"),
            (36,"中平","早安，路人甲。"),
            (1 ,"中中","對你而言，我就是過客，而你什麼都不是。"),
            (27,"下下","連一隻草履蟲都不如。"),
        };
    }
}