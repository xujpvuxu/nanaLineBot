using LineBot.DTO.Messages;
using LineBot.DTO.Messages.Request;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;

namespace LineBot.Domain.TextEvent
{
    public class TextMain :BaseResponse, IType
    {
        public void Result(WebhookEventDto eventObject , string hostUri)
        {
            string messag = $@"{hostUri}/UploadFiles/LINE_ALBUM_2020-2022_221224.jpg";
            var replyMessage = new ReplyMessageRequestDto<ImageMessageDto>()
            {
                ReplyToken = eventObject.ReplyToken,
                Messages = new List<ImageMessageDto>
                            {
                                new ImageMessageDto
                                {
                                    PreviewImageUrl = messag,
                                    OriginalContentUrl=messag
                                }
                            }
            };
            ReplyMessageHandler("text", replyMessage);
        }
    }
}
