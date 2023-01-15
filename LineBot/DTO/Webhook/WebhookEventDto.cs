namespace LineBot.DTO.Webhook
{
    public class WebhookEventDto
    {
        // -------- 以下 common property --------
        public string Type { get; set; } // 事件類型

        public string Mode { get; set; } // Channel state : active | standby
        public long Timestamp { get; set; } // 事件發生時間 : event occurred time in milliseconds
        public SourceDto Source { get; set; } // 事件來源 : user | group chat | multi-person chat
        public string WebhookEventId { get; set; } // webhook event id - ULID format
        public DeliverycontextDto DeliveryContext { get; set; } // 是否為重新傳送之事件 DeliveryContext.IsRedelivery : true | false

        // -------- 以下 event properties--------
        public string? ReplyToken { get; set; } // 回覆此事件所使用的 token

        public MessageEventSpaceDto? Message { get; set; } // 收到訊息的事件，可收到 text、sticker、image、file、video、audio、location 訊息
        public UnsendEventDto? Unsend { get; set; } //使用者“收回”訊息事件
    }

    // -------- 以下 common property --------

    public class SourceDto
    {
        public string Type { get; set; }
        public string? UserId { get; set; }
        public string? GroupId { get; set; }
        public string? RoomId { get; set; }
    }

    public class DeliverycontextDto
    {
        public bool IsRedelivery { get; set; }
    }

    // -------- 以下 message event --------

    public class MessageEventSpaceDto
    {
        public string Id { get; set; }
        public string Type { get; set; }

        // Text Message Event
        public string? Text { get; set; }

        public List<TextMessageEventSpaceEmojiDto>? Emojis { get; set; }
        public TextMessageEventSpaceMentionDto? Mention { get; set; }

        // Image & Video & Audio Message Event
        public ContentProviderDto? ContentProvider { get; set; }

        public ImageMessageEventSpaceImageSetDto? ImageSet { get; set; }
        public int? Duration { get; set; }

        //File Message Event
        public string? FileName { get; set; }

        public int? FileSize { get; set; }

        //Location Message Event
        public string? Title { get; set; }

        public string? Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        // Sticker Message Event
        public string? PackageId { get; set; }

        public string? StickerId { get; set; }
        public string? StickerResourceType { get; set; }
        public List<string>? Keywords { get; set; }
    }

    public class TextMessageEventSpaceEmojiDto
    {
        public int Index { get; set; }
        public int Length { get; set; }
        public string ProductId { get; set; }
        public string EmojiId { get; set; }
    }

    public class TextMessageEventSpaceMentionDto
    {
        public List<TextMessageEventSpaceMentioneeDto> Mentionees { get; set; }
    }

    public class TextMessageEventSpaceMentioneeDto
    {
        public int Index { get; set; }
        public int Length { get; set; }
        public string UserId { get; set; }
    }

    public class ContentProviderDto
    {
        public string Type { get; set; }
        public string? OriginalContentUrl { get; set; }
        public string? PreviewImageUrl { get; set; }
    }

    public class ImageMessageEventSpaceImageSetDto
    {
        public string Id { get; set; }
        public string Index { get; set; }
        public string Total { get; set; }
    }

    // -------- 以下 unsend event --------
    public class UnsendEventDto
    {
        public string messageId { get; set; }
    }
}