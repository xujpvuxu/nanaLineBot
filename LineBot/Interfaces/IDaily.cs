using LineBot.DTO.Webhook;

namespace LineBot.Interfaces
{
    public interface IGarageplay
    {
        string Uri { get; }
        string GetMovieDetail();
    }
}