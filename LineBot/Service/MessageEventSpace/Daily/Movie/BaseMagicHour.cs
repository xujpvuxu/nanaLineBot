using LineBot.Domain.MessageEventSpace.Daily.Model;
using LineBot.Interfaces;
using System.Text.Json;

namespace LineBot.Service.MessageEventSpace.Daily.Movie
{
    public class BaseMagicHour 
    {
        protected HttpClient Client = new HttpClient();

        public BaseMagicHour() 
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36");
        }


    }
}
