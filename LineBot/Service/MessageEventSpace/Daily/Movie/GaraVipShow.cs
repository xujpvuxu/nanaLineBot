using LineBot.Domain.MessageEventSpace.Daily.Model;
using LineBot.Interfaces;
using System.Text.Json;

namespace LineBot.Service.MessageEventSpace.Daily.Movie
{
    public class GaraVipShow : BaseMagicHour, IGarageplay
    {
        public string Uri => "https://garageplay.tw/api/sessions_vending?identity=chat_tix";

        public string GetMovieDetail()
        {
            
            string content = Client.GetStringAsync(Uri).Result;
            GarageplayModel sample = JsonSerializer.Deserialize<GarageplayModel>(content);

            List<string> result = new List<string>();
            foreach (Datum item in sample.data)
            {
                result.Add($"名稱：{item.event_cname}");
                result.Add($"地點：{item.event_location}");
                result.Add($"開演時間：{item.clock_showtime}");
                result.Add($"價格：{item.chat_tix_points} P + {item.chat_tix_price} + {item.fee}");
                result.Add("");
            }
            return string.Join(Environment.NewLine, result);
        }
    }
}
