namespace LineBot.Service.MessageEventSpace.Monthes
{
    public class Month
    {
        public string GetMonth()
        {
            // 取資料
            //https://docs.google.com/spreadsheets/d/1kvM_Ax7E5zYHe81m0W2UwVbT-Any3rrsCFWevcnksao/edit?gid=0#gid=0
            string[][] response = StaticFuntion.GetExcelData("1kvM_Ax7E5zYHe81m0W2UwVbT-Any3rrsCFWevcnksao", "Cat");
            string monthString = response[0].First();
            int period = int.Parse(response[1].First());

            // 上次日期轉換
            if (DateTime.TryParse(monthString, out DateTime date))
            {
                DateTime currentDate = DateTime.Now;
                int ticksDiff = (int)new TimeSpan(currentDate.Ticks - date.Ticks).TotalDays;
                int left = ticksDiff % period;
                // 下次幾天後來
                int nextDays = period - left;
                DateTime nextDate = currentDate.AddDays(nextDays);
                return $"倒數 {nextDays} 天{Environment.NewLine}{nextDate.ToString("yyyy/MM/dd")}";
            }

            return "";
        }
    }
}