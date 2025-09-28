using LineBot.Domain;
using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using System.Text.RegularExpressions;

namespace LineBot.Domain.MessageEventSpace
{
    public class CarHelp : BaseResponse, IMessageEventSpace
    {
        public string Pattern { get; set; } = "導航王";

        public CarHelp(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public void Result()
        {
            HttpClient client = new HttpClient(); // 負責處理HttpReques

            string url ="https://naviking.localking.com.tw/download/download.aspx?item=1&step1=12&step2=39&step3=63";
            string result = client.GetStringAsync(url).Result;
            Match match = Regex.Matches(result, $@"<tr>.*?</tr>", RegexOptions.Singleline).OfType<Match>().First(x => x.Value.Contains("導航王"));
            List<Match> matches = Regex.Matches(match.Value, $@"<td>.*?</td>", RegexOptions.Singleline).OfType<Match>().ToList();
            List<string> returnList = matches.Skip(1).Take(2).Select(x=>x.Value).ToList();
            List<string> replaces = new List<string>
            { 
                "<td>",
                "</td>",
                "<br />",
            };

            List<string> res = new List<string>();
            foreach (string returnString in returnList)
            {
                string temp = returnString;

                foreach (string replaceString in replaces)
                {

                    temp =temp.Replace(replaceString,string.Empty);
                }
                res.Add(temp);
            }
            res.Add(url);

            ReplyText(string.Join(Environment.NewLine,res));
        }
    }
}