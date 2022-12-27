using LineBot.Domain.TextEvent.Daily.Model;
using LineBot.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LineBot.Domain.TextEvent.Daily.Sub
{
    public class Agentm : IDaily
    {
        public string Uri { get; set; } = "https://api.agentm.tw/v1/login";

        public void GetDailyGift()
        {
            HttpClient client = new HttpClient();
            foreach (DailyLoging perDailyLoging in GetModel())
            {
                //FormData參數
                MultipartFormDataContent sentMultiData = new MultipartFormDataContent
                {
                   { new StringContent(perDailyLoging.Other1), "device_id" },
                   { new StringContent(perDailyLoging.Other2), "email" },
                   { new StringContent(perDailyLoging.Other3), "passwd" },
                };

                HttpResponseMessage response = client.PostAsync(perDailyLoging.Uri, sentMultiData).Result;
                string _ = response.Content.ReadAsStringAsync().Result;
            }
        }

        private List<DailyLoging> GetModel()
        {
            return new List<DailyLoging>
            {
                new DailyLoging
                {
                    Other1 = "D20D4749-C934-414B-AEBF-BA170D96D422",
                    Other2 = "xujpvuxu2332@gmail.com",
                    Other3 = "Michael1220",
                }
            };
        }
    }
}