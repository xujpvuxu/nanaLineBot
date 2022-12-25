using LineBot.DTO.Webhook;

namespace LineBot.Interfaces
{
    public interface ITextEvent
    {
        string Pattern { get; set; }

        void Result();
    }
}