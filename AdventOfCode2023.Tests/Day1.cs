namespace AdventOfCode2023.Tests
{
    using Day1;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class Day1Tests
    {
        [TestMethod]
        public void Part1Example()
        {
            var example = $"1abc2\r\npqr3stu8vwx\r\na1b2c3d4e5f\r\ntreb7uchet".Split(Environment.NewLine);
            Assert.AreEqual(142, Day1.Part1(example));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(56506, Day1.Part1());
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(56017, Day1.Part2());
        }

        [TestMethod]
        public void Part2Example()
        {
            var example = "two1nine\r\neightwothree\r\nabcone2threexyz\r\nxtwone3four\r\n4nineeightseven2\r\nzoneight234\r\n7pqrstsixteen".Split(Environment.NewLine);
            Assert.AreEqual(281, Day1.Part2(example));
        }

        [TestMethod]
        public void abcone2threexyz()
        {
            Assert.AreEqual(1, Day1.GetDigits("abcone2threexyz").First());
            Assert.AreEqual(3, Day1.GetDigits("abcone2threexyz").Last());
        }
    }
}