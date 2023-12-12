using System.Collections.Immutable;

namespace AdventOfCode2023.Day12
{
    using Cache = Dictionary<(string, ImmutableStack<int>), long>;

    public class Day12
    {
        public long Part1()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day12/day12.txt").ToList();
            return this.Part1(input);
        }

        public long Part1(IEnumerable<string> rows)
        {
            return rows.Select(PossibleSolutions).Sum();
        }
        public long Part2()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day12/day12.txt").ToList();
            return this.Part2(input);
        }

        public long Part2(IEnumerable<string> rows)
        {
            return rows
                .Select(ExtendRow)
                .Select(PossibleSolutions)
                .Sum();
        }

        public string ExtendRow(string row)
        {
            var parts = row.Split(' ');
            var springs = parts[0];
            var pattern = parts[1];

            var newSprings = String.Join("?", Enumerable.Repeat(springs, 5));
            var newPattern = String.Join(",", Enumerable.Repeat(pattern, 5));

            return newSprings + " " + newPattern;
        }

        public long PossibleSolutions(string row)
        {
            var parts = row.Split(' ');
            var springs = parts[0];
            var pattern = parts[1].Split(',').Select(int.Parse);
            var stack = ImmutableStack.CreateRange(pattern.Reverse());

            var cache = new Cache();
            return CalculateAndCache(springs, stack, cache);
        }

        public long CalculateAndCache(string springs, ImmutableStack<int> stack, Cache cache)
        {
            if (!cache.ContainsKey((springs, stack)))
            {
                cache[(springs, stack)] = Calculate(springs, stack, cache);
            }
            return cache[(springs, stack)];
        }

        public long Calculate(string springs, ImmutableStack<int> stack, Cache cache)
        {
            return springs.FirstOrDefault() switch
            {
                '.' => ProcessDot(springs, stack, cache),
                '?' => ProcessQuestion(springs, stack, cache),
                '#' => ProcessHash(springs, stack, cache),
                _ => ProcessEnd(springs, stack, cache),
            };
        }

        long ProcessDot(string pattern, ImmutableStack<int> nums, Cache cache)
        {
            // consume one spring and recurse
            return CalculateAndCache(pattern[1..], nums, cache);
        }

        long ProcessQuestion(string pattern, ImmutableStack<int> nums, Cache cache)
        {
            // recurse both ways
            var ifGood = CalculateAndCache("." + pattern[1..], nums, cache);
            var ifBad = CalculateAndCache("#" + pattern[1..], nums, cache);
            return ifGood + ifBad;
        }

        // We have a dead spring, so it needs to be the start of the next set of dead springs from the pattern
        long ProcessHash(string pattern, ImmutableStack<int> nums, Cache cache)
        {
            if (!nums.Any())
            {
                // no more dead springs left in pattern but we have one here, this path can't work
                return 0;
            }

            nums = nums.Pop(out int n);

            var potentiallyDead = pattern.TakeWhile(s => s == '#' || s == '?').Count();

            if (potentiallyDead < n)
            {
                // not enough dead springs 
                return 0;
            }
            else if (pattern.Length == n)
            {
                // Special case this one due to length issues
                return CalculateAndCache("", nums, cache);
            }
            else if (pattern[n] == '#')
            {
                // dead spring follows the range -> not good
                return 0;
            }
            else if (pattern[n] == '?' || pattern[n] == '.')
            {
                // We found a set of dead springs of the right length, so we move on to looking for the next set of dead springs after this one has finished. A question mark after the pattern has to be a good spring, so it ends the run
                return CalculateAndCache(pattern[(n + 1)..], nums, cache);
            }
            else
            {
                throw new Exception("Shouldn't get here");
            }
        }

        long ProcessEnd(string _, ImmutableStack<int> nums, Cache __)
        {
            // the good case is when there are no numbers left at the end of the pattern - i.e. we've found all the dead springs we expect to
            return nums.Any() ? 0 : 1;
        }


    }
}
