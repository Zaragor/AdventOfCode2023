namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day12Tests
    {
        private Day12.Day12 Calculator = new Day12.Day12();
        [TestMethod]
        public void PartOneExample()
        {
            var input = Example.Split(Environment.NewLine);
            Assert.AreEqual(21, Calculator.Part1(input));
        }

        [TestMethod]
        public void OneDeadSpring()
        {
            var input = "..#? 1,1";
            Assert.AreEqual(0, Calculator.PossibleSolutions(input));
        }

        [TestMethod]
        public void OneDeadSpringFollowedByQuestion()
        {
            var input = "..#?. 1,1";
            Assert.AreEqual(0, Calculator.PossibleSolutions(input));
        }

        public static string Example = @"???.### 1,1,3
.??..??...?##. 1,1,3
?#?#?#?#?#?#?#? 1,3,1,6
????.#...#... 4,1,1
????.######..#####. 1,6,5
?###???????? 3,2,1";
    }
}
