using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class NanaPicture : BaseResponse, ITextEvent
    {
        public string Pattern { get; set; } = "抽.*?娜娜";

        public NanaPicture(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            ReplyPicture(NanaPictures);
        }

        public void ReplyPicture(List<string> pictures)
        {
            //// 隨機取數字
            int index = new Random().Next(pictures.Count());

            // 取得隨機路徑
            string picturePath = pictures[index];

            ReplyImage(picturePath);
        }

        private static List<string> NanaPictures = new List<string>
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
    }
}