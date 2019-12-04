using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardSharp.Tests {
    [TestClass]
    public class ShufflerTest {
        [TestMethod]
        public void FisherYates_GivenKnownSequence_ShufflesIntoSequence() {
            // This test really just exercises the algorithm
            var randomizer = new FakeRandomizer(2, 0);
            var deck = new Deck<int>(new Card<int>[] { 3, 2, 1 });
            var shuffler = new Shuffler(randomizer);

            shuffler.FisherYates(deck);

            var expected = new Deck<int>(new Card<int>[] { 1, 2, 3 });
            CollectionAssert.AreEqual(expected, deck);
        }
        
        [TestMethod]
        public void FisherYates_GivenRandomSequence_ShufflesIntoSequence() {
            int seed = 43770;
            var random = new Random(seed);
            var randomizer = new DotNetRandomizer(seed);

            var deck = new Deck<int>(Card.Make(1, 2, 3 ));
            var shuffler = new Shuffler(randomizer);

            var expectedDeck = deck.Clone();
            expectedDeck.Swap(0, random.Next(3));
            expectedDeck.Swap(1, 1 + random.Next(2));

            shuffler.FisherYates(deck);

            CollectionAssert.AreEqual(expectedDeck, deck);
        }
    }
}
