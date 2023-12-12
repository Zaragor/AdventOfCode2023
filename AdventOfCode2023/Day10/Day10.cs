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

            var connectedSections = FindConnectedSections(grid, loopSections);
            return connectedSections.Where(section => section.All(point => point.x != 0 && point.y != 0 && point.y != grid.Length - 1 && point.x != grid[0].Length - 1)).Select(s => s.Count()).Sum();
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

        public static int WalkPipe(char[][] grid, (int x, int y) current, (int x, int y) previous, int distanceWalked)
        {
            var currentChar = grid[current.y][current.x];
            switch (currentChar)
            {
                case 'S':
                    return distanceWalked;
                case '|':
                    if (previous.y < current.y)
                    {
                        return WalkPipe(grid, (current.x, current.y + 1), current, distanceWalked + 1);
                    }
                    else if (previous.y > current.y)
                    {
                        return WalkPipe(grid, (current.x, current.y - 1), current, distanceWalked + 1);
                    }
                    else throw new Exception("Invalid pipe |");
                case '-':
                    if (previous.x < current.x)
                    {
                        return WalkPipe(grid, (current.x + 1, current.y), current, distanceWalked + 1);
                    }
                    else if (previous.x > current.x)
                    {
                        return WalkPipe(grid, (current.x - 1, current.y), current, distanceWalked + 1);
                    }
                    else throw new Exception("Invalid pipe -");
                case 'L':
                    if (previous.y < current.y)
                    {
                        return WalkPipe(grid, (current.x + 1, current.y), current, distanceWalked + 1);
                    }
                    else if (previous.x > current.x)
                    {
                        return WalkPipe(grid, (current.x, current.y - 1), current, distanceWalked + 1);
                    }
                    else throw new Exception("Invalid pipe L");
                case 'J':
                    if (previous.x < current.x)
                    {
                        return WalkPipe(grid, (current.x, current.y - 1), current, distanceWalked + 1);
                    }
                    else if (previous.y < current.y)
                    {
                        return WalkPipe(grid, (current.x - 1, current.y), current, distanceWalked + 1);
                    }
                    else throw new Exception("Invalid pipe J");
                case '7':
                    if (previous.x < current.x)
                    {
                        return WalkPipe(grid, (current.x, current.y + 1), current, distanceWalked + 1);
                    }
                    else if (previous.y > current.y)
                    {
                        return WalkPipe(grid, (current.x - 1, current.y), current, distanceWalked + 1);
                    }
                    else throw new Exception("Invalid pipe 7");
                case 'F':
                    if (previous.x > current.x)
                    {
                        return WalkPipe(grid, (current.x, current.y + 1), current, distanceWalked + 1);
                    }
                    else if (previous.y > current.y)
                    {
                        return WalkPipe(grid, (current.x + 1, current.y), current, distanceWalked + 1);
                    }
                    else throw new Exception("Invalid pipe F");
                case '.':
                    throw new Exception("Invalid pipe .");
                default:
                    throw new Exception("Invalid pipe");
            }
        }

        public static List<List<(int x, int y)>> FindConnectedSections(char[][] grid, List<(int x, int y)> loopSections)
        {
            var connectedSections = new List<List<(int x, int y)>>();
            var visited = new HashSet<(int x, int y)>();
            var loopSectionsHash = loopSections.ToHashSet();
            for (var x = 0; x < grid.Length; x++)
            {
                for (var y = 0; y < grid[x].Length; y++)
                {
                    if (loopSectionsHash.Contains((x, y)))
                    {
                        continue;
                    }
                    if (visited.Contains((x, y)))
                    {
                        continue;
                    }

                    var section = new List<(int x, int y)>() { (x, y) };
                    connectedSections.Add(section);
                    visited.Add((x, y));

                    GreedyVisitNeighbours(visited, loopSectionsHash, section, grid, (x, y));
                }
            }
            return connectedSections;
        }

        public static void GreedyVisitNeighbours(
            HashSet<(int x, int y)> visited,
            HashSet<(int x, int y)> loopSections,
            List<(int x, int y)> section,
            char[][] grid,
            (int x, int y) point)
        {
            foreach (var neighbour in FindNeighbours(grid, point))
            {
                if (visited.Contains(neighbour))
                {
                    continue;
                }
                if (loopSections.Contains(neighbour))
                {
                    var loopCharacter = grid[point.y][point.x];
                    switch (loopCharacter)
                    {
                        case '|':
                            if (neighbour.x == point.x)
                            {
                                continue;
                            }
                            var leftNeighbour = grid[neighbour.y][neighbour.x - 1];
                            var rightNeighbour = grid[neighbour.y][neighbour.x + 1];
                            if (loopSections.Contains((neighbour.x - 1, neighbour.y)) &&
                                (leftNeighbour == '|' || leftNeighbour == '7' || leftNeighbour == 'J'))
                            {
                                throw new NotImplementedException("expand downwards");
                            }
                            if (loopSections.Contains((neighbour.x + 1, neighbour.y)) &&
                                (rightNeighbour == '|' || rightNeighbour == 'F' || rightNeighbour == 'L'))
                            {
                                throw new NotImplementedException("expand upwards");
                            }
                            break;

                        default:
                            throw new Exception("Invalid loop character");

                    }
                    Console.WriteLine("loop section might have gaps in it");
                    continue;
                }
                section.Add(neighbour);
                visited.Add(neighbour);
                GreedyVisitNeighbours(visited, loopSections, section, grid, neighbour);
            }
        }

        public static IEnumerable<(int x, int y)> FindNeighbours(char[][] grid, (int x, int y) point)
        {
            if (point.x - 1 > 0)
            {
                yield return (point.x - 1, point.y);
            }
            if (point.x < grid[point.y].Length - 1)
            {
                yield return (point.x + 1, point.y);
            }
            if (point.y - 1 > 0)
            {
                yield return (point.x, point.y - 1);
            }
            if (point.y < grid.Length - 2)
            {
                yield return (point.x, point.y + 1);
            }
        }
    }
}
