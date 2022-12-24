using LineBot.DTO.Webhook;

namespace LineBot.Interfaces
{
    public interface IType
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestBody">使用者傳送內容</param>
        /// <param name="hostUri">https網址( https://44dc-111-248-189-101.jp.ngrok.io)</param>
        void Result(WebhookEventDto eventObject, string hostUri);
    }
}
