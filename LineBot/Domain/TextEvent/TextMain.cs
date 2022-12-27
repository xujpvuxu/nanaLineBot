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
        private static List<(string pattern, Type type)> Patterns = null;

        public void Result(WebhookEventDto eventObject)
        {
            if (!string.IsNullOrEmpty(eventObject.Message.Text))
            {
                if (Patterns == null)
                {
                    GetPatterns(eventObject);
                }

                // 選擇跟當前NameSpace相同的class後並執行
                Patterns.AsParallel().ForAll(p =>
                {
                    if (Regex.IsMatch(eventObject.Message.Text, p.pattern))
                    {
                        ((ITextEvent)Activator.CreateInstance(p.type, new object[] { eventObject })).Result();
                    }
                });
            }
        }

        private void GetPatterns(WebhookEventDto eventObject)
        {
            // 當前NameSpace
            string currentNameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;

            Patterns = Assembly.GetExecutingAssembly()
                                   .GetTypes()
                                   .Where(t => t.Namespace == currentNameSpace
                                            && !t.IsNested
                                            && t.IsClass
                                            && !t.Name.EndsWith("Main"))
                                   .Select(type => (
                                           ((ITextEvent)Activator.CreateInstance(type, new object[] { eventObject })).Pattern,
                                           type))
                                   .ToList();
        }
    }
}