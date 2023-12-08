using AdventOfCode2023.Day7.Models;

namespace AdventOfCode2023.Day7
{
    public static class Day7
    {
        public static long Part1()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day7/day7.txt").ToList();
            return Part1(input);
        }

        public static long Part1(IEnumerable<string> input)
        {
            var hands = input.Select(i => ParseHand(i));
            var orderedHands = hands.Order(new CardComparer());
            return orderedHands.Select((hand, index) => hand.Bet * (index + 1)).Sum();
        }

        public static long Part2()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day7/day7.txt").ToList();
            return Part2(input);
        }

        public static long Part2(IEnumerable<string> input)
        {
            var hands = input.Select(i => ParseHand(i, true));
            var orderedHands = hands.Order(new CardComparer()).ToList();
            return orderedHands.Select((hand, index) => hand.Bet * (index + 1)).Sum();
        }

        public static CardHand ParseHand(string line, bool wildcard = false)
        {
            var parts = line.Split(' ');

            return new CardHand(parts[0], long.Parse(parts[1]), wildcard);
        }
    }
}
