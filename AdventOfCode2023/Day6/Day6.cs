namespace AdventOfCode2023.Day6
{
    public static class Day6
    {
        private static IEnumerable<(long time, long distance)> RacesPart1 = new List<(long time, long distance)>
        {
            (44, 208),
            (80, 1581),
            (65, 1050),
            (72, 1102)
        };

        private static IEnumerable<(long time, long distance)> RacesPart2 = new List<(long time, long distance)>
        {
            (44806572, 208158110501102)
        };

        public static int Part1()
        {
            return Part1(RacesPart1);
        }
        public static int Part1(IEnumerable<(long time, long distance)> races)
        {
            return races.Select(RaceMargin).Aggregate(1, (a, x) => a * x);
        }

        public static int Part2()
        {
            return Part1(RacesPart2);
        }

        public static int RaceMargin((long time, long distance) race)
        {
            var winningTimes = 0;
            for (var i = 0; i < race.time; i++)
            {
                var remainingTime = race.time - i;
                if (remainingTime * i > race.distance)
                {
                    winningTimes++;
                }
            }

            return winningTimes;
        }
    }
}
