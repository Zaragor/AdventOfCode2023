namespace AdventOfCode2023.Day9
{
    public static class Day9
    {
        public static int Part1()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day9/day9.txt").ToList();
            return Part1(input);
        }

        public static int Part1(IEnumerable<string> readings)
        {
            return readings
                .Select(reading => reading.Split(' ')
                .Select(int.Parse))
                .Select(NextNumber)
                .Sum();
        }

        public static int Part2()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day9/day9.txt").ToList();
            return Part2(input);
        }

        public static int Part2(IEnumerable<string> readings)
        {
            return readings
                .Select(reading => reading.Split(' ')
                .Select(int.Parse))
                .Select(PreviousNumber)
                .Sum();
        }

        public static int PreviousNumber(IEnumerable<int> numbers)
        {
            var initialDiffs = CalculateInitialDifference(numbers, new List<int>()).ToList();
            initialDiffs.Reverse();
            return numbers.First() - initialDiffs.Aggregate((a, b) => b - a);
        }

        public static int NextNumber(IEnumerable<int> numbers)
        {
            var finalDiffs = CalculateDifference(numbers, new List<int>()).ToList();
            return finalDiffs.Sum() + numbers.Last();
        }

        public static IEnumerable<int> CalculateDifference(IEnumerable<int> numbers, IEnumerable<int> finalNumbers)
        {
            var differences = new List<int>();
            for (var i = 1; i < numbers.Count(); i++)
            {
                var first = numbers.ElementAt(i - 1);
                var second = numbers.ElementAt(i);
                differences.Add(second - first);
            }
            if (differences.All(diff => diff == 0))
            {
                return finalNumbers.Append(0);
            }
            else
            {
                return CalculateDifference(differences, finalNumbers.Append(differences.Last()));
            }
        }

        public static IEnumerable<int> CalculateInitialDifference(IEnumerable<int> numbers, IEnumerable<int> initialNumbers)
        {
            var differences = new List<int>();
            for (var i = 1; i < numbers.Count(); i++)
            {
                var first = numbers.ElementAt(i - 1);
                var second = numbers.ElementAt(i);
                differences.Add(second - first);
            }
            if (differences.All(diff => diff == 0))
            {
                return initialNumbers.Append(0);
            }
            else
            {
                return CalculateInitialDifference(differences, initialNumbers.Append(differences.First()));
            }
        }
    }
}
