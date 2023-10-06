using LineBot.Domain.MessageEventSpace.Daily.Model;
using LineBot.Interfaces;
using LineBot.Service.MessageEventSpace.Daily.Movie;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LineBot.Domain.MessageEventSpace.Daily.Sub
{
    public class MagicHour : BaseMagicHour, IDaily
    {
        public string Uri { get; set; }

        public void GetDailyGift()
        {
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.32.2");
            foreach (DailyLoging perDailyLoging in GetModel())
            {
                //FormData參數
                MultipartFormDataContent sentMultiData = new MultipartFormDataContent
                {
                   { new StringContent(perDailyLoging.Other1), "member_id" },
                   { new StringContent("checkin"), "source" },
                };

                HttpResponseMessage response = Client.PostAsync(perDailyLoging.Uri, sentMultiData).Result;
                string responseContent = response.Content.ReadAsStringAsync().Result;
            }
        }

        private List<DailyLoging> GetModel()
        {
            return new List<DailyLoging>
            {
                new DailyLoging{ Other1 = "2774889da3fd3f641fc95cdb2048073a", Uri = "https://garageplay.tw/api/chat_points/d5ac38abde48dd848f9f17de15bb9dfa" },
                new DailyLoging{ Other1 = "4cea20cc4ed45f3c57ff9d3fe12aa8f0", Uri = "https://garageplay.tw/api/chat_points/5ab6953ccafcad78924b59589afc9122" },
                new DailyLoging{ Other1 = "da899c96f0aec5e81fd9a44116d73c14", Uri = "https://garageplay.tw/api/chat_points/3f92826c17326b28bd13ec97e2716287" },
             };
        }
    }
}