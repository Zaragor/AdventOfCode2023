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
                total += engineRow.PartNumbers
                    .Where(partNumber => partNumber.IsValid(new List<EngineRow> { precedingEngineRow, engineRow, subsequentEngineRow }))
                    .Sum(partNumber => partNumber.Id);
            }
            return total;
        }

        public static int Part2()
        {
            return 0;
        }
    }
}
