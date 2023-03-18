using LineBot.DTO.Webhook;

namespace LineBot.Interfaces
{
    public interface IDaily
    {
        string Uri { get; set; }

        void GetDailyGift();
    }
}