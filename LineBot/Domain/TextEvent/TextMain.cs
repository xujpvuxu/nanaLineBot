using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.TextEvent
{
    public class TextMain : IType
    {
        public void Result(WebhookEventDto eventObject, string hostUri)
        {
            if (!string.IsNullOrEmpty(eventObject.Message.Text))
            {
                if (Regex.IsMatch(eventObject.Message.Text, @"抽.*?娜娜"))
                {
                    new NanaResponsePicture().Result(eventObject,Const.NanaPictures, hostUri);
                }
                else if (Regex.IsMatch(eventObject.Message.Text, @"抽.*?踏雪"))
                {
                    new NanaResponsePicture().Result(eventObject, Const.SnowPictures,hostUri);
                }
            }
        }
    }
}