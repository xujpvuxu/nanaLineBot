using LineBot.Domain.MessageEventSpace.Daily.Model;
using LineBot.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LineBot.Domain.MessageEventSpace.Daily.Sub
{
    public class Chickpt : IDaily
    {
        public string Uri { get; set; } = "https://chickpt.com.tw/api/v2/check_in";

        public void GetDailyGift()
        {
            HttpClient client = new HttpClient();
            foreach (DailyLoging perDailyLoging in GetModel())
            {
                //FormData參數
                MultipartFormDataContent sentMultiData = new MultipartFormDataContent
                {
                   { new StringContent("201"), "task_id" },
                   { new StringContent("2"), "from" },
                   { new StringContent(perDailyLoging.Other1), "device_id" },
                   { new StringContent(perDailyLoging.Other2), "m_id" },
                   { new StringContent(perDailyLoging.Other3), "login_key" },
                };

                HttpResponseMessage response = client.PostAsync(Uri, sentMultiData).Result;
                string _ = response.Content.ReadAsStringAsync().Result;
            }
        }

        private List<DailyLoging> GetModel()
        {
            return new List<DailyLoging>
            {
                new DailyLoging
                {
                    Other1 = "92D74E07-EC2B-4A3D-AB77-DD6D569DA281",
                    Other2 = "2010059",
                    Other3 = "eyJpdiI6Ikw5V0ZTR3BaSVFCY3loSTNKdVBBaFE9PSIsInZhbHVlIjoiOTRNTVwvSlB0XC8zc0xzV1c2MllwSG41Z2VkeTJCS1wvTzE5c1NNTEhMSmYzZz0iLCJtYWMiOiI3ZDhjYWYyNWQ4ZmQxN2E1ZDY0OTQ5YmEzYzI5MjM0MGFlYzdlMjQ3NmQyMDc5MDE4ZmIxNWJlZmZjYjY0YzYxIn0=",
                }
            };
        }
    }
}