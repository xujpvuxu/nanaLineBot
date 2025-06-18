using LineBot.Domain;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using LineBot.ExcelModel;

namespace LineBot.Domain.MessageEventSpace
{
    public class MouseIndex : BaseResponse, IMessageEventSpace
    {
        private string SheetId = "1jTchAMN4sLJQlR5RCJiYh7lxCuf52_0mP_gIv-k3P14";

        public MouseIndex(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = "^MTicket$";

        public void Result()
        {
            // 從 Google Sheet 取回資料
            StaticFuntion.GetExcel<NormalDAO>(SheetId, "Ticket");
            
            // 將資料寫入 Normal 的 Model 中
            List<string> data = NormalDAO.Normal.ToList();
            var numberedData = data.Select((item, index) => $"{index + 1}. {item}");
            string result = string.Join(Environment.NewLine, numberedData);

            ReplyText(result);
        }
    }
}
