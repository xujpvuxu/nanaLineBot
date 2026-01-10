namespace LineBot.Models
{
    public class AIResponse
    {
        public string id { get; set; }
        public string _object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public Choice[] choices { get; set; }
        public Usage usage { get; set; }
        public object usage_breakdown { get; set; }
        public string system_fingerprint { get; set; }
        public X_Groq x_groq { get; set; }
        public string service_tier { get; set; }
    }

    public class Usage
    {
        public float queue_time { get; set; }
        public int prompt_tokens { get; set; }
        public float prompt_time { get; set; }
        public int completion_tokens { get; set; }
        public float completion_time { get; set; }
        public int total_tokens { get; set; }
        public float total_time { get; set; }
    }

    public class X_Groq
    {
        public string id { get; set; }
        public int seed { get; set; }
    }

    public class Choice
    {
        public int index { get; set; }
        public Message message { get; set; }
        public object logprobs { get; set; }
        public string finish_reason { get; set; }
    }

    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}