using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class SnowPicture : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = "抽.*?踏雪";
        public WebhookEventDto EventObject { get; set; }

        public void Result(WebhookEventDto eventObject)
        {
            new NanaPicture().ReplyPicture(eventObject, SnowPictures);
            EventObject = eventObject;
        }

        private static List<string> SnowPictures = new List<string>
        {
            @"https://i.imgur.com/ZJbLvKh.jpg",
            @"https://i.imgur.com/QvTmJzg.jpg",
            @"https://i.imgur.com/PzO41MJ.jpg",
            @"https://i.imgur.com/UmmYTc0.jpg",
            @"https://i.imgur.com/MtPAyd0.jpg",
            @"https://i.imgur.com/yHgWOlE.jpg",
            @"https://i.imgur.com/dFjphyL.jpg",
            @"https://i.imgur.com/fS3uDvZ.jpg",
            @"https://i.imgur.com/9GD3n9z.jpg",
            @"https://i.imgur.com/zD4Sobk.jpg",
            @"https://i.imgur.com/D1UXf18.jpg",
            @"https://i.imgur.com/jTtK8xv.jpg",
            @"https://i.imgur.com/6FEpWgJ.jpg",
            @"https://i.imgur.com/YQG1bPT.jpg",
            @"https://i.imgur.com/DLYuDbz.jpg",
            @"https://i.imgur.com/69cpl1v.jpg",
            @"https://i.imgur.com/hP19xgh.jpg",
            @"https://i.imgur.com/9a3mgJo.jpg",
            @"https://i.imgur.com/o3NURfb.jpg",
            @"https://i.imgur.com/4kr2QVp.jpg",
            @"https://i.imgur.com/8625AL5.jpg",
            @"https://i.imgur.com/GuVmS1r.jpg",
            @"https://i.imgur.com/RTpWWt6.jpg",
            @"https://i.imgur.com/OeozMRK.jpg",
            @"https://i.imgur.com/gUtha0l.jpg",
            @"https://i.imgur.com/4CRuI2M.jpg",
            @"https://i.imgur.com/Z0lyj3C.jpg",
            @"https://i.imgur.com/vFeV9RJ.jpg",
            @"https://i.imgur.com/XNBYOua.jpg",
            @"https://i.imgur.com/L9T3xpx.jpg",
            @"https://i.imgur.com/9vioKco.jpg",
            @"https://i.imgur.com/2dMw3B1.jpg",
            @"https://i.imgur.com/li5JkQe.jpg",
            @"https://i.imgur.com/KFSf5vA.jpg",
            @"https://i.imgur.com/J4sRscL.jpg",
            @"https://i.imgur.com/Bb8XweM.jpg",
            @"https://i.imgur.com/8jAQLQg.jpg",
            @"https://i.imgur.com/o6k7Do9.jpg",
            @"https://i.imgur.com/kDh6H3A.jpg",
            @"https://i.imgur.com/efhbnYW.jpg",
            @"https://i.imgur.com/D8t60bF.jpg",
            @"https://i.imgur.com/jHbDvXv.jpg",
            @"https://i.imgur.com/hY359Le.jpg",
            @"https://i.imgur.com/SlGrqUp.jpg",
            @"https://i.imgur.com/IxOH40v.jpg",
            @"https://i.imgur.com/iLb0e65.jpg",
            @"https://i.imgur.com/UPrh48u.jpg",
            @"https://i.imgur.com/yzENGqz.jpg",
            @"https://i.imgur.com/ZdyQM6A.jpg",
        };
    }
}