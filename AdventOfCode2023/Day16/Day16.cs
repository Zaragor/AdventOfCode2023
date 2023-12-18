using AdventOfCode2023.Day16.Models;
using System.Data;

namespace AdventOfCode2023.Day16
{
    public class Day16
    {
        public long Part1()
        {
            var input = System.IO.File.ReadAllLines("Day16/day16.txt");
            return Part1(input, (row: 0, col: 0, dir: Direction.East));
        }

        public long Part1(IEnumerable<string> input, (int row, int col, Direction dir) beamPosition)
        {
            var grid = input.Select(x => x.ToCharArray()).ToArray();
            var visited = new HashSet<(int row, int col, Direction dir)>();
            var energised = new HashSet<(int row, int col)>();
            PropegateBeam(grid, visited, energised, new List<(int, int, Direction)>() { beamPosition });
            return energised.Count();
        }

        public long Part2()
        {
            var input = System.IO.File.ReadAllLines("Day16/day16.txt");
            return Part2(input);
        }

        public long Part2(IEnumerable<string> input)
        {
            var max = 0L;
            for (var i = 0; i < input.Count(); i++)
            {
                var right = Part1(input, (i, 0, Direction.East));
                var left = Part1(input, (i, input.First().Length - 1, Direction.West));
                max = Math.Max(max, Math.Max(right, left));
            }

            for (var i = 0; i < input.First().Length; i++)
            {
                var top = Part1(input, (0, i, Direction.South));
                var bottom = Part1(input, (input.Count() - 1, i, Direction.North));
                max = Math.Max(max, Math.Max(top, bottom));
            }

            return max;
        }

        public void PropegateBeam(char[][] grid, HashSet<(int row, int col, Direction dir)> visited, HashSet<(int row, int col)> energised, ICollection<(int row, int col, Direction dir)> beams)
        {
            if (!beams.Any())
            {
                return;
            }
            var currentBeam = beams.First();
            while (true)
            {
                if (visited.Contains(currentBeam) || currentBeam.row < 0 || currentBeam.row > grid.Length - 1 || currentBeam.col < 0 || currentBeam.col > grid[0].Length - 1)
                {
                    break;
                }
                visited.Add(currentBeam);
                energised.Add((currentBeam.row, currentBeam.col));
                var currentChar = grid[currentBeam.row][currentBeam.col];
                switch (currentBeam.dir)
                {
                    case Direction.North:
                        switch (currentChar)
                        {
                            case '.':
                            case '|':
                                currentBeam = (currentBeam.row - 1, currentBeam.col, currentBeam.dir);
                                break;
                            case '-':

                                currentBeam = (currentBeam.row, currentBeam.col - 1, Direction.West);
                                beams.Add((currentBeam.row, currentBeam.col + 1, Direction.East));
                                break;
                            case '/':
                                currentBeam = (currentBeam.row, currentBeam.col + 1, Direction.East);
                                break;
                            case '\\':
                                currentBeam = (currentBeam.row, currentBeam.col - 1, Direction.West);
                                break;
                        }
                        break;
                    case Direction.South:
                        switch (currentChar)
                        {
                            case '.':
                            case '|':
                                currentBeam = (currentBeam.row + 1, currentBeam.col, currentBeam.dir);
                                break;
                            case '-':
                                currentBeam = (currentBeam.row, currentBeam.col - 1, Direction.West);
                                beams.Add((currentBeam.row, currentBeam.col + 1, Direction.East));
                                break;
                            case '/':
                                currentBeam = (currentBeam.row, currentBeam.col - 1, Direction.West);
                                break;
                            case '\\':
                                currentBeam = (currentBeam.row, currentBeam.col + 1, Direction.East);
                                break;
                        }
                        break;
                    case Direction.East:
                        switch (currentChar)
                        {
                            case '.':
                            case '-':
                                currentBeam = (currentBeam.row, currentBeam.col + 1, currentBeam.dir);
                                break;
                            case '|':
                                currentBeam = (currentBeam.row + 1, currentBeam.col, Direction.South);
                                beams.Add((currentBeam.row - 1, currentBeam.col, Direction.North));
                                break;
                            case '/':
                                currentBeam = (currentBeam.row - 1, currentBeam.col, Direction.North);
                                break;
                            case '\\':
                                currentBeam = (currentBeam.row + 1, currentBeam.col, Direction.South);
                                break;
                        }
                        break;
                    case Direction.West:
                        switch (currentChar)
                        {
                            case '.':
                            case '-':
                                currentBeam = (currentBeam.row, currentBeam.col - 1, currentBeam.dir);
                                break;
                            case '|':
                                currentBeam = (currentBeam.row + 1, currentBeam.col, Direction.South);
                                beams.Add((currentBeam.row - 1, currentBeam.col, Direction.North));
                                break;
                            case '/':
                                currentBeam = (currentBeam.row + 1, currentBeam.col, Direction.South);
                                break;
                            case '\\':
                                currentBeam = (currentBeam.row - 1, currentBeam.col, Direction.North);
                                break;
                        }
                        break;
                }
            }

            PropegateBeam(grid, visited, energised, beams.Skip(1).ToList());
        }

