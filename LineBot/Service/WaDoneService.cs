using LineBot.Enums;
using LineBot.Models;
using System.Data;

namespace LineBot.Service
{
    public class WaDoneService
    {
        /// <summary>
        /// 請求
        /// </summary>
        public WaDoneRequest Request { get; set; }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="request"></param>
        public WaDoneService(WaDoneRequest request)
        {
            Request = request;
        }

        /// <summary>
        /// 開始找答案
        /// </summary>
        public void GetWaDone()
        {
            Init();
            ResultTable = new DataTable();
            Enumerable.Range(1, Length).ToList().ForEach(x => ResultTable.Columns.Add(x.ToString()));
            Enumerable.Range(1, Length).ToList().ForEach(x => ResultTable.Rows.Add(ResultTable.NewRow()));

            if (string.IsNullOrEmpty(ErrorMessage))
            {
                bool isLoop = true;
                while (isLoop && Request.PathCount <= Math.Pow(Length, 2) - 2)
                {
                    GetStartEnd();
                    if (Result.Any())
                    {
                        int diffPathCount = Request.PathCount + 1;
                        Go(Request.Start.Properity, Request.Start.Energy, 0, 0, 0, 0, 0, 0, new List<EProperity> { (EProperity)Request.Start.Properity }, diffPathCount);
                    }
                    if (HasAnswer || !Request.NeedResult)
                    {
                        isLoop = false;
                    }
                    Request.PathCount = Request.PathCount + 4;
                }
            }
        }

        private List<(List<EProperity>, List<int>)> ResultAnswer = new List<(List<EProperity>, List<int>)>();
        public List<EProperity> ResultProperity = new List<EProperity>();
        private List<(List<int>, List<int>)> Result = new List<(List<int>, List<int>)>();

        // 轉屬幾次
        private Dictionary<string, int> NameToInt = new Dictionary<string, int>();

        private Dictionary<EProperity, int> ProperityToInt = new Dictionary<EProperity, int>();

        public DataTable ResultTable = new DataTable();

        // 設定
        private static int Length = 5;

        private int[,] Maze = null;
        private Dictionary<(int, int), int> PathRecord = new Dictionary<(int, int), int>();
        private ERotate EndRotate = ERotate.橫;

        private string ErrorMessage = string.Empty;
        private bool HasAnswer = false;
        private List<EProperity> ResultProperityPath = new List<EProperity>();
        public List<int> ResultPath = new List<int>();
        public List<int> ResultTransPath = new List<int>();

        private Dictionary<int, (int x, int y)> ParseCoor = Enumerable.Range(0, Length).SelectMany(x => Enumerable.Range(0, Length), (x, y) => (x, y))
                                                                 .ToDictionary(
                                                                       index => (index.x + 1) + (Length * index.y),
                                                                       coordinate => (coordinate.x, coordinate.y));

