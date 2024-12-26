using LineBot.ExcelModel;
using LineBot.Domain.MessageEventSpace.Base;
using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.MessageEventSpace
{
    public class FishPicture : BasePicture, IMessageEventSpace
    {
        public string Pattern { get; set; } = "^鮭魚$";

        public FishPicture(WebhookEventDto eventObject) : base(eventObject)
        {
            SheetID = "1U7PDQJDnJTyX6Y-kbfEqI5IaT2a0sM3qYrXi96iAGaA";
            SheetWorkName = "Fish";
        }

        public void Result()
        {
            (bool isPicture, string replyMessge) = IsGetPicture(SevenPicturesDAO.FishPicture, SheetID, SheetWorkName,false);
            SendPicture(isPicture, replyMessge, SevenPicturesDAO.FishPicture);
        }
    }
}