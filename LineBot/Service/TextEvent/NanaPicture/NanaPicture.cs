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
        private static List<string> NanaPictures = new List<string>();

        public NanaPicture(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            if (!NanaPictures.Any())
            {
                NanaPictures = StaticFuntion.GetExcelDatas(NanaPicuteUri, @"https://i[\.]imgur[\.]com/.*?[\.]jpg");
            }
            ReplyPicture(NanaPictures);
        }

        public void ReplyPicture(List<string> pictures)
        {
            //// 隨機取數字
            int index = new Random().Next(pictures.Count());

            // 取得隨機路徑
            string picturePath = pictures[index];

            ReplyImage(picturePath);
        }
    }
}