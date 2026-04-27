using LineBotMessage.Controllers;

namespace LineBot.Service
{
    public class BleachService
    {
        public List<Need> Change(List<string> source)
        {
            string name = source.First();
            source = source.Skip(1).ToList();

            return source.Select(data => new Need { Person = data, Card = name })
                         .ToList();
        }

        public object Test(List<Need> needs, List<Need> haves)
        {
            //var needs = new List<Need>
            //    {
            //        new Need { Person = "A", Card = "1" },
            //        new Need { Person = "A", Card = "2" },
            //        new Need { Person = "B", Card = "4" }
            //    };

            //var haves = new List<Need>
            //    {
            //        new Need { Person = "B", Card = "1" },
            //        new Need { Person = "B", Card = "2" },
            //        new Need { Person = "A", Card = "4" },
            //        new Need { Person = "C", Card = "3" }
            //    };

            var result =
                    (
                        from n1 in needs
                        join h1 in haves on n1.Card equals h1.Card
                        where n1.Person != h1.Person

                        // 找 B 需要的卡
                        join n2 in needs on h1.Person equals n2.Person

                        // 找 A 是否有 B 要的卡
                        join h2 in haves on n2.Card equals h2.Card
                        where h2.Person == n1.Person

                        // 避免 A-B / B-A 重複
                        where string.Compare(n1.Person, h1.Person) < 0

                        select new
                        {
                            PersonA = n1.Person,
                            PersonB = h1.Person,
                            ANeed = n1.Card,
                            BHave = h1.Card,
                            BNeed = n2.Card,
                            AHave = h2.Card
                        }
                    )
                    .Distinct()
                    .ToList();
            return result;
        }
    }
}