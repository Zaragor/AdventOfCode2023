using AdventOfCode2023.Day3.Models;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day3
{
    public static class Day3
    {
        public static int Part1()
        {
            return Part1(FileHelpers.ParseInputAsString("Day3/day3.txt"));
        }

        public static int Part1(IEnumerable<string> input)
        {
            var total = 0;
            var engineRows = input.Select(input => new EngineRow(input)).ToList();
            for (int i = 0; i < engineRows.Count(); i++)
            {
                var engineRow = engineRows.ElementAt(i);
                var precedingEngineRow = engineRows.ElementAt(Math.Max(0, i - 1));
                var subsequentEngineRow = engineRows.ElementAt(Math.Min(i + 1, engineRows.Count() - 1));
                total = total + engineRow.PartNumbers
                    .Where(partNumber => partNumber.IsValid(new List<EngineRow> { precedingEngineRow, engineRow, subsequentEngineRow }))
                    .Sum(partNumber => partNumber.Id);
            }
            return total;
        }

        public static int Part2()
        {
            return Part2(FileHelpers.ParseInputAsString("Day3/day3.txt"));
        }

        public static int Part2(IEnumerable<string> input)
        {
            var total = 0;
            var engineRows = input.Select(input => new EngineRow(input)).ToList();
            for (var i = 0; i < engineRows.Count; i++)
            {
                var engineRow = engineRows.ElementAt(i);
                var precedingEngineRow = engineRows.ElementAt(Math.Max(0, i - 1));
                var subsequentEngineRow = engineRows.ElementAt(Math.Min(i + 1, engineRows.Count() - 1));
                var neighbours = new List<EngineRow> { precedingEngineRow, engineRow, subsequentEngineRow };
                total = total + engineRow.StarIndex.Sum(starIndex => starIndex.gearRatio(neighbours));
            }

            return total;
        }

        public static int gearRatio(this int starIndex, IEnumerable<EngineRow> neighbours)
        {
            var neighbouringNumbers = neighbours.SelectMany(neighbour => neighbour.PartNumbers.Where(part => starIndex >= part.StartIndex - 1 && starIndex <= part.EndIndex + 1)).ToList();

            if (neighbouringNumbers.Count != 2)
            {
                return 0;
            }

            return neighbouringNumbers[0].Id * neighbouringNumbers[1].Id;
        }
    }
}
