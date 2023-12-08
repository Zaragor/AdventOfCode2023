using AdventOfCode2023.Day5.Models;

namespace AdventOfCode2023.Day5
{
    public static class Day5
    {
        public static Int64 Part1()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day5/day5.txt").ToList();
            return Part1(input);
        }

        public static Int64 Part1(List<string> input)
        {
            var maps = ParseMaps(input);
            var seeds = input.ElementAt(0).Substring(7).Split(' ').Select(long.Parse).ToList();

            var min = Int64.MaxValue;
            foreach (var seed in seeds)
            {
                var key = seed;
                foreach (var map in maps)
                {
                    var shift = map.Shifts.FirstOrDefault(shift => shift.Source <= key && shift.SourceEnd >= key);
                    if (shift != null)
                    {
                        key += shift.ShiftAmount;
                    }
                }
                if (key < min)
                {
                    min = key;
                }
            }

            return min;
        }

        public static long Part2()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day5/day5.txt").ToList();
            return Part2(input);
        }

        public static long Part2(List<string> input)
        {
            var maps = ParseMaps(input);
            var seeds = input.ElementAt(0).Substring(7).Split(' ').Select(long.Parse).ToList();

            var min = Int64.MaxValue;
            for (var i = 0; i < seeds.Count; i += 2)
            {
                var seedStart = seeds[i];
                var seedRange = seeds[i + 1];
                var seedEnd = seedStart + seedRange;
                var ranges = new List<(long start, long end)> { (seedStart, seedEnd) };
                foreach (var map in maps)
                {
                    var newRanges = new List<(long, long)>();
                    foreach (var range in ranges)
                    {
                        var relevantShifts = map.Shifts.Where(shift => shift.In(range)).OrderBy(s => s.Source).ToList();

                        if (relevantShifts.Count == 0)
                        {
                            newRanges.Add(range);
                            continue;
                        }

                        var lowestShiftStart = relevantShifts.First().Source;
                        if (lowestShiftStart > range.start)
                        {
                            newRanges.Add((range.start, lowestShiftStart));
                        }
                        for (var j = 0; j < relevantShifts.Count; j++)
                        {
                            var shift = relevantShifts[j];
                            var start = Math.Max(range.start, shift.Source);
                            var end = Math.Min(range.end, shift.SourceEnd);
                            newRanges.Add((start + shift.ShiftAmount, end + shift.ShiftAmount));

                            var nextShift = j + 1 < relevantShifts.Count ? relevantShifts[j + 1] : null;
                            var trailingEnd = range.end;
                            if (nextShift != null)
                            {
                                trailingEnd = Math.Min(range.end, nextShift.Source);
                            }
                            if (shift.SourceEnd != trailingEnd && shift.SourceEnd < trailingEnd)
                            {
                                newRanges.Add((shift.SourceEnd, trailingEnd));
                            }
                        }
                    }
                    ranges = newRanges;
                }

                if (ranges.Min(range => range.start) < min)
                {
                    min = ranges.Min(range => range.start);
                }
            }

            return min;
        }

        public static IEnumerable<Map> ParseMaps(List<string> input)
        {
            var maps = new List<Map>();
            var rowBoundries = input.Select((input, index) => (input, index)).Where(input => string.IsNullOrEmpty(input.input)).Select(input => input.index).ToList();

            for (var i = 0; i < rowBoundries.Count; i++)
            {
                var map = new Map();
                var rowBoundry = rowBoundries[i];
                var nextBoundry = i + 1 < rowBoundries.Count ? rowBoundries[i + 1] : input.Count();
                var mapRows = input
                    .Skip(rowBoundry + 1)
                    .Skip(1)
                    .Take(nextBoundry - rowBoundry - 2)
                    .ToList();
                foreach (var mapRow in mapRows)
                {
                    var bits = mapRow.Split(' ');
                    var shift = new Shift
                    {
                        Destination = Int64.Parse(bits[0]),
                        Source = Int64.Parse(bits[1]),
                        Distance = Int64.Parse(bits[2])
                    };
                    map.Shifts.Add(shift);
                }
                maps.Add(map);
            }
            return maps;
        }
    }
}
