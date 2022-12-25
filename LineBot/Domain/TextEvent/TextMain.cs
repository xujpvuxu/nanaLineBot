using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Reflection;
using System.Text.RegularExpressions;

namespace LineBot.Domain.TextEvent
{
    public class TextMain : IType
    {
        public void Result(WebhookEventDto eventObject)
        {
            if (!string.IsNullOrEmpty(eventObject.Message.Text))
            {
                // 當前NameSpace
                string currentNameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;

                // 選擇跟當前NameSpace相同的class後並執行
                foreach (ITextEvent type in Assembly.GetExecutingAssembly().GetTypes()
                                                    .Where(t => t.IsClass
                                                             && t.Namespace == currentNameSpace
                                                             && !t.IsNested
                                                             && !t.Name.EndsWith("Main")
                                                             )
                                                    .Select(data => Activator.CreateInstance(data, new object[] { eventObject }))
                                                    .OfType<ITextEvent>())
                {
                    if (Regex.IsMatch(eventObject.Message.Text, type.Pattern))
                    {
                        type.Result();
                    }
                }
            }
        }
    }
}