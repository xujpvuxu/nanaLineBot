using LineBot.DTO.Webhook;

namespace LineBot.Interfaces
{
    public interface IGoogleSheet
    {
        string SheetID { get; }
        string SheetWorkName { get; }
    }
}