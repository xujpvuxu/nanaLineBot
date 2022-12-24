using LineBot.Enums;

namespace LineBot.DTO.Messages
{
    public class TextMessageDto : BaseMessageDto
    {
        public TextMessageDto()
        {
            Type = MessageTypeEnum.Text;
        }

        public string Text { get; set; }
    }
}