namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day14Tests
    {
        private Day14.Day14 Calculator = new Day14.Day14();
        [TestMethod]
        public void Part1Example()
        {
            var input = Example.Split(Environment.NewLine);
            Assert.AreEqual(136, Calculator.Part1(input));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(109661, Calculator.Part1());
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(90176, Calculator.Part2());
        }

        [TestMethod]
        public void Part2Example()
        {
            var input = Example.Split(Environment.NewLine);
            Assert.AreEqual(64, Calculator.Part2(input));
        }

        [TestMethod]
        public void TiltEastTest()
        {
            var initial = "..#..O..#..OO".Split(Environment.NewLine).Select(i => i.ToCharArray()).ToArray();
            var result = this.Calculator.TiltEast(initial);
            Assert.AreEqual("..#O....#OO..", new string(result.First()));
        }

        [TestMethod]
        public void TiltEastTestAdjacent()
        {
            var initial = "..#..O..#O.OO".Split(Environment.NewLine).Select(i => i.ToCharArray()).ToArray();
            var result = this.Calculator.TiltEast(initial);
            Assert.AreEqual("..#O....#OOO.", new string(result.First()));
        }

        [TestMethod]
        public void TiltEastTestStarting()
        {
            var initial = ".O#..O..#O.OO".Split(Environment.NewLine).Select(i => i.ToCharArray()).ToArray();
            var result = this.Calculator.TiltEast(initial);
            Assert.AreEqual("O.#O....#OOO.", new string(result.First()));
        }

        [TestMethod]
        public void TiltNorthTest()
        {
            var initial = @".
.
O
#
.
.
O
O
.
#
O";
            var result = this.Calculator.TiltNorth(initial.Split(Environment.NewLine).Select(i => i.ToCharArray()).ToArray());
            var final = string.Join(Environment.NewLine, result.Select(i => new string(i)));
            Assert.AreEqual(@"O
.
.
#
O
O
.
.
.
#
O", final);
        }

        [TestMethod]
        public void TiltSouthTest()
        {
            var initial = @"O
.
O
#
.
.
O
O
.
#
O";
            var result = this.Calculator.TiltSouth(initial.Split(Environment.NewLine).Select(i => i.ToCharArray()).ToArray());
            var final = string.Join(Environment.NewLine, result.Select(i => new string(i)));
            Assert.AreEqual(@".
O
O
#
.
.
.
O
O
#
O", final);
        }

        public static string Example = @"O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....";
    }
}
