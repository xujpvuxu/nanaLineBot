using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Models
{
    public class NoneEvent : IType
    {
        public void Result(WebhookEventDto eventObject)
        {
        }
    }
}