using LineBot.Domain.MessageEventSpace.Daily.Model;
using LineBot.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LineBot.Domain.MessageEventSpace.Daily.Sub
{
    public class Feebee : IDaily
    {
        public string Uri { get; set; } = "https://feebee.com.tw/event/reward_ad?is_show_production_ad=1";

        public void GetDailyGift()
        {
            foreach (DailyLoging perDailyLogings in GetModel())
            {
                HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 15_4_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148");
                client.DefaultRequestHeaders.Add("Cookie", perDailyLogings.Cookie);
                var response = client.GetAsync(Uri).Result;
                string content = response.Content.ReadAsStringAsync().Result;
            }
        }

        private List<DailyLoging> GetModel()
        {
            return new List<DailyLoging>
            {
                new DailyLoging{ Cookie = "app=ios-prod-release-v3.43.0-2022062003;domain=.feebee.com.tw; path=/;appu=v2S-TmV1STFWOXdMM0dPcUVXdFZoaHZXQUlRNm1hOFE2STFrWkRzWGo4SVpPeitrNXczdWR6dCtZUGJic0x1OFlJbmRJQVJyS05yL2hZTWd6a1pkbEQ4MTFTdmNna29KTkVvUmsxS1RMVWpzb3JUQ1dibHFJYkhPWkd3bjQwTXpWbXlyZVNobjFWeWpNd25lTTlHZEdPVktucTJQa2lEaHNCR0pNQzJiSllyM3E0MUxrdm40bk1LZDluaGhTNjJqUG1pbC9JcmpKbVhyMHBVYzhCUzhuS0NleHVUU0xYZWNuckNxNllCQ0dyT3o3bz0%3D;domain=.feebee.com.tw; path=/;appd=7ad43031;domain=.feebee.com.tw; path=/;"}
            };
        }
    }
}