using LineBot.DAO;
using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.MessageEventSpace
{
    public class NanaPicture : BaseResponse, IMessageEventSpace, IGoogleSheet
    {
        public string Pattern { get; set; } = "^抽.*?娜娜";

        public string SheetID => "1U7PDQJDnJTyX6Y-kbfEqI5IaT2a0sM3qYrXi96iAGaA";

        public string SheetWorkName => "Seven";

        public NanaPicture(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (!SevenPicturesDAO.NanaPicture.Any())
            {
                StaticFuntion.GetExcel<SevenPicturesDAO>(SheetID, SheetWorkName);
            }
            ReplyImage(SevenPicturesDAO.NanaPicture.GetRandomOne());
        }
    }
}