using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class NanaResponsePicture : BaseResponse
    {
        public void Result(WebhookEventDto eventObject, List<string> pictures, string hostUri)
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
    }
}