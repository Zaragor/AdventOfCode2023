namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day15Tests
    {
        private Day15.Day15 Calculator = new Day15.Day15();

        [TestMethod]
        public void Par1()
        {
            Assert.AreEqual(495972, Calculator.Part1());
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(245223, Calculator.Part2());
        }

        [TestMethod]
        public void Part2Example()
        {
            var input = "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7";
            Assert.AreEqual(145, Calculator.Part2(input));
        }
    }
}
