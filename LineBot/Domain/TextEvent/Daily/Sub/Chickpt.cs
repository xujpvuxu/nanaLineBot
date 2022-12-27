using LineBot.Domain.TextEvent.Daily.Model;
using LineBot.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LineBot.Domain.TextEvent.Daily.Sub
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
                    Other1 = "BB49A429-08EC-4254-9AFB-6A8DACD2ABF6",
                    Other2 = "2010059",
                    Other3 = "eyJpdiI6IlorTFZvaDBoUlwvdDZRMjNyblM1bDhnPT0iLCJ2YWx1ZSI6InZCcjJMdFprMnEwakh1cTVmOGxNV2lpbFY1WGE0Y3ZkaXY0a2RJSjIxUUk9IiwibWFjIjoiNzFhMzRlNDFiNTg3YjNjMTU1MjYxNWI2ZDYwNWYxODZmMmVlODg5OTA0MTY4OTllN2EyOTlkZDUwNjgwNTY5NyJ9",
                }
            };
        }
    }
}