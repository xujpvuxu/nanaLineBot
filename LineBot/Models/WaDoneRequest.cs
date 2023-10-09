using LineBot.Enums;
using Microsoft.OpenApi.Any;

namespace LineBot.Models
{
    public class WaDoneRequest
    {
        /// <summary>
        /// 起始能量
        /// </summary>
        public ProperityStatus Start { get; set; }

        /// <summary>
        /// 終迄能量
        /// </summary>
        public ProperityStatus End { get; set; }

        /// <summary>
        /// 總路徑
        /// </summary>
        private int _PathCount { get; set; }

        /// <summary>
        /// 剩餘 木 屬性
        /// </summary>
        public FiveProperity Wood { get; set; }

        /// <summary>
        /// 剩餘 火 屬性
        /// </summary>
        public FiveProperity Fire { get; set; }

        /// <summary>
        /// 剩餘 土 屬性
        /// </summary>
        public FiveProperity Dust { get; set; }

        /// <summary>
        /// 剩餘 金 屬性
        /// </summary>
        public FiveProperity Gold { get; set; }

        /// <summary>
        /// 剩餘 水 屬性
        /// </summary>
        public FiveProperity Water { get; set; }

        /// <summary>
        /// 任務 至少  屬性
        /// </summary>
        public EProperity Task_Properity { get; set; }

        /// <summary>
        /// 任務 至少 數量
        /// </summary>
        public int Task_Properity_Count { get; set; }

        /// <summary>
        /// 轉屬幾個
        /// </summary>
        public int Task_TransProperity { get; set; }

        /// <summary>
        /// 是否一定要找到答案
        /// </summary>
        public bool NeedResult { get; set; }

        public Point StartPath_0 { get; set; }
        public Point StartPath_1 { get; set; }
        public Point EndPath_0 { get; set; }
        public Point EndPath_1 { get; set; }

        public int PathCount
        {
            get { return _PathCount - 2; }
            set { _PathCount = value; }
        }
    }

    /// <summary>
    /// 起訖能量狀態
    /// </summary>
    public class ProperityStatus
    {
        /// <summary>
        /// 屬性
        /// </summary>
        public int Properity { get; set; }

        /// <summary>
        /// 能量
        /// </summary>
        public int Energy { get; set; }
    }

    public class FiveProperity
    {
        /// <summary>
        /// 數量
        /// </summary>
        private int _Count { get; set; }

        /// <summary>
        /// 轉彎數量
        /// </summary>
        private int _Trans { get; set; }

        /// <summary>
        /// 直線數量
        /// </summary>
        public int Strage { get; set; }

        public int Count
        {
            get { return _Count; }
            set
            {
                Strage += value;
                _Count = value;
            }
        }

        public int Trans
        {
            get { return _Trans; }
            set
            {
                Strage -= value;
                _Trans = value;
            }
        }
    }

    public class Point
    {
        private int _X { get; set; }
        private int _Y { get; set; }

        public int X
        {
            get { return _X - 1; }
            set { _X = value; }
        }

        public int Y
        {
            get { return _Y - 1; }
            set { _Y = value; }
        }
    }
}