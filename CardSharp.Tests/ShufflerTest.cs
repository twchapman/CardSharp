using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardSharp.Tests {
    [TestClass]
    public class ShufflerTest {
        [TestMethod]
        public void FisherYates_GivenKnownSequence_ShufflesIntoSequence() {
            var randomizer = new FakeRandomizer(0, 1, 2);
            var deck = new Deck<int>(new[] { 3, 2, 1 });
            var shuffler = new Shuffler(randomizer);

            var shuffledDeck = shuffler.FisherYates(deck);

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, shuffledDeck);
        }
    }
}
