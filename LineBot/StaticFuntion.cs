﻿using LineBot.Models;
using Newtonsoft.Json;
using System.Data;
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
            string[][] values = GetExcelData(sheetID, SheetWorkName);

            Dictionary<string, List<string>> columnValue = values.Select(data => data.Select(
                                                                                          (data, i) => new
                                                                                          {
                                                                                              Index = i,
                                                                                              value = data
                                                                                          }))
                                                               .SelectMany(data => data)
                                                               .GroupBy(data => data.Index)
                                                               .ToDictionary(
                                                                   key => key.Select(data => data.value)
                                                                             .First(),
                                                                   value => value.Select(data => data.value)
                                                                                 .Skip(1)
                                                                                 .Where(data => !string.IsNullOrEmpty(data))
                                                                                 .ToList());
            // 寫入資料
            T writedModel = new T();
            PropertyInfo[] source = writedModel.GetType().GetProperties();
            var ee =  writedModel.GetType();
            var tt= ee.GetProperty("Part");
            foreach (PropertyInfo property in source)
            {
                if (columnValue.TryGetValue(property.Name, out List<string> valuesds))
                {
                    property.SetValue(writedModel, columnValue[property.Name]);
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

        /// <summary>
        /// 取得Excel內容
        /// </summary>
        /// <param name="sheetID"></param>
        /// <param name="SheetWorkName"></param>
        /// <returns></returns>
        public static string[][] GetExcelData(string sheetID, string SheetWorkName)
        { 
            // 從Excel取資料
            HttpClient client = new HttpClient();

            string content = client.GetStringAsync($@"https://sheets.googleapis.com/v4/spreadsheets/{sheetID}/values/{SheetWorkName}?key={ApiKey}").Result;
            return JsonConvert.DeserializeObject<GoogleSheet>(content).values;
        }
    }
}