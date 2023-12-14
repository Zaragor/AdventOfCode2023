using AdventOfCode2023.Day2.Models;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        public void GameConstructor_ParsesId()
        {
            var inputTest = "Game 135: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
            var game = new Game(inputTest);
            Assert.AreEqual(game.Id, 135);
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(2268, Day2.Day2.Part1());
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(63542, Day2.Day2.Part2());
        }

        [TestMethod]
        public void GameConstructor_ParsesRolls()
        {
            var inputTest = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
            var game = new Game(inputTest);
            Assert.AreEqual(game.RollSet.Count(), 3);
            Assert.AreEqual(Color.Blue, game.RollSet.First().Rolls.First().Color);
        }
    }
}
