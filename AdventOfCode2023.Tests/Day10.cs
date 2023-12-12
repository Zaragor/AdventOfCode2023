namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public void ExamplePart1()
        {
            var input = Example.Split(Environment.NewLine);
            Assert.AreEqual(8, Day10.Day10.Part1(input));
        }

        [TestMethod]
        public void ExamplePart2()
        {
            var input = Example.Split(Environment.NewLine);
            Assert.AreEqual(1, Day10.Day10.Part2(input));
        }

        [TestMethod]
        public void BasicExample()
        {
            var input = @"F-7
|.|
S-J";
            Assert.AreEqual(4, Day10.Day10.Part1(input.Split(Environment.NewLine)));
        }

        [TestMethod]
        public void BasicExamplePart2()
        {
            var input = @".....
.F-7.
.|.|.
.S-J.
.....";
            Assert.AreEqual(1, Day10.Day10.Part2(input.Split(Environment.NewLine)));
        }

        public static string Example = @"7-F7-
.FJ|7
SJLL7
|F--J
LJ.LJ";
    }
}
