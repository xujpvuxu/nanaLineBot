using LineBot.DAO;

namespace LineBot.Service.MessageEventSpace.Sexs
{
    public class SexIndexTwo
    {
        private string SheetId = "1co08s6FapFHaV9L4eLET4zb9jqq2DGra7NH9j_vj0p0";

        public string GetResult(int count)
        {
            // 部位
            StaticFuntion.GetExcel<SexDAO>(SheetId, "2-0");
            List<string> part = SexDAO.SexCard.ToList();

            List<string> collection = new List<string>();

            List<string> genders = new List<string> { "男", "女" };
            for (int i = 0; i < count; i++)
            {
                foreach (string gender in genders)
                {
                    collection.Add($@"{i + 1}.{gender}:{part.GetRandomOne()}");
                    collection.Add(Environment.NewLine);
                }
                collection.Add(Environment.NewLine);
            }

            return string.Join(string.Empty, collection);
        }
    }
}