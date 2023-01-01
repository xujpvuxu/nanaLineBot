using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.TextEvent
{
    public class DrawStraws : BaseResponse, ITextEvent
    {
        public DrawStraws(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = "^抽籤$";

        private string NegitiveUri = @"https://arielhsu.tw/negative-energy-sentence/";
        private static List<(string type, string describe)> Lots = new List<(string, string)>();

        public void Result()
        {
            if (!Lots.Any())
            {
                RandomLots();
            }
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            (string type, string describe) lot = Lots[rand.Next(0, Lots.Count)];

            ReplyText(new List<string> { lot.type, lot.describe });
        }

        private void RandomLots()
        {
            List<string> negitive = GetNegativeEnergy();
            ForRandom(negitive);

            Lots = LotTypes().SelectMany(data => Enumerable.Repeat(data.type, data.count))
                             .Zip(negitive, (x, y) => (x, y))
                             .ToList();
            ForRandom(Lots);
        }

        /// <summary>
        /// 洗亂
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        private void ForRandom<T>(List<T> source)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < source.Count; i++)
            {
                int tempPosition = rand.Next(0, source.Count);

                var temp = source[i];
                source[i] = source[tempPosition];
                source[tempPosition] = temp;
            }
        }

        /// <summary>
        /// 抽籤個數
        /// </summary>
        /// <returns></returns>
        private List<(int count, string type)> LotTypes()
        {
            return new List<(int count, string type)>
                    {
                        (3, "大吉"),
                        (10,"上上"),
                        (13,"上吉"),
                        (1, "上平"),
                        (9 ,"中吉"),
                        (36,"中平"),
                        (1 ,"中中"),
                        (27,"下下"),
                    };
        }

        /// <summary>
        /// 網站中抓取負能量
        /// </summary>
        /// <returns></returns>
        private List<string> GetNegativeEnergy()
        {
            List<string> negatives = new List<string>();

            HttpClient client = new HttpClient();
            string content = client.GetStringAsync(NegitiveUri).Result;
            string pattern = $@"font-size: 20px; color: #000000;"">(?<negtive>.*?)<";
            var ete = Regex.Matches(content, pattern);
            List<string> t = Regex.Matches(content, pattern)
                                  .OfType<Match>()
                                  .Select(data => Regex.Replace(data.Groups["negtive"].Value, @"[\d]{1,2}、", string.Empty))
                                  .Where(data => !string.IsNullOrWhiteSpace(data)).ToList();
            negatives = t.Select(
                                        (data, i) =>
                                        {
                                            string result = data;
                                            if (i == 88)
                                            {
                                                //特別處理
                                                result = $"{t[88]}{t[89]}";
                                            }
                                            return result;
                                        })
                                  .Where((data, i) => i != 89)
                                  .Take(98).ToList();
            negatives.Add("努力不保證成功，偷懶保證輕鬆！");
            negatives.Add("世上無難事，只要肯放棄");
            return negatives;
        }
    }
}