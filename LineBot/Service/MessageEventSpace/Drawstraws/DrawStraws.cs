using LineBot.DAO;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.MessageEventSpace
{
    public class DrawStraws : BaseResponse, IMessageEventSpace, IGoogleSheet
    {
        public DrawStraws(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = "^抽籤$";

        public string SheetID => @"134R97lsH4h9Z7oOXOlBt5QPa0BNZT7RULU3aJidQFfI";

        public string SheetWorkName => @"Negitive";

        private static List<string> Lots = new List<string>();

        public void Result()
        {
            if (!Lots.Any())
            {
                StaticFuntion.GetExcel<CardDAO>(SheetID, SheetWorkName);
                Lots = LotTypes().SelectMany(data => Enumerable.Repeat(data.type, data.count))
                                 .ToList();
            }

            int hour = DateTime.Now.Hour;

            string resultLot = (hour % 2 == 1) ?
                                    CardDAO.PostiveEnergys.GetRandomOne() :
                                    CardDAO.NegitiveEnergys.GetRandomOne();

            ReplyText(new List<string> { Lots.GetRandomOne(), resultLot });
        }

        /// <summary>
        /// 抽籤個數
        /// </summary>
        /// <returns></returns>
        private List<(int count, string type)> LotTypes()
        {
            return new List<(int count, string type)>
                    {
                        (3, "大吉"),
                        (10,"上上"),
                        (13,"上吉"),
                        (1, "上平"),
                        (9 ,"中吉"),
                        (36,"中平"),
                        (1 ,"中中"),
                        (27,"下下"),
                    };
        }
    }
}