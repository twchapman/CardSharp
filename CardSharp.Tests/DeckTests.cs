using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardSharp.Tests {
    [TestClass]
    public class DeckTests {
        [TestMethod]
        public void Draw_NoCountGiven_DrawsOneCard() {
            var deck = new Deck<int>(new [] { 1, 2, 3 });

            Assert.AreEqual(1, deck.Draw());
        }

        [TestMethod]
        public void Draw_DeckEmpty_ThrowsDeckEmptyException() {
            var deck = new Deck<int>(new int[0]);

            Assert.ThrowsException<DeckEmptyException>(() => deck.Draw());
        }
    }
}