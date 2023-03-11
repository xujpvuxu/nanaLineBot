using LineBot.DAO;
using LineBot.Domain.MessageEventSpace.Base;
using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.MessageEventSpace
{
    public class NanaPicture : BasePicture, IMessageEventSpace
    {
        public string Pattern { get; set; } = "^抽.*?娜娜";

        public NanaPicture(WebhookEventDto eventObject) : base(eventObject)
        {
            SheetID = "1U7PDQJDnJTyX6Y-kbfEqI5IaT2a0sM3qYrXi96iAGaA";
            SheetWorkName = "Seven";
        }

        public void Result()
        {
            (bool isPicture, string replyMessge) = IsGetPicture(SevenPicturesDAO.NanaPicture, SheetID, SheetWorkName);
            SendPicture(isPicture, replyMessge, SevenPicturesDAO.NanaPicture);
        }
    }
}