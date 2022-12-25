using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Providers;
using System.Net.Http.Headers;
using System.Text;

namespace LineBot.Domain
{
    public class BaseResponse
    {
        private readonly string channelAccessToken = @"U9c8zlj7hqd3YyukRsgHHjE6GI3hoRzrchGTgUnVpLzHYw7dnW/XeRamUzm5Xjfr2MiGssJRxrYweRtmvVS83kswfEMrHIKeOUbWwagAkgTpJibXdZtmy/V0S4S9qXgN6cXx3pcMLJGuN9gCXUs/0wdB04t89/1O/w1cDnyilFU=";

        private readonly string channelSecret = @"a61cfe69fd532111edfd30935277c8d6";

        private readonly string replyMessageUri = "https://api.line.me/v2/bot/message/reply";

        private readonly JsonProvider _jsonProvider = new JsonProvider();
        public WebhookEventDto EventObject { get; set; }

        public void ReplyText(string text) => ReplyText(new List<string> { text });

        public BaseResponse(WebhookEventDto eventObject)
        {
            EventObject = eventObject;
        }

        public void ReplyText(List<string> text)
        {
            var replyMessage = new ReplyMessageRequestDto<TextMessageDto>(EventObject);
            text.ForEach(x => replyMessage.Messages.Add(new TextMessageDto { Text = x }));
            ReplyMessageHandler("text", replyMessage);
        }

        public void ReplyImage(string uri) => ReplyImage(new List<string> { uri });

        public void ReplyImage(List<string> uries)
        {
            var replyMessage = new ReplyMessageRequestDto<ImageMessageDto>(EventObject);
            uries.ForEach(x => replyMessage.Messages.Add(new ImageMessageDto { OriginalContentUrl = x, PreviewImageUrl = x, }));
            ReplyMessageHandler("text", replyMessage);
        }

        /// <summary>
        /// 接收到回覆請求時，在將請求傳至 Line 前多一層處理(目前為預留)
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="requestBody"></param>
        private void ReplyMessageHandler<T>(string messageType, ReplyMessageRequestDto<T> requestBody)
        {
            ReplyMessage(requestBody);
        }

        /// <summary>
        /// 將回覆訊息請求送到 Line
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        public async void ReplyMessage<T>(ReplyMessageRequestDto<T> request)
        {
            HttpClient client = new HttpClient(); // 負責處理HttpRequest
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelAccessToken); //帶入 channel access token
            string json = _jsonProvider.Serialize(request);
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(replyMessageUri),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(requestMessage);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}