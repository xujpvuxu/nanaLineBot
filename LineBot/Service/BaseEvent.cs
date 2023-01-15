using LineBot.DTO.Webhook;
using System.Diagnostics;
using System.Reflection;

namespace LineBot.Service
{
    public class BaseEvent
    {
        /// <summary>
        /// 找所有類別為 nameSpace.{事件名稱}EventSpace 的類別
        /// </summary>
        /// <param name="eventType"></param>
        /// <returns></returns>
        private protected IEnumerable<Type> GetEventClasses(string eventType)
        {
            StackTrace stackTrace = new StackTrace(true);
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();
            string fatherNameSpace = methodBase.DeclaringType.Namespace;

            return Assembly.GetExecutingAssembly()
                                   .GetTypes()
                                   .Where(t => t.Namespace == $"{fatherNameSpace}.{eventType.ToTitleText()}EventSpace"
                                            && !t.IsNested);
        }
    }
}