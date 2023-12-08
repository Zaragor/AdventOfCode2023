using AdventOfCode2023.Day2.Models;

namespace AdventOfCode2023.Day2
{
    public static class Day2
    {
        static IEnumerable<(Color, int)> Colors = new List<(Color, int)>()
        {
            (Color.Red, 12),
            (Color.Green, 13),
            (Color.Blue, 14),
        };

        public static int Part1()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day2/day2.txt");
            return Part1(input);
        }

        public static int Part2()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day2/day2.txt");
            return Part2(input);
        }

        public static int Part1(IEnumerable<string> input)
        {
            var games = input.Select(input => new Game(input));
            return games.Where(game => game.RollSet.SelectMany(r => r.Rolls).All(roll => roll.IsValid(Day2.Colors))).Sum(game => game.Id);
        }

        public static int Part2(IEnumerable<string> input)
        {
            var games = input.Select(input => new Game(input));
            return games.Sum(game => game.MinimumColors());
        }
    }
}
