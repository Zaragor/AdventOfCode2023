namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public void ExamplePart1()
        {
            var input = Example.Split(Environment.NewLine).ToList();
            Assert.AreEqual(374, Day11.Day11.Part1(input));
        }

        [TestMethod]
        public void ExamplePart2TenTimes()
        {
            var input = Example.Split(Environment.NewLine).ToList();
            Assert.AreEqual(1030, Day11.Day11.Part2(input, 10));
        }

        public const string Example = @"...#......
.......#..
#.........
..........
......#...
.#........
.........#
..........
.......#..
#...#.....";
    }
}
