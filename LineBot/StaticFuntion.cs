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

        /// <summary>
        /// 洗亂
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>

        public static List<T> ToRandom<T>(this List<T> source)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < source.Count; i++)
            {
                int tempPosition = rand.Next(0, source.Count);

                var temp = source[i];
                source[i] = source[tempPosition];
                source[tempPosition] = temp;
            }
            return source;
        }
    }
}