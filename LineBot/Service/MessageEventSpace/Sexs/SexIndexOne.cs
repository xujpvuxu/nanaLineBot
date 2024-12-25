using LineBot.DAO;

namespace LineBot.Service.MessageEventSpace.Sexs
{
    public class SexIndexOne
    {
        private string SheetId = "1co08s6FapFHaV9L4eLET4zb9jqq2DGra7NH9j_vj0p0";

        public string GetResult(int count )
        {
            // 部位
            StaticFuntion.GetExcel<SexDAO>(SheetId, "1-0");
            List<string> part = SexDAO.SexCard.ToList();

            // 動作
            StaticFuntion.GetExcel<SexDAO>(SheetId, "1-1");
            List<string> action = SexDAO.SexCard.ToList();

            // 次數
            StaticFuntion.GetExcel<SexDAO>(SheetId, "1-2");
            List<string> time = SexDAO.SexCard.ToList();

            List<string> collection = new List<string>();

            List<string> genders = new List<string> { "男", "女" };
            for (int i = 0; i < count; i++)
            {
                foreach (string gender in genders)
                {
                    collection.Add($@"{i+1}.{gender}:{action.GetRandomOne()}對方{part.GetRandomOne()}{time.GetRandomOne()}秒");
                    collection.Add(Environment.NewLine);
                }
                collection.Add(Environment.NewLine);
            }

            return string.Join(string.Empty, collection);
        }
    }
}