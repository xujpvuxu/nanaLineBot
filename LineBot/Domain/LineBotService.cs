using LineBot.Domain.TextEvent;
using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Enums;
using LineBot.Interfaces;
using LineBot.Providers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;

namespace LineBot.Domain
{
    public class LineBotService //: ILineBotService
    {
        // (將 LineBotController 裡宣告的 ChannelAccessToken & ChannelSecret 移到 LineBotService中)
        // 貼上 messaging api channel 中的 accessToken & secret
        //private readonly string channelAccessToken = @"U9c8zlj7hqd3YyukRsgHHjE6GI3hoRzrchGTgUnVpLzHYw7dnW/XeRamUzm5Xjfr2MiGssJRxrYweRtmvVS83kswfEMrHIKeOUbWwagAkgTpJibXdZtmy/V0S4S9qXgN6cXx3pcMLJGuN9gCXUs/0wdB04t89/1O/w1cDnyilFU=";

        //private readonly string channelSecret = @"a61cfe69fd532111edfd30935277c8d6";

        //private readonly string replyMessageUri = "https://api.line.me/v2/bot/message/reply";
        private readonly string broadcastMessageUri = "https://api.line.me/v2/bot/message/broadcast";
        //private static HttpClient client = new HttpClient(); // 負責處理HttpRequest
        //private readonly JsonProvider _jsonProvider = new JsonProvider();

        public void ReceiveWebhook(WebhookRequestBodyDto requestBody, string hostUri)
        {
            foreach (WebhookEventDto eventObject in requestBody.Events)
            {
                if (TypeDictionary.TryGetValue(eventObject.Type, out IType type))
                {
                    type.Result(eventObject, hostUri);
                } 
                //switch (eventObject.Type)
                //{
                //    case WebhookEventTypeEnum.Message:

                //        string messag = $@"{hostUri}/UploadFiles/LINE_ALBUM_2020-2022_221224.jpg";
                //        var replyMessage = new ReplyMessageRequestDto<ImageMessageDto>()
                //        {
                //            ReplyToken = eventObject.ReplyToken,
                //            Messages = new List<ImageMessageDto>
                //            {
                //                new ImageMessageDto
                //                {
                //                    PreviewImageUrl = messag,
                //                    OriginalContentUrl=messag
                //                }
                //            }
                //        };

                //        //var replyMessage = new ReplyMessageRequestDto<TextMessageDto>()
                //        //{
                //        //    ReplyToken = eventObject.ReplyToken,
                //        //    Messages = new List<TextMessageDto>
                //        //    {
                //        //        new TextMessageDto(){Text = $"您好，您傳送了\"{eventObject.Message.Text}\"!"},
                //        //        new TextMessageDto(){Text = $"15!"},

                //        //    }
                //        //};
                //        ReplyMessageHandler("text", replyMessage);
                //        break;

                //    case WebhookEventTypeEnum.Unsend:
                //        Console.WriteLine($"使用者{eventObject.Source.UserId}在聊天室收回訊息！");
                //        break;

                //    case WebhookEventTypeEnum.Follow:
                //        Console.WriteLine($"使用者{eventObject.Source.UserId}將我們新增為好友！");
                //        break;

                //    case WebhookEventTypeEnum.Unfollow:
                //        Console.WriteLine($"使用者{eventObject.Source.UserId}封鎖了我們！");
                //        break;

                //    case WebhookEventTypeEnum.Join:
                //        Console.WriteLine("我們被邀請進入聊天室了！");
                //        break;

                //    case WebhookEventTypeEnum.Leave:
                //        Console.WriteLine("我們被聊天室踢出了");
                //        break;
                //}
            }
        }

        //public void BroadcastMessageHandler(string messageType, object requestBody)
        //{
        //    string strBody = requestBody.ToString();
        //    switch (messageType)
        //    {
        //        case MessageTypeEnum.Text:
        //            var messageRequest = _jsonProvider.Deserialize<BroadcastMessageRequestDto<TextMessageDto>>(strBody);
        //            BroadcastMessage(messageRequest);
        //            break;

        //        case MessageTypeEnum.Image:
        //            var emessageRequest = _jsonProvider.Deserialize<BroadcastMessageRequestDto<ImageMessageDto>>(strBody);
        //            break;
        //    }
        //}

        /// <summary>
        /// 將廣播訊息請求送到 Line
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        //public async void BroadcastMessage<T>(BroadcastMessageRequestDto<T> request)
        //{
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelAccessToken); //帶入 channel access token
        //    var json = _jsonProvider.Serialize(request);
        //    var requestMessage = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(broadcastMessageUri),
        //        Content = new StringContent(json, Encoding.UTF8, "application/json")
        //    };

        //    var response = await client.SendAsync(requestMessage);
        //    Console.WriteLine(await response.Content.ReadAsStringAsync());
        //}

        /// <summary>
        /// 接收到回覆請求時，在將請求傳至 Line 前多一層處理(目前為預留)
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="requestBody"></param>
        //public void ReplyMessageHandler<T>(string messageType, ReplyMessageRequestDto<T> requestBody)
        //{
        //    ReplyMessage(requestBody);
        //}

        /// <summary>
        /// 將回覆訊息請求送到 Line
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        //public async void ReplyMessage<T>(ReplyMessageRequestDto<T> request)
        //{
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelAccessToken); //帶入 channel access token
        //    string json = _jsonProvider.Serialize(request);
        //    HttpRequestMessage requestMessage = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(replyMessageUri),
        //        Content = new StringContent(json, Encoding.UTF8, "application/json")
        //    };

        //    var response = await client.SendAsync(requestMessage);
        //    Console.WriteLine(await response.Content.ReadAsStringAsync());
        //}

        private Dictionary<string, IType> TypeDictionary = new Dictionary<string, IType>
        {
            { "message", new TextMain() },
            { "unsend", new TextMain() },
            { "follow", new TextMain() },
            { "unfollow", new TextMain() },
            { "join", new TextMain() },
            { "leave", new TextMain() },
        };
    }
}