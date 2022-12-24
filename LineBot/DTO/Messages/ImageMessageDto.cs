using LineBot.Enums;

namespace LineBot.DTO.Messages
{
    public class ImageMessageDto : BaseMessageDto
    {
        public ImageMessageDto()
        {
            Type = MessageTypeEnum.image.ToString();
        }

        public string OriginalContentUrl { get; set; }
        public string PreviewImageUrl { get; set; }
    }
}