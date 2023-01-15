namespace LineBot.Models
{
    public class GoogleSheet
    {
        public string range { get; set; }
        public string majorDimension { get; set; }
        public string[][] values { get; set; }
    }
}