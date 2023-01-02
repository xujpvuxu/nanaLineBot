using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class SnowPicture : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = "抽.*?踏雪";
        private static List<string> SnowPictures = new List<string>();
        private string SnowPictureUri = @"https://docs.google.com/spreadsheets/d/1scvzcNs5-manr9I3kTQWh1GDe-R_2XR2Eu7OArc6d2o/edit";

        public SnowPicture(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (!SnowPictures.Any())
            {
                SnowPictures = StaticFuntion.GetExcelDatas(SnowPictureUri, @"https://i[\.]imgur[\.]com/.*?[\.]jpg");
            }

            new NanaPicture(EventObject).ReplyPicture(SnowPictures);
        }
    }
}