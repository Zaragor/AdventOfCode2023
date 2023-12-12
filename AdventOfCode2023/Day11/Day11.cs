namespace AdventOfCode2023.Day11
{
    public static class Day11
    {
        public static int Part1()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day11/day11.txt").ToList();
            return Part1(input);
        }
        public static long Part2()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day11/day11.txt").ToList();
            return Part2(input, 1_000_000);
        }

        public static int Part1(List<string> input)
        {
            for (var i = 0; i < input.Count; i++)
            {
                if (input[i].All((col) => col == '.'))
                {
                    input.Insert(i, new string('.', input[0].Length));
                    i++;
                }
            }

            for (var i = 0; i < input[0].Length; i++)
            {
                if (input.All((row) => row[i] == '.'))
                {
                    for (var j = 0; j < input.Count; j++)
                    {
                        input[j] = input[j].Insert(i, ".");
                    }
                    i++;
                }
            }

            var galaxies = new List<(int row, int col)>();
            for (var row = 0; row < input.Count; row++)
            {
                for (var col = 0; col < input[0].Length; col++)
                {
                    if (input[row][col] == '#')
                    {
                        galaxies.Add((row, col));
                    }
                }
            }

            var totalDistance = 0;
            for (var i = 0; i < galaxies.Count; i++)
            {
                for (var j = i + 1; j < galaxies.Count; j++)
                {
                    var rowDistance = Math.Abs(galaxies[i].row - galaxies[j].row);
                    var colDistance = Math.Abs(galaxies[i].col - galaxies[j].col);
                    totalDistance = totalDistance + rowDistance + colDistance;
                }
            }
            return totalDistance;
        }

        public static long Part2(List<string> input, int expansionFactor)
        {
            var blankRows = new List<int>();
            for (var i = 0; i < input.Count; i++)
            {
                if (input[i].All((col) => col == '.'))
                {
                    blankRows.Add(i);
                }
            }

            var blankColumns = new List<int>();
            for (var i = 0; i < input[0].Length; i++)
            {
                if (input.All((row) => row[i] == '.'))
                {
                    blankColumns.Add(i);
                }
            }

            var galaxies = new List<(int row, int col)>();
            for (var row = 0; row < input.Count; row++)
            {
                for (var col = 0; col < input[0].Length; col++)
                {
                    if (input[row][col] == '#')
                    {
                        galaxies.Add((row, col));
                    }
                }
            }

            long totalDistance = 0;
            for (var i = 0; i < galaxies.Count; i++)
            {
                for (var j = i + 1; j < galaxies.Count; j++)
                {
                    var rowDistance = Math.Abs(galaxies[i].row - galaxies[j].row);
                    var colDistance = Math.Abs(galaxies[i].col - galaxies[j].col);
                    var blankRowsCrossed = blankRows.Where(row =>
                    row > galaxies[i].row && row < galaxies[j].row ||
                    row > galaxies[j].row && row < galaxies[i].row).Count();
                    var blankColumnsCrossed = blankColumns.Where(col =>
                    col > galaxies[i].col && col < galaxies[j].col ||
                    col > galaxies[j].col && col < galaxies[i].col).Count();
                    totalDistance =
                        totalDistance +
                        rowDistance +
                        colDistance +
                        (blankRowsCrossed * (expansionFactor - 1)) +
                        blankColumnsCrossed * (expansionFactor - 1);
                }
            }
            return totalDistance;
        }
    }
}
