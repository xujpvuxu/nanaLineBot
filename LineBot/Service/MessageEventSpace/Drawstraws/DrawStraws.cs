using LineBot.DAO;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.MessageEventSpace
{
    public class DrawStraws : BaseResponse, IMessageEventSpace, IGoogleSheet
    {
        //private string NegativeEnergyUri = @"https://docs.google.com/spreadsheets/d/134R97lsH4h9Z7oOXOlBt5QPa0BNZT7RULU3aJidQFfI/edit";

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
                if (!CardDAO.NegitiveEnergys.Any())
                {
                    StaticFuntion.GetExcel<CardDAO>(SheetID, SheetWorkName);
                }

                Lots = LotTypes().SelectMany(data => Enumerable.Repeat(data.type, data.count))
                                 .ToList();
            }

            ReplyText(new List<string> { Lots.GetRandomOne(), CardDAO.NegitiveEnergys.GetRandomOne() });
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