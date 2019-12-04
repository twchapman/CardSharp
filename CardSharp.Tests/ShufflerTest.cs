using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardSharp.Tests {
    [TestClass]
    public class ShufflerTest {
        [TestMethod]
        public void FisherYates_GivenKnownSequence_ShufflesIntoSequence() {
            // This test really just exercises the algorithm
            var randomizer = new FakeRandomizer(2, 0);
            var deck = new Deck<int>(new[] { 3, 2, 1 });
            var shuffler = new Shuffler(randomizer);

            var shuffledDeck = shuffler.FisherYates(deck);

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, shuffledDeck);
        }
        
        [TestMethod]
        public void FisherYates_GivenRandomSequence_ShufflesIntoSequence() {
            int seed = 43770;
            var random = new Random(seed);
            var randomizer = new DotNetRandomizer(seed);

            var deck = new Deck<int>(new[] { 1, 2, 3 });
            var shuffler = new Shuffler(randomizer);

            var expectedDeck = new Deck<int>(deck);
            expectedDeck.Swap(0, random.Next(3));
            expectedDeck.Swap(1, 1 + random.Next(2));

            var shuffledDeck = shuffler.FisherYates(deck);

            CollectionAssert.AreEqual(expectedDeck, shuffledDeck);
        }
    }
}
