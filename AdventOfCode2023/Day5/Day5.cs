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
