namespace AdventOfCode2023.Day14
{
    public class Day14
    {
        public long Part1()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day14/day14.txt").ToList();
            return this.Part1(input);
        }

        public long Part1(IEnumerable<string> input)
        {
            var charArray = input.Select(i => i.ToCharArray()).ToArray();
            TiltNorth(charArray);
            return CalculateLoad(charArray);
        }

        public long Part2()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day14/day14.txt").ToList();
            return this.Part2(input);
        }

        public long Part2(IEnumerable<string> input)
        {
            var charArray = input.Select(i => i.ToCharArray()).ToArray();

            var seen = new Dictionary<string, int>();
            var firstSeen = 0;
            var cycleLength = 0;
            for (var i = 1; i <= 1_000_000_000; i++)
            {
                var starting = charArray.Select(c => c.Select(i => i).ToArray()).ToArray();
                charArray = TiltNorth(charArray);
                charArray = TiltEast(charArray);
                charArray = TiltSouth(charArray);
                charArray = TiltWest(charArray);
                var oneString = string.Join(Environment.NewLine, charArray.Select(i => new string(i)));
                if (seen.TryGetValue(oneString, out var lastSeen))
                {
                    firstSeen = lastSeen;
                    cycleLength = i - lastSeen;
                    break;
                }
                seen.Add(oneString, i);
            }

            var cycle = (1_000_000_000 - firstSeen) % cycleLength;
            var pattern = seen.Where(i => i.Value == cycle + firstSeen).Select(i => i.Key).First();

            return CalculateLoad(pattern.Split(Environment.NewLine).Select(c => c.ToCharArray()).ToArray());
        }

        public long CalculateLoad(char[][] chars)
        {
            var total = 0;
            for (var row = chars.Length - 1; row >= 0; row--)
            {
                for (var col = 0; col < chars[row].Length; col++)
                {
                    var character = chars[row][col];
                    if (character == 'O')
                    {
                        total = total + (chars.Length - row);
                    }
                }
            }

            return total;
        }

        public char[][] TiltNorth(char[][] starting)
        {
            for (var col = 0; col < starting[0].Length; col++)
            {
                var currentStationaryRock = 0;
                var currentRollingRocks = 0;
                for (var row = starting.Length - 1; row >= 0; row--)
                {
                    var character = starting[row][col];
                    if (character == '#')
                    {
                        currentStationaryRock = row + 1;
                        for (var k = 0; k < currentRollingRocks; k++)
                        {
                            starting[currentStationaryRock][col] = 'O';
                            currentStationaryRock++;
                        }
                        currentStationaryRock = row - 1;
                        currentRollingRocks = 0;
                    }
                    else if (character == 'O')
                    {
                        starting[row][col] = '.';
                        currentRollingRocks++;
                    }
                }
                if (currentRollingRocks > 0)
                {
                    currentStationaryRock = 0;
                    for (var k = 0; k < currentRollingRocks; k++)
                    {
                        starting[currentStationaryRock][col] = 'O';
                        currentStationaryRock++;
                    }
                }
            }

            return starting;
        }

        public char[][] TiltEast(char[][] starting)
        {
            for (var row = 0; row < starting.Length; row++)
            {
                var currentStationaryRock = 0;
                var currentRollingRocks = 0;
                for (var col = starting[0].Length - 1; col >= 0; col--)
                {
                    var character = starting[row][col];
                    if (character == '#')
                    {
                        currentStationaryRock = col + 1;
                        for (var k = 0; k < currentRollingRocks; k++)
                        {
                            starting[row][currentStationaryRock] = 'O';
                            currentStationaryRock++;
                        }
                        currentStationaryRock = col - 1;
                        currentRollingRocks = 0;
                    }
                    else if (character == 'O')
                    {
                        starting[row][col] = '.';
                        currentRollingRocks++;
                    }
                }
                if (currentRollingRocks > 0)
                {
                    currentStationaryRock = 0;
                    for (var k = 0; k < currentRollingRocks; k++)
                    {
                        starting[row][currentStationaryRock] = 'O';
                        currentStationaryRock++;
                    }
                }
            }

            return starting;
        }

        public char[][] TiltSouth(char[][] starting)
        {
            for (var col = 0; col < starting[0].Length; col++)
            {
                var currentStationaryRock = 0;
                var currentRollingRocks = 0;
                for (var row = 0; row < starting.Length; row++)
                {
                    var character = starting[row][col];
                    if (character == '#')
                    {
                        currentStationaryRock = row - 1;
                        for (var k = 0; k < currentRollingRocks; k++)
                        {
                            starting[currentStationaryRock][col] = 'O';
                            currentStationaryRock--;
                        }
                        currentStationaryRock = row + 1;
                        currentRollingRocks = 0;
                    }
                    else if (character == 'O')
                    {
                        starting[row][col] = '.';
                        currentRollingRocks++;
                    }
                }
                if (currentRollingRocks > 0)
                {
                    currentStationaryRock = starting.Length - 1;
                    for (var k = 0; k < currentRollingRocks; k++)
                    {
                        starting[currentStationaryRock][col] = 'O';
                        currentStationaryRock--;
                    }
                }
            }

            return starting;
        }

        public char[][] TiltWest(char[][] starting)
        {
            for (var row = 0; row < starting.Length; row++)
            {
                var currentStationaryRock = 0;
                var currentRollingRocks = 0;
                for (var col = 0; col < starting[row].Length; col++)
                {
                    var character = starting[row][col];
                    if (character == '#')
                    {
                        currentStationaryRock = col - 1;
                        for (var k = 0; k < currentRollingRocks; k++)
                        {
                            starting[row][currentStationaryRock] = 'O';
                            currentStationaryRock--;
                        }
                        currentStationaryRock = col + 1;
                        currentRollingRocks = 0;
                    }
                    else if (character == 'O')
                    {
                        starting[row][col] = '.';
                        currentRollingRocks++;
                    }
                }
                if (currentRollingRocks > 0)
                {
                    currentStationaryRock = starting[row].Length - 1;
                    for (var k = 0; k < currentRollingRocks; k++)
                    {
                        starting[row][currentStationaryRock] = 'O';
                        currentStationaryRock--;
                    }
                }
            }

            return starting;
        }
    }
}
