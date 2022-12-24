using LineBot.Enums;

namespace LineBot.DTO.Messages
{
    /// <summary>
    /// 以文字方式回傳
    /// </summary>
    public class TextMessageDto : BaseMessageDto
    {
        public TextMessageDto()
        {
            Type = MessageTypeEnum.text.ToString();
        }

        public string Text { get; set; }
    }
}