using LineBot.Domain;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using LineBot.ExcelModel;

namespace LineBot.Domain.MessageEventSpace
{
    public class CatIndex : BaseResponse, IMessageEventSpace
    {
        private string SheetId = "1sV2UFlX5K2hM9Jat8roymkAs6zWwPOTf8zugJS2xwOc";

        public CatIndex(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = "^Ticket$";

        public void Result()
        {
            // 從 Google Sheet 取回資料
            StaticFuntion.GetExcel<NormalDAO>(SheetId, "CatTicket");
            
            // 將資料寫入 Normal 的 Model 中
            List<string> data = NormalDAO.Normal.ToList();
            var numberedData = data.Select((item, index) => $"{index + 1}. {item}");
            string result = string.Join(Environment.NewLine, numberedData);

            ReplyText(result);
        }
    }
}
