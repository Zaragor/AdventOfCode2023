using AdventOfCode2023.Day7.Models;

namespace AdventOfCode2023.Day7
{
    public class CardComparer : IComparer<CardHand>
    {
        public int Compare(CardHand? x, CardHand? y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            var toReturn = y.HandType - x.HandType;

            if (toReturn == 0)
            {
                return CompareHands(x.Hand, y.Hand);
            }
            return toReturn;
        }

        private int CompareHands(string x, string y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == y[i])
                {
                    continue;
                }
                var xCard = Enum.Parse<CardType>(x[i].ToString());
                var yCard = Enum.Parse<CardType>(y[i].ToString());
                return xCard - yCard;
            }
            return 0;
        }
    }
}
