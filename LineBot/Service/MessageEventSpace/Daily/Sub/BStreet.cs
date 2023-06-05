using LineBot.Domain.MessageEventSpace.Daily.Model;
using LineBot.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace LineBot.Domain.MessageEventSpace.Daily.Sub
{
    public class BStreet : IDaily
    {
        public string Uri { get; set; } = "https://sg-public-api.hoyolab.com/event/luna/os/sign";

        public void GetDailyGift()
        {
            foreach (DailyLoging perDailyLoging in GetModel())
            {
                HttpClient Client = new HttpClient(new HttpClientHandler() { UseCookies = false });
                Client.DefaultRequestHeaders.Add("Cookie", perDailyLoging.Cookie);

                BStreetPostData data = new BStreetPostData
                {
                    act_id = perDailyLoging.Other1,
                    lang = perDailyLoging.Other2
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
                new DailyLoging{ Other1 = "e202303301540311", Other2="zh-tw", Cookie = "_MHYUUID=867ed1cc-a018-4b31-8005-b6b5bc8dd50b; DEVICEFP_SEED_ID=6f69defa597ec020; DEVICEFP_SEED_TIME=1658464698726; _ga_JRFG0HQ22J=GS1.1.1676749687.3.0.1676749813.0.0.0; ltoken=AuIraKpCqqTmzyUYNFXsZSeqITBS52Tyh5YwC4xO; ltuid=11205767; account_id=11205767; cookie_token_v2=v2_CAQSDGNlMXRidXdiMDB6axokNDdjMGRjZGUtZjg5MC00Njc0LThkMDctYmQyNGNjMzMwMDM1ILbG_qIGKKjei8QEMIf5qwU=; account_mid_v2=1x1vh1qbv8_hy; account_id_v2=11205767; DEVICEFP=38d7ed64fe277; mi18nLang=zh-tw; _ga=GA1.2.295364921.1648644962; _gid=GA1.2.708781570.1685964946; cookie_token=Z81atB71QtgiL5L6LWVJqYpCp5DVdSoti3aejljh; _ga_Y5SZ86WZQH=GS1.1.1685964945.2.1.1685965056.0.0.0; _gat_gtag_UA_206868027_31=1; _ga_SBYZMHZRMJ=GS1.1.1685964945.2.1.1685965056.0.0.0"},
            };
        }
    }
}