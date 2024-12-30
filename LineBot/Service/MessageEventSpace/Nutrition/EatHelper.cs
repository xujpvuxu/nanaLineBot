using LineBot.Domain.MessageEventSpace.Base;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.MessageEventSpace
{
    public class EatHelper : BasePicture, IMessageEventSpace
    {
        public EatHelper(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = $@"zzHelper";

        public void Result()
        {
            ReplyText($"zz 份數 熱量(Kcl) 蛋白質(g) 碳水化合物(g) 鈉(mg)");
        }
    }
}