
using LineBot.Domain.MessageEventSpace.Daily.Model;
using LineBot.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LineBot.Domain.MessageEventSpace.Daily.Sub
{
    public class Bh3 : IDaily
    {
        public string Uri { get; set; } = "https://sg-public-api.hoyolab.com/event/mani/sign?lang=zh-tw";

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
                string _ = response.Content.ReadAsStringAsync().Result;
            }
        }

        private List<DailyLoging> GetModel()
        {
            return new List<DailyLoging>
            {
                new DailyLoging{ Name="毛毛" , Other1 = "e202110291205111", Cookie = "G_AUTHUSER_H=0; _MHYUUID=da162798-8797-4bb3-8646-c9f1dcfd1102; mi18nLang=zh-tw; G_ENABLED_IDPS=google; ltoken=14h7mJpvzfoDgmWVVvwqAJS6gc4SbtWR8iw5TTEC; ltuid=179489324; cookie_token=D0NNZ3f0d5sdKVf6prGDqZ9rV0VuWTXGVoNqVs3t; account_id=179489324"},
                new DailyLoging{ Name="腳腳", Other1 = "e202110291205111", Cookie = "_MHYUUID=da162798-8797-4bb3-8646-c9f1dcfd1102; mi18nLang=zh-tw; ltoken=AuIraKpCqqTmzyUYNFXsZSeqITBS52Tyh5YwC4xO; ltuid=11205767; cookie_token=0NVSpiTQNmksuFofcpsKolZE1Thyzanevi3QIa8s; account_id=11205767"},
                new DailyLoging{ Name="海參", Other1 = "e202110291205111", Cookie = "mi18nLang=zh-tw; _MHYUUID=65ff80f5-94f4-43f3-aca5-a2cff1ba1981; ltuid=150443054; _ga_524XFD81V5=GS1.1.1651210785.1.0.1651210785.0; DEVICEFP_SEED_ID=205a16bc50922b58; DEVICEFP_SEED_TIME=1663432919804; _ga_54PBK3QDF4=GS1.1.1663432932.2.0.1663432935.0.0.0; DEVICEFP=38d7eca45900d; ltoken=KoM30kMs8jfDSMBZBnRkxdnBIwbAvQqIjETJ4689; cookie_token=30yMzSuHlHSB84saHUY7x26mXMimqRIYLKw9SYOZ; account_id=150443054; _ga_JTLS2F53NR=GS1.1.1678898314.1.1.1678898500.0.0.0; _ga_27EG203DM0=GS1.1.1678959792.1.1.1678959797.0.0.0; _ga_JRFG0HQ22J=GS1.1.1678959795.13.1.1678960227.0.0.0; _gid=GA1.2.1223216308.1679067932; _gat=1; _ga=GA1.2.179876109.1650818170; _gat_gtag_UA_200790024_1=1; _ga_45QSFFBGJT=GS1.1.1679068111.27.0.1679068116.0.0.0"},
             };
        }
    }
}