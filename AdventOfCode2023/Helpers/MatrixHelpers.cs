namespace AdventOfCode2023.Helpers
{
    internal class MatrixHelpers
    {
        public static IEnumerable<(int x, int y)> FindNeighbours<T>(T[][] grid, (int x, int y) point)
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

        public static bool AreEqual<T>(T[][] a, T[][] b)
        {
            for (var i = 0; i < a.Length; i++)
            {
                for (var j = 0; j < a[0].Length; j++)
                {
                    if (!a[i][j].Equals(b[i][j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
