using LineBot.DTO.Webhook;

namespace LineBot.Interfaces
{
    public interface IMessageEventSpace
    {
        string Pattern { get; set; }

        void Result();
    }
}