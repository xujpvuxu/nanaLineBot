using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using LineBot.Service;
using System.Reflection;
using System.Text.RegularExpressions;

namespace LineBot.Domain
{
    public class MessageEvent : BaseEvent, IType
    {
        private static List<(string pattern, Type type)> Patterns = new List<(string pattern, Type type)>();

        /// <summary>
        /// 執行事件
        /// </summary>
        /// <param name="eventObject"></param>
        public void Result(WebhookEventDto eventObject)
        {
            if (!string.IsNullOrEmpty(eventObject.Message.Text))
            {
                if (!Patterns.Any())
                {
                    Patterns = GetEventClasses(eventObject.Type)
                                    .Select(type => (
                                        ((IMessageEventSpace)Activator.CreateInstance(type, new object[] { eventObject })).Pattern,
                                        type))
                                    .ToList();
                }

                Patterns.AsParallel().ForAll(perClass =>
                {
                    if (Regex.IsMatch(eventObject.Message.Text, perClass.pattern))
                    {
                        ((IMessageEventSpace)Activator.CreateInstance(perClass.type, new object[] { eventObject })).Result();
                    }
                });
            }
        }
    }
}