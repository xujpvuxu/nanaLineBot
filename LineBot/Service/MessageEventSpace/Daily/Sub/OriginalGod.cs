using LineBot.Domain.MessageEventSpace.Daily.Model;
using LineBot.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace LineBot.Domain.MessageEventSpace.Daily.Sub
{
    public class OriginalGod : IDaily
    {
        public string Uri { get; set; } = "https://sg-hk4e-api.hoyolab.com/event/sol/sign?lang=zh-tw";

        public void GetDailyGift()
        {
            foreach (DailyLoging perDailyLoging in GetModel())
            {
                HttpClient Client = new HttpClient(new HttpClientHandler() { UseCookies = false });
                Client.DefaultRequestHeaders.Add("Cookie", perDailyLoging.Cookie);

                PostData data = new PostData
                {
                    act_id = perDailyLoging.Other1
                };

                string Content = JsonConvert.SerializeObject(data);
                byte[] Buffer = Encoding.UTF8.GetBytes(Content);
                ByteArrayContent ByteContent = new ByteArrayContent(Buffer);
                ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = Client.PostAsync(Uri, ByteContent).GetAwaiter().GetResult();
                string content = response.Content.ReadAsStringAsync().Result;
            }
        }

        private List<DailyLoging> GetModel()
        {
            return new List<DailyLoging>
            {
                new DailyLoging{ Other1 = "e202102251931481", Cookie = "_MHYUUID=da162798-8797-4bb3-8646-c9f1dcfd1102; mi18nLang=zh-tw; ltoken=AuIraKpCqqTmzyUYNFXsZSeqITBS52Tyh5YwC4xO; ltuid=11205767; cookie_token=0NVSpiTQNmksuFofcpsKolZE1Thyzanevi3QIa8s; account_id=11205767"},
                new DailyLoging{ Other1 = "e202102251931481", Cookie = "_MHYUUID=da162798-8797-4bb3-8646-c9f1dcfd1102; mi18nLang=zh-tw; ltoken=gd70hGOIOnIWdCPn97Rlec9HLYvVjg0iJLC3ko2t; ltuid=26393837; cookie_token=JKqsYnEVcmhu3bMElzvWIRZKROLxRdZ8QhuOKzy6; account_id=26393837"},
            };
        }
    }
}