using AdventOfCode2023.Day3.Models;
namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void Part1Example()
        {
            var example = "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..";
            var result = Day3.Day3.Part1(example.Split(Environment.NewLine));
            Assert.AreEqual(4361, result);
        }
        [TestMethod]
        public void Part2Example()
        {
            var example = "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..";
            var result = Day3.Day3.Part2(example.Split(Environment.NewLine));
            Assert.AreEqual(467835, result);
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(537832, Day3.Day3.Part1());
        }


        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(81939900, Day3.Day3.Part2());
        }
        [TestMethod]
        public void ParsesEngineRow()
        {
            var example = "617*......";
            var result = new EngineRow(example);
            Assert.AreEqual(1, result.SymbolIndex.Count());
            Assert.AreEqual(3, result.SymbolIndex.First());
        }

        [TestMethod]
        public void ParsesEngineWithTwoParts()
        {
            var example = "467..114..";
            var result = new EngineRow(example);
            Assert.AreEqual(2, result.PartNumbers.Count());
            Assert.AreEqual(467, result.PartNumbers.First().Id);
            Assert.AreEqual(114, result.PartNumbers.Last().Id);
        }

        [TestMethod]
        public void ParsesEngineRowWithEndingDigit()
        {
            var example = "........56";
            var result = new EngineRow(example);
            Assert.AreEqual(1, result.PartNumbers.Count());
            Assert.AreEqual(56, result.PartNumbers.First().Id);
            Assert.AreEqual(8, result.PartNumbers.First().StartIndex);
            Assert.AreEqual(9, result.PartNumbers.First().EndIndex);
        }

        [TestMethod]
        public void EngineRowValidAfter()
        {
            var example = "617.......";
            var result = new EngineRow(example);
            var preceding = new EngineRow("...*......");
            var isValid = result.PartNumbers.First().IsValid(new List<EngineRow> { preceding });
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void EngineRowValidBefore()
        {
            var example = ".617......";
            var result = new EngineRow(example);
            var preceding = new EngineRow("*.........");
            var isValid = result.PartNumbers.First().IsValid(new List<EngineRow> { preceding });
            Assert.IsTrue(isValid);
        }
    }
}
