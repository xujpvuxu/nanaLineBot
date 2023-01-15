using LineBot.Domain.MessageEventSpace;
using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Enums;
using LineBot.Interfaces;
using LineBot.Models;
using LineBot.Providers;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace LineBot.Domain
{
    public class LineBotService
    {
        private static Dictionary<string, IType> TypeDictionary = new Dictionary<string, IType>();

        /// <summary>
        /// 接收事件後 按照不同的事件進行處理
        /// </summary>
        /// <param name="requestBody"></param>
        public void ReceiveWebhook(WebhookRequestBodyDto requestBody)
        {
            foreach (WebhookEventDto eventObject in requestBody.Events)
            {
                if (!TypeDictionary.TryGetValue(eventObject.Type, out IType type))
                {
                    // 目前事件有 message,unsend follow.unfollow.join.leave
                    try
                    {
                        // 嘗試取得 是否有{事件名稱}Event 的類別
                        Type eventType = Type.GetType($"{MethodBase.GetCurrentMethod().DeclaringType.Namespace}.{eventObject.Type.ToTitleText()}Event");
                        type = (IType)Activator.CreateInstance(eventType);
                    }
                    catch
                    {
                        // 此未實作的物件
                        type = new NoneEvent();
                    }

                    TypeDictionary.Add(eventObject.Type, type);
                }

                // 執行事件 {事件名稱}Event 的class
                type.Result(eventObject);
            }
        }
    }
}