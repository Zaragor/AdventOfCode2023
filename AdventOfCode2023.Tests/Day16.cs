using AdventOfCode2023.Day16.Models;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day16Tests
    {
        [TestMethod]
        public void Part1Example()
        {
            var input = Example.Split(Environment.NewLine);
            var result = new Day16.Day16().Part1(input, (0, 0, Direction.East));
            Assert.AreEqual(46, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = new Day16.Day16().Part1();
            Assert.AreEqual(6361, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = new Day16.Day16().Part2();
            Assert.AreEqual(6701, result);
        }

        public static string Example = @".|...\....
|.-.\.....
.....|-...
........|.
..........
.........\
..../.\\..
.-.-/..|..
.|....-|.\
..//.|....";
    }
}
