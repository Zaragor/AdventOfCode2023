namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day9Tests
    {
        [TestMethod]
        public void PartOneExample()
        {
            var input = Example.Split(Environment.NewLine);
            Assert.AreEqual(114, Day9.Day9.Part1(input));
        }

        [TestMethod]
        public void ConstantDifference()
        {
            var input = "0 3 6 9 12 15";
            Assert.AreEqual(18, Day9.Day9.NextNumber(input.Split(' ').Select(int.Parse)));
        }

        [TestMethod]
        public void SecondOrderDifference()
        {
            var input = "1 3 6 10 15 21";
            Assert.AreEqual(28, Day9.Day9.NextNumber(input.Split(' ').Select(int.Parse)));
        }

        [TestMethod]
        public void PartTwoExample()
        {
            var input = Example.Split(Environment.NewLine);
            Assert.AreEqual(2, Day9.Day9.Part2(input));
        }

        [TestMethod]
        public void WorkedExamplePartTwo()
        {
            var input = "10 13 16 21 30 45".Split(' ').Select(int.Parse);
            Assert.AreEqual(5, Day9.Day9.PreviousNumber(input));
        }



        [TestMethod]
        public void FirstExamplePartTwo()
        {
            var input = "0 3 6 9 12 15".Split(' ').Select(int.Parse);
            Assert.AreEqual(-3, Day9.Day9.PreviousNumber(input));
        }
        [TestMethod]
        public void SecondExamplePartTwo()
        {
            var input = "1 3 6 10 15 21".Split(' ').Select(int.Parse);
            Assert.AreEqual(0, Day9.Day9.PreviousNumber(input));
        }

        public static string Example = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";
    }
}
