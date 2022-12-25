using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class NanaResponsePicture : BaseResponse
    {
        public void Result(WebhookEventDto eventObject, List<string> pictures)
        {
            //// 隨機取數字
            int index = new Random().Next(pictures.Count());

            // 取得隨機路徑
            //string picturePath = $@"{hostUri}/{Const.UploadFiles}/{Path.GetFileName(datas[index])}";
            string picturePath = pictures[index];

            var replyMessage = new ReplyMessageRequestDto<ImageMessageDto>(eventObject)
            {
                Messages = new List<ImageMessageDto>
                            {
                                new ImageMessageDto
                                {
                                    PreviewImageUrl = picturePath,
                                    OriginalContentUrl = picturePath
                                }
                            }
            };
            ReplyMessageHandler("text", replyMessage);
        }

        public static List<string> NanaPictures = new List<string>
        {
            @"https://i.imgur.com/fcYrJ4C.jpg",
            @"https://i.imgur.com/eqvGQws.jpg",
            @"https://i.imgur.com/67Q9Q6Z.jpg",
            @"https://i.imgur.com/QF5IkmF.jpg",
            @"https://i.imgur.com/h4ceC9o.jpg",
            @"https://i.imgur.com/yOqW18y.jpg",
            @"https://i.imgur.com/MLEKrhI.jpg",
            @"https://i.imgur.com/WYPQw90.jpg",
            @"https://i.imgur.com/olt5dzX.jpg",
            @"https://i.imgur.com/ibwZ0ge.jpg",
            @"https://i.imgur.com/mdhZxqI.jpg",
            @"https://i.imgur.com/xhxSbjF.jpg",
            @"https://i.imgur.com/hF0aaMQ.jpg",
            @"https://i.imgur.com/N3oCqVU.jpg",
            @"https://i.imgur.com/L23SYwN.jpg",
            @"https://i.imgur.com/YmFERCe.jpg",
            @"https://i.imgur.com/CkR5KUO.jpg",
            @"https://i.imgur.com/NCCSd7s.jpg",
            @"https://i.imgur.com/jjsaimv.jpg",
            @"https://i.imgur.com/urdlxgJ.jpg",
            @"https://i.imgur.com/GYEbCB0.jpg",
            @"https://i.imgur.com/7uV7BmP.jpg",
            @"https://i.imgur.com/Sj4UA6g.jpg",
            @"https://i.imgur.com/ia7jMhV.jpg",
            @"https://i.imgur.com/OvvLqyJ.jpg",
            @"https://i.imgur.com/6cTzPDB.jpg",
            @"https://i.imgur.com/YZOeGDA.jpg",
            @"https://i.imgur.com/6j6ddu2.jpg",
            @"https://i.imgur.com/JUrfVDd.jpg",
            @"https://i.imgur.com/PJFlZxX.jpg",
            @"https://i.imgur.com/Ib90JIS.jpg",
            @"https://i.imgur.com/fVSTTTx.jpg",
            @"https://i.imgur.com/ChUsFup.jpg",
            @"https://i.imgur.com/6QgYdV7.jpg",
            @"https://i.imgur.com/ry6wuYX.jpg",
            @"https://i.imgur.com/i8ihrFU.jpg",
            @"https://i.imgur.com/Jkqp23d.jpg",
            @"https://i.imgur.com/pPS1VlN.jpg",
            @"https://i.imgur.com/pzpPRHC.jpg",
            @"https://i.imgur.com/MCicOKP.jpg",
            @"https://i.imgur.com/b9DEo0V.jpg",
            @"https://i.imgur.com/vBQGA7P.jpg",
            @"https://i.imgur.com/mmIQwvt.jpg",
            @"https://i.imgur.com/hDfBBOp.jpg",
            @"https://i.imgur.com/I3WsKi8.jpg",
            @"https://i.imgur.com/5XU4Dsu.jpg",
            @"https://i.imgur.com/FLFa3NY.jpg",
            @"https://i.imgur.com/VesJLvD.jpg",
            @"https://i.imgur.com/BKd7V7H.jpg",
            @"https://i.imgur.com/UZxVgWs.jpg",
            @"https://i.imgur.com/NmrZZs6.jpg",
            @"https://i.imgur.com/mQKyTNH.jpg",
            @"https://i.imgur.com/5kCixOs.jpg",
            @"https://i.imgur.com/yUwpmey.jpg",
            @"https://i.imgur.com/YtvTDNJ.jpg",
            @"https://i.imgur.com/mNoPwmY.jpg",
            @"https://i.imgur.com/m1BnfzX.jpg",
            @"https://i.imgur.com/tfrorXM.jpg",
            @"https://i.imgur.com/lVpSRvv.jpg",
            @"https://i.imgur.com/RuPjEYI.jpg",
            @"https://i.imgur.com/mntCFXn.jpg",
            @"https://i.imgur.com/7Z4t6zt.jpg",
            @"https://i.imgur.com/pSdK4pM.jpg",
            @"https://i.imgur.com/mzcTrJe.jpg",
            @"https://i.imgur.com/FvWngHp.jpg",
            @"https://i.imgur.com/1R7WUUw.jpg",
            @"https://i.imgur.com/YUjtcC9.jpg",
            @"https://i.imgur.com/xVyOiUe.jpg",
            @"https://i.imgur.com/pbqu9Yt.jpg",
            @"https://i.imgur.com/WbbIKmM.jpg",
            @"https://i.imgur.com/EAxm4UG.jpg",
            @"https://i.imgur.com/47d47NJ.jpg",
            @"https://i.imgur.com/OYwWolO.jpg",
            @"https://i.imgur.com/gFEOuOv.jpg",
            @"https://i.imgur.com/rbh6b7C.jpg",
            @"https://i.imgur.com/W7Rk4yM.jpg",
            @"https://i.imgur.com/QPfsqhB.jpg",
            @"https://i.imgur.com/M1rGTT5.jpg",
            @"https://i.imgur.com/cM5GoMi.jpg",
            @"https://i.imgur.com/fEjwpGN.jpg",
            @"https://i.imgur.com/ZBkDzcS.jpg",
            @"https://i.imgur.com/3OKndEL.jpg",
            @"https://i.imgur.com/KKLm8IS.jpg",
            @"https://i.imgur.com/oBDktFD.jpg",
            @"https://i.imgur.com/qYmu0Ia.jpg",
            @"https://i.imgur.com/drdt7rz.jpg",
            @"https://i.imgur.com/uRjm7L8.jpg",
            @"https://i.imgur.com/CYYLq3V.jpg",
        };

        public static List<string> SnowPictures = new List<string>
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