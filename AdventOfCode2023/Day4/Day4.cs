namespace AdventOfCode2023.Day4
{
    public static class Day4
    {
        public static int Part1()
        {
            return Part1(Helpers.FileHelpers.ParseInputAsString("Day4/day4.txt"));
        }

        public static int Part1(IEnumerable<string> input)
        {
            return input.Sum(ScorePerCard);
        }

        public static int Part2()
        {
            return Part2(Helpers.FileHelpers.ParseInputAsString("Day4/day4.txt"));
        }

        public static int Part2(IEnumerable<string> input)
        {
            var scorecardCount = Enumerable.Repeat(1, input.Count()).ToArray();
            for (var i = 0; i < input.Count(); i++)
            {
                var card = input.ElementAt(i);
                var count = scorecardCount.ElementAt(i);
                var cardScore = MatchingNumbers(card);
                for (var j = 0; j < cardScore; j++)
                {
                    scorecardCount[i + j + 1] += count;
                }
            }
            return scorecardCount.Sum();
        }

        public static int MatchingNumbers(string card)
        {
            var start = card.IndexOf(':');
            var divider = card.IndexOf('|');
            var winning = card
                .Substring(start + 1, divider - start - 1)
                .Split(' ')
                .Select(digit => digit.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(Int32.Parse).ToList();
            var ours = card.Substring(divider + 1)
                .Split(' ')
                .Select(digit => digit.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(Int32.Parse).ToList();

            return ours.Intersect(winning).Count();
        }

        public static int ScorePerCard(string card)
        {

            var winningCount = MatchingNumbers(card);
            return (int)Math.Pow(2, winningCount - 1);
        }
    }
}