        public void PropegateBeamRecursive(char[][] grid, HashSet<(int row, int col, Direction dir)> visited, HashSet<(int row, int col)> energised, (int row, int col, Direction dir) beam)
        {
            if (visited.Contains(beam) || beam.row < 0 || beam.row > grid.Length - 1 || beam.col < 0 || beam.col > grid[0].Length - 1)
            {
                return;
            }
            visited.Add(beam);
            energised.Add((beam.row, beam.col));
            var currentChar = grid[beam.row][beam.col];
            switch (beam.dir)
            {
                case Direction.North:
                    switch (currentChar)
                    {
                        case '.':
                        case '|':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row - 1, beam.col, beam.dir));
                            break;
                        case '-':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row, beam.col - 1, Direction.West));
                            PropegateBeamRecursive(grid, visited, energised, (beam.row, beam.col + 1, Direction.East));
                            break;
                        case '/':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row, beam.col + 1, Direction.East));
                            break;
                        case '\\':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row, beam.col - 1, Direction.West));
                            break;
                    }
                    break;
                case Direction.South:
                    switch (currentChar)
                    {
                        case '.':
                        case '|':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row + 1, beam.col, beam.dir));
                            break;
                        case '-':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row, beam.col - 1, Direction.West));
                            PropegateBeamRecursive(grid, visited, energised, (beam.row, beam.col + 1, Direction.East));
                            break;
                        case '/':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row, beam.col - 1, Direction.West));
                            break;
                        case '\\':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row, beam.col + 1, Direction.East));
                            break;
                    }
                    break;
                case Direction.East:
                    switch (currentChar)
                    {
                        case '.':
                        case '-':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row, beam.col + 1, beam.dir));
                            break;
                        case '|':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row + 1, beam.col, Direction.South));
                            PropegateBeamRecursive(grid, visited, energised, (beam.row - 1, beam.col, Direction.North));
                            break;
                        case '/':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row - 1, beam.col, Direction.North));
                            break;
                        case '\\':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row + 1, beam.col, Direction.South));
                            break;
                    }
                    break;
                case Direction.West:
                    switch (currentChar)
                    {
                        case '.':
                        case '-':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row, beam.col - 1, beam.dir));
                            break;
                        case '|':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row + 1, beam.col, Direction.South));
                            PropegateBeamRecursive(grid, visited, energised, (beam.row - 1, beam.col, Direction.North));
                            break;
                        case '/':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row + 1, beam.col, Direction.South));
                            break;
                        case '\\':
                            PropegateBeamRecursive(grid, visited, energised, (beam.row - 1, beam.col, Direction.North));
                            break;
                    }
                    break;
            }
        }
    }
}
