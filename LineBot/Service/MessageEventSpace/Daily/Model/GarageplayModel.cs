namespace LineBot.Domain.MessageEventSpace.Daily.Model
{
    public class GarageplayModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public object[] identity { get; set; }
        public object[] gpvideo { get; set; }
        public object[] films { get; set; }
        public object[] news { get; set; }
        public Datum[] data { get; set; }
        public Checks checks { get; set; }
        public Position[] positions { get; set; }
    }
    public class Checks
    {
        public bool bundle { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string bsns_date { get; set; }
        public string clock_showtime { get; set; }
        public string time_intvl { get; set; }
        public string seat_type { get; set; }
        public string[] pick_by { get; set; }
        public string dtm_time { get; set; }
        public string dtm_accom { get; set; }
        public string title { get; set; }
        public string english_title { get; set; }
        public string duration { get; set; }
        public string rating { get; set; }
        public string area { get; set; }
        public string theater { get; set; }
        public string hall { get; set; }
        public string alien_id { get; set; }
        public string hall_id { get; set; }
        public object lux_id { get; set; }
        public string hall_seat_num { get; set; }
        public string event_cname { get; set; }
        public string event_ename { get; set; }
        public string event_location { get; set; }
        public string event_datetime { get; set; }
        public string video { get; set; }
        public string pic_url { get; set; }
        public string content { get; set; }
        public string ori_price { get; set; }
        public string price { get; set; }
        public string max_accom { get; set; }
        public string session_id { get; set; }
        public string event_id { get; set; }
        public object type { get; set; }
        public object stage { get; set; }
        public string clear { get; set; }
        public string qty { get; set; }
        public string fee { get; set; }
        public string book { get; set; }
        public string preview { get; set; }
        public string preview_icon_url { get; set; }
        public string preview_note { get; set; }
        public string preview_register_info { get; set; }
        public string preview_points { get; set; }
        public string preview_limit { get; set; }
        public string passcode { get; set; }
        public string plus_book { get; set; }
        public string plus_addition { get; set; }
        public string plus_price { get; set; }
        public string plan_a { get; set; }
        public string plan_b { get; set; }
        public string plan_c { get; set; }
        public string chat_tix { get; set; }
        public string chat_tix_price { get; set; }
        public string chat_tix_points { get; set; }
        public string chat_tix_max { get; set; }
        public string chat_max { get; set; }
        public string pic_url_v { get; set; }
        public string pic_url_h { get; set; }
        public string movie_url { get; set; }
        public string session_url { get; set; }
        public string registrant_picture_path { get; set; }
        public string lux_url { get; set; }
        public string chat_sn { get; set; }
        public string web_promotion { get; set; }
        public object clear_time { get; set; }
        public string[] pay_by { get; set; }
        public string event_datetime_info { get; set; }
        public string chat_stu_only { get; set; }
        public string position { get; set; }
        public Registrant[] registrants { get; set; }
        public string director { get; set; }
        public string actor { get; set; }
        public string[] vimeo_video_link { get; set; }
        public string preview_remain { get; set; }
        public string pixnet { get; set; }
        public Ad[] ads { get; set; }
    }

    public class Registrant
    {
        public string id { get; set; }
        public string member_id { get; set; }
        public string q11 { get; set; }
        public string update_time { get; set; }
        public string insert_time { get; set; }
    }

    public class Ad
    {
        public string m3u8 { get; set; }
        public string mp4 { get; set; }
        public string skip_seconds { get; set; }
        public string again_seconds { get; set; }
        public string button_text { get; set; }
        public string button_url { get; set; }
        public string icon_text { get; set; }
    }

    public class Position
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}