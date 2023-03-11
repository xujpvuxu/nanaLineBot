using LineBot;
using LineBot.DAO;
using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.MessageEventSpace.Base
{
    public class BasePicture : BaseResponse, IGoogleSheet
    {
        public string SheetID { get; set; }

        public string SheetWorkName { get; set; }
        private static Dictionary<string, int> Collections = new Dictionary<string, int>();
        private static int Limit = 8;
        private static List<int> Dices = Enumerable.Range(1, Limit).ToList();


        public BasePicture(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public (bool, string) IsGetPicture(List<string> pictures, string sheetID, string sheetWorkName)
        {
            bool result = false;
            if (!Collections.TryGetValue(EventObject.Source.UserId, out int collect))
            {
                Collections.Add(EventObject.Source.UserId, collect);
            }

            int nowCollect = Dices.GetRandomOne() + collect;

            if (nowCollect >= Limit)
            {
                if (!pictures.Any())
                {
                    StaticFuntion.GetExcel<SevenPicturesDAO>(sheetID, sheetWorkName);
                }
                nowCollect = nowCollect - Limit;
                result = true;
            }

            Collections[EventObject.Source.UserId] = nowCollect;
            return (result, $"集點卡：{nowCollect}/{Limit}");
        }

        public void SendPicture(bool isPicture, string replyMessge, List<string> pictures)
        {
            List<string> result = new List<string> ();
            if (isPicture)
            {
                result.Add(pictures.GetRandomOne());
                ReplyImage(result);
            }
            else
            {
                result.Add(replyMessge);
                ReplyText(result);
            }
            
        }
    }
}