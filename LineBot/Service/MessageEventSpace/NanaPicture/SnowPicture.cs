using LineBot.DAO;
using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.MessageEventSpace
{
    public class SnowPicture : BaseResponse, IMessageEventSpace
    {
        public string Pattern { get; set; } = "^抽.*?踏雪$";
        private string SnowPictureUri = @"https://docs.google.com/spreadsheets/d/1U7PDQJDnJTyX6Y-kbfEqI5IaT2a0sM3qYrXi96iAGaA/edit";

        public SnowPicture(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (!SevenPicturesDAO.SnowPicture.Any())
            {
                StaticFuntion.GetExcel<SevenPicturesDAO>(SnowPictureUri);
            }

            ReplyImage(SevenPicturesDAO.SnowPicture.GetRandomOne());
        }
    }
}