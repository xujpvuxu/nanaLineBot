using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace LineBot
{
    public static class StaticFuntion
    {
        public static void GetExcel<T>(string uri) where T : class, new()
        {
            // 從Excel取資料
            HttpClient client = new HttpClient();
            string content = client.GetStringAsync(uri).Result;

            string bodyContent = Regex.Match(content, @"<tbody>.*?</tbody>", RegexOptions.Singleline).Value;
            List<Match> trValue = Regex.Matches(bodyContent, @"<tr.*?</tr>", RegexOptions.Singleline).OfType<Match>().ToList();

            // 先處理 Dic<欄位Index,(欄位名稱,List) >
            var columnName = Regex.Matches(trValue.First().Value, @"<td.*?>(?<value>.*?)</td>")
                                   .OfType<Match>()
                                   .Select(data => data.Groups["value"].Value)
                                   .Where(data => !string.IsNullOrEmpty(data))
                                   .Select((data, i) => new { Name = data, Index = i })
                                   .ToDictionary(
                                        index => index.Index,
                                        value => (value.Name, new List<string>()));

            // 將資料寫入Dic中的List
            foreach (Match item in trValue.Skip(1))
            {
                List<Match> matchValue = Regex.Matches(item.Value, @"<td.*?>(.*?<div.*?>|)(?<value>.*?)(</div>|)</td>").OfType<Match>().ToList();

                bool isOver = true;
                for (int i = 0; i < columnName.Count; i++)
                {
                    string value = matchValue[i].Groups["value"].Value;
                    if (!string.IsNullOrEmpty(value))
                    {
                        columnName[i].Item2.Add(value);
                        isOver = false;
                    }
                }
                if (isOver)
                {
                    break;
                }
            }
            // 後處理欄位資料 改成 Dic<欄位名稱,欄位值>
            Dictionary<string, List<string>> res = columnName.ToDictionary(
                                                            Name => Name.Value.Name,
                                                            value => value.Value.Item2.ToRandomList());

            // 寫入資料
            T writedModel = new T();
            PropertyInfo[] source = writedModel.GetType().GetProperties();
            foreach (PropertyInfo property in source)
            {
                if (res.TryGetValue(property.Name, out List<string> columnValue))
                {
                    property.SetValue(writedModel, columnValue);
                }
            }
        }

        /// <summary>
        /// 洗亂
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>

        public static List<T> ToRandomList<T>(this IEnumerable<T> source)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            return source.OrderBy(data => rand.Next())
                         .ToList();
        }

        public static T GetRandomOne<T>(this List<T> source)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int randomNumber = random.Next(0, source.Count);
            return source[randomNumber];
        }

        public static string ToTitleText(this string text)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(text);
        }
    }
}