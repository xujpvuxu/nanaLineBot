using System.Text.RegularExpressions;

namespace LineBot
{
    public static class StaticFuntion
    {
        public static List<string> GetExcelDatas(string uri, string pattern)
        {
            HttpClient client = new HttpClient();
            string content = client.GetStringAsync(uri).Result;
            return Regex.Matches(content, pattern)
                                 .OfType<Match>()
                                 .Select(data => data.Value)
                                 .Distinct()
                                 .ToList();
        }
    }
}