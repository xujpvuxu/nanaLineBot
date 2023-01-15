using LineBot.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace LineBot
{
    public static class StaticFuntion
    {
        private static readonly string ApiKey = "AIzaSyCXVrCX9QWtx9MmUsDHi9vePsJovuu7Tgs";

        public static void GetExcel<T>(string sheetID, string SheetWorkName) where T : class, new()
        {
            // 從Excel取資料
            HttpClient client = new HttpClient();

            string content = client.GetStringAsync($@"https://sheets.googleapis.com/v4/spreadsheets/{sheetID}/values/{SheetWorkName}?key={ApiKey}").Result;
            List<string> values = JsonConvert.DeserializeObject<GoogleSheet>(content).values.SelectMany(data => data).ToList();

            string columnName = values.First();
            // 寫入資料
            T writedModel = new T();
            PropertyInfo[] source = writedModel.GetType().GetProperties();
            foreach (PropertyInfo property in source)
            {
                if (property.Name.Equals(columnName))
                {
                    property.SetValue(writedModel, values.ToList());
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