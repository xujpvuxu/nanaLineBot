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
    public class LineBotService
    {
        public void ReceiveWebhook(WebhookRequestBodyDto requestBody)
        {
            foreach (WebhookEventDto eventObject in requestBody.Events)
            {
                if (TypeDictionary.TryGetValue(eventObject.Type, out IType type))
                {
                    type.Result(eventObject);
                }
            }
        }

        private Dictionary<string, IType> TypeDictionary = new Dictionary<string, IType>
        {
            { "message", new TextMain() },
        };
    }
}