        /// <summary>
        ///
        /// </summary>
        /// <param name="startPro"></param>
        /// <param name="startEng"></param>
        /// <param name="wood"></param>
        /// <param name="fire"></param>
        /// <param name="dust"></param>
        /// <param name="gold"></param>
        /// <param name="water"></param>
        /// <param name="path"></param>
        /// <param name="process"></param>
        /// <param name="diffPathCount">還有幾步路到終點</param>
        private void Go(int startPro, int startEng, int wood, int fire, int dust, int gold, int water, int path, List<EProperity> process, int diffPathCount)
        {
            diffPathCount--;
            path++;
            EProperity start = (EProperity)startPro;

            int diffProperityPower = Request.End.Properity - startPro;
            if (diffProperityPower < 0)
            { diffProperityPower += Length; }

            int diffEnergy = Math.Abs(startEng - Request.End.Energy);
            int totalDiffPower = diffProperityPower + diffEnergy;

            if (path < Request.PathCount + 1 && !HasAnswer && (totalDiffPower <= diffPathCount))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (!HasAnswer)
                    {
                        int tempStartPro = startPro;
                        int tempStartEng = startEng;
                        int tempWood = wood;
                        int tempFire = fire;
                        int tempDust = dust;
                        int tempGold = gold;
                        int tempWater = water;

                        bool isRun = false;
                        List<EProperity> tempProcess = process.ToList();

                        EProperity encome = (EProperity)i;
                        switch (encome)
                        {
                            case EProperity.木:
                                tempWood++;
                                if (tempWood <= Request.Wood.Count)
                                {
                                    isRun = true;
                                    // 一開始屬性 遇到木
                                    switch (start)
                                    {
                                        case EProperity.木:
                                            break;

                                        case EProperity.火:
                                            tempStartEng++;
                                            break;

                                        case EProperity.土:
                                            tempStartEng--;
                                            break;

                                        case EProperity.金:
                                            tempStartEng--;
                                            break;

                                        case EProperity.水:
                                            tempStartPro = (int)EProperity.木;
                                            break;

                                        default:
                                            break;
                                    }
                                }
                                break;

                            case EProperity.火:
                                tempFire++;
                                if (tempFire <= Request.Fire.Count)
                                {
                                    isRun = true;
                                    // 一開始屬性 遇到火
                                    switch (start)
                                    {
                                        case EProperity.木:
                                            tempStartPro = (int)EProperity.火;
                                            break;

                                        case EProperity.火:
                                            break;

                                        case EProperity.土:
                                            tempStartEng++;
                                            break;

                                        case EProperity.金:
                                            tempStartEng--;
                                            break;

                                        case EProperity.水:
                                            tempStartEng--;
                                            break;
                                    }
                                }
                                break;

                            case EProperity.土:
                                tempDust++;
                                if (tempDust <= Request.Dust.Count)
                                {
                                    isRun = true;
                                    // 一開始屬性 遇到土
                                    switch (start)
                                    {
                                        case EProperity.木:
                                            tempStartEng--;
                                            break;

                                        case EProperity.火:
                                            tempStartPro = (int)EProperity.土;
                                            break;

                                        case EProperity.土:
                                            break;

                                        case EProperity.金:
                                            tempStartEng++;
                                            break;

                                        case EProperity.水:
                                            tempStartEng--;
                                            break;
                                    }
                                }
                                break;

                            case EProperity.金:
                                tempGold++;
                                if (tempGold <= Request.Gold.Count)
                                {
                                    isRun = true;
                                    // 一開始屬性 遇到金
                                    switch (start)
                                    {
                                        case EProperity.木:
                                            tempStartEng--;
                                            break;

                                        case EProperity.火:
                                            tempStartEng--;
                                            break;

                                        case EProperity.土:
                                            tempStartPro = (int)EProperity.金;
                                            break;

                                        case EProperity.金:
                                            break;

                                        case EProperity.水:
                                            tempStartEng++;
                                            break;
                                    }
                                }
                                break;

                            case EProperity.水:
                                tempWater++;
                                if (tempWater <= Request.Water.Count)
                                {
                                    isRun = true;
                                    // 一開始屬性 遇到水
                                    switch (start)
                                    {
                                        case EProperity.木:
                                            tempStartEng++;
                                            break;

                                        case EProperity.火:
                                            tempStartEng--;
                                            break;

                                        case EProperity.土:
                                            tempStartEng--;
                                            break;

                                        case EProperity.金:
                                            tempStartPro = (int)EProperity.水;
                                            break;

                                        case EProperity.水:
                                            break;
                                    }
                                }
                                break;
                        }

                        if (isRun)
                        {
                            if (tempStartEng != 0 && tempStartEng != 4)
                            {
                                tempProcess.Add(encome);
                                Go(tempStartPro, tempStartEng, tempWood, tempFire, tempDust, tempGold, tempWood, path, tempProcess, diffPathCount);
                            }
                        }
                    }
                }
            }
            else if (path == Request.PathCount + 1)
            {
                if (startPro == Request.End.Properity && startEng == Request.End.Energy)
                {
                    // 檢查 [某屬性幾次, 轉數幾次]
                    bool[] isAllMatch = new bool[] { false, false };
                    // 至少某屬性幾次
                    if (Request.Task_Properity_Count == 0)
                    {
                        isAllMatch[0] = true;
                    }
                    else
                    {
                        List<EProperity> tempProcess = process.ToList();
                        tempProcess.Add((EProperity)Request.End.Properity);
                        if (tempProcess.Where(x => x == Request.Task_Properity).Count() >= Request.Task_Properity_Count)
                        {
                            isAllMatch[0] = true;
                        }
                    }

                    // 轉屬幾次
                    if (Request.Task_TransProperity == 0)
                    {
                        isAllMatch[1] = true;
                    }
                    else
                    {
                        int maxCount = 0;
                        int lastValue = ProperityToInt.Last().Value;
                        List<EProperity> tempTransList = process.ToList();
                        tempTransList.Add((EProperity)Request.End.Properity);

                        int properityRecord = ProperityToInt[tempTransList.First()];
                        var _ = tempTransList.Aggregate((x, y) =>
                        {
                            int source = ProperityToInt[x];
                            int target = (ProperityToInt[y] == ProperityToInt.First().Value) ?
                                                    lastValue + 1 :
                                                    ProperityToInt[y];
                            if (source == properityRecord && source + 1 == target)
                            {
                                // 轉屬
                                maxCount++;
                                properityRecord = (target == lastValue + 1) ? 0 : target;
                            }
                            return y;
                        });
                        if (maxCount >= Request.Task_TransProperity)
                        {
                            isAllMatch[1] = true;
                        }
                    }
                    if (isAllMatch.All(x => x))
                    {
                        CheckAnswer(process);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            ProperityToInt = ((EProperity[])Enum.GetValues(typeof(EProperity)))
                                                .ToDictionary(
                                                    key => key,
                                                    index => (int)index);
        }

        private void GetStartEnd()
        {
            ERotate startRotate = (Request.StartPath_1.X - Request.StartPath_0.X  == 0) ? ERotate.直 : ERotate.橫;
            EndRotate = (Request.EndPath_1.X - Request.EndPath_0.X == 0) ? ERotate.直 : ERotate.橫;

            Result = new List<(List<int>, List<int>)>();
            ResultAnswer = new List<(List<EProperity>, List<int>)>();
            Maze = new int[Length, Length];
            List<int> maxLength = Enumerable.Range(0, Length).ToList();
            PathRecord = maxLength.SelectMany(x => maxLength, (x, y) => (x, y)).ToDictionary(
                           key => (key.x, key.y),
                           value => value.x + (value.y * Length) + 1);

            // 設定 起始終迄點
            Maze[Request.StartPath_0.X, Request.StartPath_0.Y] = 1;
            Maze[Request.EndPath_0.X, Request.EndPath_0.Y] = 1;

            // 設定起始走點
            SolveMaze(Request.StartPath_1.X, Request.StartPath_1.Y, startRotate, new List<int>(), new List<int>());

            // 判斷轉彎數
            int totalTransCount = Request.Wood.Trans + Request.Fire.Trans + Request.Dust.Trans + Request.Gold.Trans + Request.Water.Trans;
            Result = Result.Where(x => x.Item2.Count <= totalTransCount).ToList();
            if (Request.PathCount == Math.Pow(Length, 2))
            {
                if (startRotate == EndRotate)
                {
                    if (totalTransCount % 2 != 0)
                    {
                        Result = new List<(List<int>, List<int>)>();
                        ErrorMessage = "轉彎數不對";
                    }
                }
                else
                {
                    if (totalTransCount % 2 == 0)
                    {
                        Result = new List<(List<int>, List<int>)>();
                        ErrorMessage = "轉彎數不對";
                    }
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="row"> X </param>
        /// <param name="col"> Y </param>
        /// <param name="path"></param>
        private void SolveMaze(int row, int col, ERotate rotate, List<int> path, List<int> rotateRecord)
        {
            //設定結束位置
            if (row == Request.EndPath_1.X && col == Request.EndPath_1.Y)
            {
                // Reached the end of the maze
                path.Add(PathRecord[(row, col)]);

                if (path.Count == Request.PathCount)
                {
                    if (rotate != EndRotate)
                    {
                        rotateRecord.Add(PathRecord[(row, col)]);
                    }
                    Result.Add((path, rotateRecord.Select(x => x - 1).ToList()));
                }
                return;
            }

            if (row >= 0 && row < Length && col >= 0 && col < Length && Maze[row, col] == 0)
            {
                Maze[row, col] = 1;  // Mark the current cell as visited
                path.Add(PathRecord[(row, col)]);

                ERotate tempRotate = ERotate.直;

                // Try moving in all possible directions (right, down, left, up)
                // col Y
                List<int> tempPath = path.ToList();
                List<int> tempRotateList = rotateRecord.ToList();
                if (rotate != tempRotate)
                {
                    tempRotateList.Add(PathRecord[(row, col)]);
                }
                SolveMaze(row, col + 1, tempRotate, tempPath, tempRotateList); // Right

                tempPath = path.ToList();
                SolveMaze(row, col - 1, tempRotate, tempPath, tempRotateList); // Left

                // row X
                tempRotate = ERotate.橫;
                tempPath = path.ToList();
                tempRotateList = rotateRecord.ToList();
                if (rotate != tempRotate)
                {
                    tempRotateList.Add(PathRecord[(row, col)]);
                }
                SolveMaze(row + 1, col, tempRotate, tempPath, tempRotateList); // Down

                tempPath = path.ToList();
                SolveMaze(row - 1, col, tempRotate, tempPath, tempRotateList); // Up

                Maze[row, col] = 0;  // Reset the current cell for backtracking
            }
        }

        private void CheckAnswer(List<EProperity> source)
        {
            // 總路徑 所需個屬性需要的數量
            var totalNeed = source.Skip(1).GroupBy(x => x).Select(prop => new { properity = prop.Key, count = prop.Count() }).ToList();

            foreach ((List<int> path, List<int> trans) item in Result)
            {
                // 總轉彎 所需屬性的數量
                Dictionary<int, int> transToIndex = item.path.Select((data, i) => new { value = data, index = i }).ToDictionary(x => x.value - 1, y => y.index + 1);

                var transDetail = item.trans.Select(data => source[transToIndex[data]]).GroupBy(data => data).ToDictionary(
                    properity => properity.Key,
                    count => count.Count()
                );

                bool isAnswer = true;
                foreach (var perNeed in totalNeed)
                {
                    bool tempAnswer = true;
                    switch (perNeed.properity)
                    {
                        case EProperity.木:
                            // 轉彎判斷
                            if (transDetail.TryGetValue(perNeed.properity, out int woodTransCount))
                            {
                                if (woodTransCount > Request.Wood.Trans)
                                {
                                    tempAnswer = false;
                                }
                            }

                            // 直線判斷
                            if (Request.Wood.Strage < (perNeed.count - woodTransCount))
                            {
                                tempAnswer = false;
                            }
                            break;

                        case EProperity.火:
                            // 轉彎判斷
                            if (transDetail.TryGetValue(perNeed.properity, out int fireTransCount))
                            {
                                if (fireTransCount > Request.Fire.Trans)
                                {
                                    tempAnswer = false;
                                }
                            }

                            // 直線判斷
                            if (Request.Fire.Strage < (perNeed.count - fireTransCount))
                            {
                                tempAnswer = false;
                            }
                            break;

                        case EProperity.土:
                            // 轉彎判斷
                            if (transDetail.TryGetValue(perNeed.properity, out int dustTransCount))
                            {
                                if (dustTransCount > Request.Dust.Trans)
                                {
                                    tempAnswer = false;
                                }
                            }

                            // 直線判斷
                            if (Request.Dust.Strage < (perNeed.count - dustTransCount))
                            {
                                tempAnswer = false;
                            }
                            break;

                        case EProperity.金:
                            // 轉彎判斷
                            if (transDetail.TryGetValue(perNeed.properity, out int goldTransCount))
                            {
                                if (goldTransCount > Request.Gold.Trans)
                                {
                                    tempAnswer = false;
                                }
                            }

                            // 直線判斷
                            if (Request.Gold.Strage < (perNeed.count - goldTransCount))
                            {
                                tempAnswer = false;
                            }
                            break;

                        case EProperity.水:
                            // 轉彎判斷
                            if (transDetail.TryGetValue(perNeed.properity, out int waterTransCount))
                            {
                                if (waterTransCount > Request.Water.Trans)
                                {
                                    tempAnswer = false;
                                }
                            }

                            // 直線判斷
                            if (Request.Water.Strage < (perNeed.count - waterTransCount))
                            {
                                tempAnswer = false;
                            }
                            break;
                    }
                    if (!tempAnswer)
                    {
                        isAnswer = false;
                    }
                }
                if (isAnswer)
                {
                    ResultTransPath = item.trans.Select(x => x + 1).ToList();

                    ResultProperity = source.ToList();
                    ResultProperity.Add((EProperity)Request.End.Properity);

                    HasAnswer = true;
                    ResultPath.Add(PathRecord[(Request.StartPath_0.X, Request.StartPath_0.Y)]);
                    ResultPath.AddRange(item.path);
                    ResultPath.Add(PathRecord[(Request.EndPath_0.X, Request.EndPath_0.Y)]);
                    break;
                }
            }
        }
    }
}