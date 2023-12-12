namespace AdventOfCode2023.Day10
{
    public static class Day10
    {
        public static int Part1()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day10/day10.txt").ToList();
            return Part1(input);
        }

        public static int Part2()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day10/day10.txt").ToList();
            return Part2(input);
        }

        public static int Part1(IEnumerable<string> input)
        {
            char[][] grid = input.Select(i => i.ToArray()).ToArray();
            var current = FindStart(grid);
            var next = FindNext(grid, current);
            var totalDistance = WalkPipeLoop(grid, next, current, out var _);

            return totalDistance / 2;
        }

        public static int Part2(IEnumerable<string> input)
        {
            char[][] grid = input.Select(i => i.ToArray()).ToArray();
            var current = FindStart(grid);
            var next = FindNext(grid, current);
            WalkPipeLoop(grid, next, current, out var loopSections);
            ReplaceS(grid, loopSections);
            var loopHash = loopSections.ToHashSet();

            var totalInside = 0;
            for (var x = 0; x < grid.Length; x++)
            {
                var currentlyInside = false;
                for (var y = 0; y < grid[x].Length; y++)
                {
                    if (loopHash.Contains((x, y)))
                    {
                        var currentChar = grid[y][x];
                        if (currentChar == '-')
                        {
                            currentlyInside = !currentlyInside;
                        }
                        if (currentChar == '|' || currentChar == 'L' || currentChar == 'J' || currentChar == '.')
                        {
                            throw new Exception("Invalid pipe " + currentChar);
                        }
                        if (currentChar == 'F' || currentChar == '7')
                        {
                            var originalChar = currentChar;
                            y++;
                            currentChar = grid[y][x];
                            while (currentChar == '|')
                            {
                                y++;
                                currentChar = grid[y][x];
                            }
                            if (currentChar != 'L' && currentChar != 'J')
                            {
                                throw new Exception("Invalid pipe");
                            }

                            if (originalChar == 'F' && currentChar == 'J')
                            {
                                currentlyInside = !currentlyInside;
                            }
                            else if (originalChar == '7' && currentChar == 'L')
                            {
                                currentlyInside = !currentlyInside;
                            }
                        }
                        continue;
                    }
                    if (currentlyInside)
                    {
                        totalInside++;
                    }
                }
            }

            return totalInside;
        }

        public static void ReplaceS(char[][] grid, List<(int x, int y)> loop)
        {
            var sPos = loop.First();
            var sNeighbourOnePos = loop[1];
            var sNeighbourTwoPos = loop[loop.Count - 2];
            var sNeighbourOne = grid[sNeighbourOnePos.y][sNeighbourOnePos.x];
            var sNeighbourTwo = grid[sNeighbourTwoPos.y][sNeighbourTwoPos.x];
            char sCharacter;
            switch ((sNeighbourOne, sNeighbourTwo))
            {
                case ('F', '|'):
                case ('F', 'L'):
                case ('F', 'J'):
                case ('|', '|'):
                case ('|', 'L'):
                case ('|', 'J'):
                case ('7', '|'):
                case ('7', 'L'):
                case ('7', 'J'):

                    sCharacter = '|';
                    break;
                case ('|', '-'):
                case ('-', '|'):
                    sCharacter = 'L';
                    break;
                case ('J', '|'):
                    sCharacter = 'F';
                    break;
                default:
                    throw new NotImplementedException("Sorry, can't be bothered");
            }
            grid[sPos.y][sPos.x] = sCharacter;
        }

        public static (int x, int y) FindNext(char[][] grid, (int x, int y) start)
        {
            if (start.x > 0)
            {
                var left = grid[start.y][start.x - 1];
                if (left == '-' || left == 'L' || left == 'F')
                {
                    return (start.x - 1, start.y);
                }
            }
            if (start.x < grid.Length - 1)
            {
                var right = grid[start.y][start.x + 1];
                if (right == '-' || right == '7' || right == 'J')
                {
                    return (start.x + 1, start.y);
                }
            }
            if (start.y > 0)
            {
                var up = grid[start.y - 1][start.x];
                if (up == '|' || up == '7' || up == 'F')
                {
                    return (start.x, start.y - 1);
                }
            }
            if (start.y < grid[0].Length - 1)
            {
                var down = grid[start.y + 1][start.x];
                if (down == '|' || down == 'L' || down == 'J')
                {
                    return (start.x, start.y + 1);
                }
            }
            throw new Exception("no neighbour is valid pipe");
        }

        public static (int x, int y) FindStart(char[][] grid)
        {
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 'S')
                    {
                        return (j, i);
                    }
                }
            }
            throw new Exception("No start found");
        }

        public static int WalkPipeLoop(char[][] grid, (int x, int y) current, (int x, int y) previous, out List<(int x, int y)> loopSections)
        {
            loopSections = new List<(int x, int y)>()
            {
                previous
            };
            var distanceWalked = 1;
            while (true)
            {
                loopSections.Add(current);
                var currentChar = grid[current.y][current.x];
                switch (currentChar)
                {
                    case 'S':
                        return distanceWalked;
                    case '|':
                        if (previous.y < current.y)
                        {
                            previous = current;
                            current = (current.x, current.y + 1);
                            break;
                        }
                        else if (previous.y > current.y)
                        {
                            previous = current;
                            current = (current.x, current.y - 1);
                            break;
                        }
                        else throw new Exception("Invalid pipe |");
                    case '-':
                        if (previous.x < current.x)
                        {
                            previous = current;
                            current = (current.x + 1, current.y);
                            break;
                        }
                        else if (previous.x > current.x)
                        {
                            previous = current;
                            current = (current.x - 1, current.y);
                            break;
                        }
                        else throw new Exception("Invalid pipe -");
                    case 'L':
                        if (previous.y < current.y)
                        {
                            previous = current;
                            current = (current.x + 1, current.y);
                            break;
                        }
                        else if (previous.x > current.x)
                        {
                            previous = current;
                            current = (current.x, current.y - 1);
                            break;
                        }
                        else throw new Exception("Invalid pipe L");
                    case 'J':
                        if (previous.x < current.x)
                        {
                            previous = current;
                            current = (current.x, current.y - 1);
                            break;
                        }
                        else if (previous.y < current.y)
                        {
                            previous = current;
                            current = (current.x - 1, current.y);
                            break;
                        }
                        else throw new Exception("Invalid pipe J");
                    case '7':
                        if (previous.x < current.x)
                        {
                            previous = current;
                            current = (current.x, current.y + 1);
                            break;
                        }
                        else if (previous.y > current.y)
                        {
                            previous = current;
                            current = (current.x - 1, current.y);
                            break;
                        }
                        else throw new Exception("Invalid pipe 7");
                    case 'F':
                        if (previous.x > current.x)
                        {
                            previous = current;
                            current = (current.x, current.y + 1);
                            break;
                        }
                        else if (previous.y > current.y)
                        {
                            previous = current;
                            current = (current.x + 1, current.y);
                            break;
                        }
                        else throw new Exception("Invalid pipe F");
                    case '.':
                        throw new Exception("Invalid pipe .");
                    default:
                        throw new Exception("Invalid pipe");
                }
                distanceWalked++;
            }
        }



    }
}
