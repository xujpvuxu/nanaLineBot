using LineBot.DAO;
using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.TextEvent
{
    public class NanaPicture : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = "抽.*?娜娜";

        private string NanaPicuteUri = "https://docs.google.com/spreadsheets/d/1U7PDQJDnJTyX6Y-kbfEqI5IaT2a0sM3qYrXi96iAGaA/edit";

        public NanaPicture(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (!SevenPicturesDAO.NanaPicture.Any())
            {
                StaticFuntion.GetExcel<SevenPicturesDAO>(NanaPicuteUri);
            }
            ReplyImage(SevenPicturesDAO.NanaPicture.ToRandom().First());
        }
    }
}