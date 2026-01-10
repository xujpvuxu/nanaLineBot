using LineBot.Domain;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using LineBot.ExcelModel;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using LineBot.Models;
using System.Text.RegularExpressions;

namespace LineBot.Domain.MessageEventSpace
{
    public class AIIndex : BaseResponse, IMessageEventSpace
    {
        public AIIndex(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = ".*";
        public static bool IsAIStarted = false;

        public void Result()
        {
            string apiKey = "";
            string url = "https://api.groq.com/openai/v1/chat/completions";

            string input = EventObject.Message.Text;
            if (input == "AI")
            {
                IsAIStarted = !IsAIStarted;
                if (IsAIStarted)
                {
                    ReplyText("開始AI");
                }
                else
                {
                    ReplyText("結束AI");
                }
            }
            if (IsAIStarted)
            {
                string result = string.Empty;
                using (HttpClient client = new HttpClient())
                {
                    var requestBody = new
                    {
                        model = "llama-3.3-70b-versatile",
                        messages = new[]
                        {
                        new { role = "system", content = "你的名字是鼠崽，回答的時候，文字請在30個字以內，並用繁體中文顯示" },
                        new { role = "user", content = EventObject.Message.Text }
                    },
                        temperature = 0.9
                    };

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                    string json = JsonSerializer.Serialize(requestBody);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {
                        HttpResponseMessage response = client.PostAsync(url, content).Result;
                        AIResponse res = JsonSerializer.Deserialize<AIResponse>(response.Content.ReadAsStringAsync().Result);
                        result = string.Join(",", res.choices.Select(x => x.message.content));
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                    }
                }

                ReplyText(result);
            }
        }
    }
}