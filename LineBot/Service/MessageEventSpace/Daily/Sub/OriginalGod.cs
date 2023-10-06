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
                new DailyLoging{ Other1 = "e202102251931481", Cookie = "_MHYUUID=867ed1cc-a018-4b31-8005-b6b5bc8dd50b; DEVICEFP_SEED_ID=6f69defa597ec020; DEVICEFP_SEED_TIME=1658464698726; _ga_JRFG0HQ22J=GS1.1.1676749687.3.0.1676749813.0.0.0; ltoken=AuIraKpCqqTmzyUYNFXsZSeqITBS52Tyh5YwC4xO; ltuid=11205767; account_mid_v2=1x1vh1qbv8_hy; account_id_v2=11205767; mi18nLang=zh-tw; _ga_45QSFFBGJT=GS1.1.1685965604.1.1.1685965687.0.0.0; cookie_token_v2=v2_CAQSDGNlMXRidXdiMDB6axokNDdjMGRjZGUtZjg5MC00Njc0LThkMDctYmQyNGNjMzMwMDM1ILax1qQGKKK_jO4DMIf5qwU=; DEVICEFP=38d7ede9e7a87; _ga_Y5SZ86WZQH=GS1.1.1688320813.4.1.1688320824.0.0.0; _ga_SBYZMHZRMJ=GS1.1.1688320813.4.1.1688320824.0.0.0; _gid=GA1.2.1241947568.1689947810; _ga=GA1.1.295364921.1648644962; _ga_54PBK3QDF4=GS1.1.1689947809.1.1.1689947917.0.0.0; _gat_gtag_UA_201411121_1=1; _ga_T9HTWX7777=GS1.1.1689947809.1.1.1689947917.0.0.0"},
            };
        }
    }
}