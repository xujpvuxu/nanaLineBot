using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class NanaResponsePicture : BaseResponse, IType
    {
        public void Result(WebhookEventDto eventObject, string hostUri)
        {
            // 取出所有檔案名稱
            string[] datas = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, Const.UploadFiles));

            // 隨機取數字
            int index = new Random().Next(datas.Length);

            // 取得隨機路徑
            string picturePath = $@"{hostUri}/{Const.UploadFiles}/{Path.GetFileName(datas[index])}";

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