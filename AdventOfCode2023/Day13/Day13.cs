namespace AdventOfCode2023.Day13
{
    public class Day13
    {
        public int Part1()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day13/day13.txt").ToList();
            return this.Part1(input);
        }

        public int Part1(IEnumerable<string> input)
        {
            var patterns = SplitIntoPatterns(input);
            return
                patterns.SelectMany(FindHorizontalMirrors).Sum() +
                patterns.SelectMany(FindVerticalMirrors).Select(i => i * 100).Sum();
        }

        public int Part2()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day13/day13.txt").ToList();
            return this.Part2(input);
        }

        public int Part2(IEnumerable<string> input)
        {
            var patterns = SplitIntoPatterns(input)
                .Select(AccountForSmudges);
            var originalPatterns = SplitIntoPatterns(input).ToList();

            var total = 0;
            for (var i = 0; i < originalPatterns.Count; i++)
            {
                var originalMirrorsHoirzontal = FindHorizontalMirrors(originalPatterns[i]).ToList();
                var newMirrorsHorizontal = patterns.ElementAt(i).SelectMany(FindHorizontalMirrors).ToList();
                var diff = newMirrorsHorizontal.Except(originalMirrorsHoirzontal).ToList();
                total += diff.Sum();

                var originalMirrorsVertical = FindVerticalMirrors(originalPatterns[i]).ToList();
                var newMirrorsVertical = patterns.ElementAt(i).SelectMany(FindVerticalMirrors).ToList();
                var diffVertical = newMirrorsVertical.Except(originalMirrorsVertical).ToList();
                total += diffVertical.Sum() * 100;
            }

            return total;
        }


        /// <summary>
        /// As in mirrors that duplicate columns
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public IEnumerable<int> FindHorizontalMirrors(IEnumerable<string> pattern)
        {
            var totalLength = pattern.First().Length;
            for (var pivot = 1; pivot < totalLength; pivot++)
            {
                if (pattern.All(row =>
                {
                    var max = Math.Min(pivot, totalLength - pivot);
                    for (var i = 1; i <= max; i++)
                    {
                        if (row.ElementAt(pivot - i) != row.ElementAt(pivot + i - 1))
                        {
                            return false;
                        }
                    }
                    return true;
                }))
                {
                    yield return pivot;
                }
            }
        }

        public IEnumerable<int> FindVerticalMirrors(IEnumerable<string> pattern)
        {
            for (var pivot = 1; pivot < pattern.Count(); pivot++)
            {
                if (!IsReflected(pivot, pattern))
                {
                    continue;
                }
                yield return pivot;
            }
        }

        private bool IsReflected(int pivot, IEnumerable<string> pattern)
        {
            var max = Math.Min(pivot, pattern.Count() - pivot);
            for (var i = 1; i <= max; i++)
            {
                if (pattern.ElementAt(pivot - i) != pattern.ElementAt(pivot + i - 1))
                {
                    return false;
                }
            }
            return true;
        }

        private IEnumerable<IEnumerable<string>> SplitIntoPatterns(IEnumerable<string> input)
        {
            while (input.Any())
            {
                yield return input.TakeWhile(i => !string.IsNullOrEmpty(i));
                input = input.SkipWhile(i => !string.IsNullOrEmpty(i)).Skip(1);
            }
        }

        public IEnumerable<IEnumerable<string>> AccountForSmudges(IEnumerable<string> pattern)
        {
            for (var i = 0; i < pattern.Count(); i++)
            {
                var row = pattern.ElementAt(i);
                for (var j = 0; j < row.Length; j++)
                {
                    var character = row.ElementAt(j);
                    var replacement = character == '#' ? '.' : '#';
                    var toYield = pattern.ToList();
                    toYield[i] = row.Substring(0, j) + replacement + row.Substring(j + 1);
                    foreach (var line in toYield)
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine();
                    yield return toYield;
                }
            }
        }
    }
}
