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
                    Other1 = "BB49A429-08EC-4254-9AFB-6A8DACD2ABF6",
                    Other2 = "2010059",
                    Other3 = "eyJpdiI6IlorTFZvaDBoUlwvdDZRMjNyblM1bDhnPT0iLCJ2YWx1ZSI6InZCcjJMdFprMnEwakh1cTVmOGxNV2lpbFY1WGE0Y3ZkaXY0a2RJSjIxUUk9IiwibWFjIjoiNzFhMzRlNDFiNTg3YjNjMTU1MjYxNWI2ZDYwNWYxODZmMmVlODg5OTA0MTY4OTllN2EyOTlkZDUwNjgwNTY5NyJ9",
                },
                new DailyLoging
                {
                    Other1 = "E00B5997-748A-42C6-981C-450983405B11",
                    Other2 = "2367927",
                    Other3 = "eyJpdiI6IndOaFZHQ1kwMUR6VzM5WTZYb05qWEE9PSIsInZhbHVlIjoia3VBSHcwOCsrajY3RlFaY1JKeURsbHhqT1I4XC9ieWg2Z05OMzUrODM5cFU9IiwibWFjIjoiZGEwMWE1ODU5NzhkNGFlYzY5NDI0MWJkMzljNGRjY2MyMjlhMzgxZDM1MTYzYWVjYWJlYmM2YWQ3YWQ1MTI5MiJ9",
                }
            };
        }
    }
}