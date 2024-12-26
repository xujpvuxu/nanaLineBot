using LineBot.ExcelModel;
using LineBot.Domain.MessageEventSpace.Base;
using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.MessageEventSpace
{
    public class SnowPicture : BasePicture, IMessageEventSpace
    {
        public string Pattern { get; set; } = "^抽.*?踏雪$";

        public SnowPicture(WebhookEventDto eventObject) : base(eventObject)
        {
            SheetID = "1U7PDQJDnJTyX6Y-kbfEqI5IaT2a0sM3qYrXi96iAGaA";
            SheetWorkName = "Snow";
        }

        public void Result()
        {
            (bool isPicture, string replyMessge) = IsGetPicture(SevenPicturesDAO.SnowPicture, SheetID, SheetWorkName);
            SendPicture(isPicture, replyMessge, SevenPicturesDAO.SnowPicture);
        }
    }
}