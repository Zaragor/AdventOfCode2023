namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day13Tests
    {
        private static Day13.Day13 Calculator = new Day13.Day13();
        [TestMethod]
        public void PartOneExample()
        {
            var input = Example.Split(Environment.NewLine);
            Assert.AreEqual(405, Calculator.Part1(input));
        }

        [TestMethod]
        public void TrivallyNotReflect()
        {
            var input = @"#..
..#".Split(Environment.NewLine);
            Assert.AreEqual(0, Calculator.FindHorizontalMirrors(input).Count());
        }

        [TestMethod]
        public void VerticalReflect()
        {
            var input = @"#.#
#.#".Split(Environment.NewLine);
            Assert.AreEqual(1, Calculator.FindVerticalMirrors(input).Count());
        }

        [TestMethod]
        public void AccountForSmudges()
        {
            var input = "....".Split(Environment.NewLine);
            var result = Calculator.AccountForSmudges(input).ToList();
            Assert.AreEqual(4, result.Count());
            Assert.AreEqual(1, result.First().Count());
            var first = result.First();
            Assert.AreEqual("#...", first.First());
            var second = result.Skip(1).First();
            Assert.AreEqual(".#..", second.First());
        }

        public static string Example = @"#.##..##.
..#.##.#.
##......#
##......#
..#.##.#.
..##..##.
#.#.##.#.

#...##..#
#....#..#
..##..###
#####.##.
#####.##.
..##..###
#....#..#";
    }
}
