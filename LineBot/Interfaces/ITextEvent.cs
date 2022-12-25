using LineBot.DTO.Webhook;

namespace LineBot.Interfaces
{
    public interface ITextEvent
    {
        string Pattern { get; set; }

        WebhookEventDto EventObject { get; set; }

        void Result(WebhookEventDto eventObject);
    }
}