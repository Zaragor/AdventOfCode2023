using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class MathHelpersTests
    {
        [TestMethod]
        public void CanFindPrimeFactors()
        {
            var result = MathHelpers.PrimeDivisors(2);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(2, result.First());
        }

        [TestMethod]
        public void CanFindPrimeFactorsOf6()
        {
            var result = MathHelpers.PrimeDivisors(6);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(2, result.First());
            Assert.AreEqual(3, result.Last());
        }

        [TestMethod]
        public void CanFindPrimeFactorsOf9()
        {
            var result = MathHelpers.PrimeDivisors(9);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(3, result.First());
            Assert.AreEqual(3, result.Last());
        }

        [TestMethod]
        public void CanFindPrimeFactorsOf11567()
        {
            var result = MathHelpers.PrimeDivisors(11567);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(43, result.First());
            Assert.AreEqual(269, result.Last());
        }

        [TestMethod]
        public void CanFindPrimeFactorsOf19637()
        {
            var result = MathHelpers.PrimeDivisors(19637);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(73, result.First());
            Assert.AreEqual(269, result.Last());
        }

    }
}
