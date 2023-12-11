using AdventOfCode2023.Day7;
using AdventOfCode2023.Day7.Models;
namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day7Tests
    {
        [TestMethod]
        public void Part1Example()
        {
            Assert.AreEqual(6440, Day7.Day7.Part1(example.Split(Environment.NewLine)));
        }

        [TestMethod]
        public void CompareTwo()
        {
            var hand1 = new CardHand("T55J5", 0);
            var hand2 = new CardHand("KK677", 0);
            var comparer = new CardComparer();
            Assert.IsTrue(comparer.Compare(hand1, hand2) > 0);
        }

        [TestMethod]
        public void CompareEqual()
        {
            var hand1 = new CardHand("T55J5", 0);
            var hand2 = new CardHand("T55J5", 0);
            var comparer = new CardComparer();
            Assert.AreEqual(0, comparer.Compare(hand1, hand2));
        }

        [TestMethod]
        public void CompareSameType()
        {
            var hand1 = new CardHand("T55J5", 0);
            var hand2 = new CardHand("KKK67", 0);
            var comparer = new CardComparer();
            Assert.IsTrue(comparer.Compare(hand1, hand2) < 0);
        }

        [TestMethod]
        public void CompareSameTypeLastDiffers()
        {
            var hand1 = new CardHand("KKK65", 0);
            var hand2 = new CardHand("KKK67", 0);
            var comparer = new CardComparer();
            Assert.IsTrue(comparer.Compare(hand1, hand2) < 0);
        }

        [TestMethod]
        public void CompareWildcard()
        {
            var hand1 = new CardHand("KKK6J", 0, true);
            var hand2 = new CardHand("KKK67", 0, true);
            var comparer = new CardComparer();
            Assert.IsTrue(comparer.Compare(hand1, hand2) > 0);
        }

        [TestMethod]
        public void JokerIsWeakest()
        {
            var hand1 = new CardHand("KKJ67", 0, true);
            var hand2 = new CardHand("KK2K7", 0, true);
            var comparer = new CardComparer();
            Assert.IsTrue(comparer.Compare(hand1, hand2) < 0);
        }

        [TestMethod]
        public void JokerMakesFive()
        {
            var hand = new CardHand("KKJKK", 0, true);
            Assert.AreEqual(HandType.FiveOfAKind, hand.HandType);
        }

        [DataTestMethod]
        [DataRow("JJJJJ", HandType.FiveOfAKind)]
        [DataRow("JJJJK", HandType.FiveOfAKind)]
        [DataRow("JJJKK", HandType.FiveOfAKind)]
        [DataRow("JJKKK", HandType.FiveOfAKind)]
        [DataRow("JKKKK", HandType.FiveOfAKind)]
        [DataRow("KKKKK", HandType.FiveOfAKind)]
        [DataRow("JJJK6", HandType.FourOfAKind)]
        [DataRow("JJJK6", HandType.FourOfAKind)]
        [DataRow("JJKK6", HandType.FourOfAKind)]
        [DataRow("JKKK6", HandType.FourOfAKind)]
        [DataRow("KKKK6", HandType.FourOfAKind)]
        [DataRow("KKK76", HandType.ThreeOfAKind)]
        public void JokerActsAsWildcard(string input, HandType type)
        {
            var hand = new CardHand(input, 0, true);
            Assert.AreEqual(type, hand.HandType);
        }

        private const string example = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";
    }
}
