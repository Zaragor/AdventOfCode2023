namespace AdventOfCode2023.Day1
{
    public static class Day1
    {
        public static IEnumerable<(char, string, int)> Digits = new List<(char, string, int)>
        {
            ('o', "one", 1),
            ('t', "two", 2),
            ('t', "three", 3),
            ('f', "four", 4),
            ('f', "five", 5),
            ('s', "six", 6),
            ('s', "seven", 7),
            ('e', "eight", 8),
            ('n', "nine", 9),
        };
        public static int Part1(IEnumerable<string> input)
        {
            var digits = input.Select(line => line.Where(character => Char.IsDigit(character)).Select<char, int>(chararacter => Int32.Parse(chararacter.ToString())));

            return digits.Sum(line => line.First() * 10 + line.Last());
        }

        public static int Part2(IEnumerable<string> input)
        {
            var digits = input.Select(GetDigits).ToList();

            return digits.Sum(line => line.First() * 10 + line.Last());
        }

        public static IEnumerable<int> GetDigits(string line)
        {
            for (var i = 0; i < line.Length; i++)
            {
                var character = line[i];
                if (Char.IsDigit(character))
                {
                    yield return Int32.Parse(character.ToString());
                }

                foreach (var digit in Digits)
                {
                    if (character.Equals(digit.Item1))
                    {
                        if (digit.Item2 == line.Substring(i, Math.Min(digit.Item2.Length, line.Length - i)))
                        {
                            yield return digit.Item3;
                            break;
                        }
                    }
                }
            }
        }
    }
}
