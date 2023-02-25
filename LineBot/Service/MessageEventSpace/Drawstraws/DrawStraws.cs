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

        private static List<(string describe, bool isPostive)> Lots = new List<(string, bool)>();

        public void Result()
        {
            if (!Lots.Any())
            {
                StaticFuntion.GetExcel<CardDAO>(SheetID, SheetWorkName);
                Lots = LotTypes().SelectMany(data => Enumerable.Repeat((data.describe, data.isPostive), data.count))
                                 .ToList();
            }

            (string describe, bool isPostive) lot = Lots.GetRandomOne();

            string resultLot = (lot.isPostive) ?
                                    CardDAO.PostiveEnergys.GetRandomOne() :
                                    CardDAO.NegitiveEnergys.GetRandomOne();

            ReplyText(new List<string> { lot.describe, resultLot });
        }

        /// <summary>
        /// 抽籤個數
        /// </summary>
        /// <returns></returns>
        private List<(int count, string describe, bool isPostive)> LotTypes()
        {
            return new List<(int, string, bool)>
                    {
                        (3, "大吉", true),
                        (10, "上上", true),
                        (13, "上吉", true),
                        (1, "上平", true),
                        (9, "中吉", true),
                        (36, "中平", true),
                        (1, "中中", false),
                        (27, "下下", false),
                    };
        }
    }
}