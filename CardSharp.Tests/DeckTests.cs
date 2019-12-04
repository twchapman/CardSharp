using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CardSharp.Tests {
    [TestClass]
    public class DeckTests {
        [TestMethod]
        public void Draw_NoCountGiven_DrawsOneCard() {
            var deck = new Deck<int>(new[] { 1, 2, 3 });

            Assert.AreEqual(1, deck.Draw());
        }

        [TestMethod]
        public void Draw_NoCountGiven_RemovesDrawnCard() {
            var deck = new Deck<int>(new[] { 1, 2, 3 });

            deck.Draw();

            CollectionAssert.AreEqual(new[] { 2, 3 }, deck);
        }

        [TestMethod]
        public void Draw_DeckEmpty_ThrowsDeckEmptyException() {
            var deck = new Deck<int>(new int[0]);

            Assert.ThrowsException<DeckEmptyException>(() => deck.Draw());
        }

        [TestMethod]
        public void Draw_DrawThreeCards_DrawsSpecificAmount() {
            var deck = new Deck<int>(new[] { 1, 2, 3 });

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, deck.Draw(3).ToList());
        }

        [TestMethod]
        public void Draw_DrawTwoCards_CardsRemovedFromDeck() {
            var deck = new Deck<int>(new[] { 1, 2, 3 });

            deck.Draw(2);

            CollectionAssert.AreEqual(new[] { 3 }, deck);
        }

        [TestMethod]
        public void Draw_DrawTwoCardsWithDeckEmpty_ThrowsDeckEmptyException() {
            var deck = new Deck<int>(new int[0]);

            Assert.ThrowsException<DeckEmptyException>(() => deck.Draw(2));
        }

        [TestMethod]
        public void Draw_NotEnoughCardsToDraw_DrawsRemainderOfDeck() {
            var deck = new Deck<int>(new[] { 1, 2 });

            CollectionAssert.AreEqual(new[] { 1, 2 }, deck.Draw(3).ToList());
        }

        [TestMethod]
        public void PutOnBottom_SingleCard_CardPutOnBottomOfDeck() {
            var deck = new Deck<int>(new[] { 1, 2 });

            deck.PutOnBottom(3);

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, deck);
        }

        [TestMethod]
        public void PutOnBottom_ThreeCards_CardsPutOnBottomOfDeck() {
            var deck = new Deck<int>(new[] { 1 });

            deck.PutOnBottom(new[] { 2, 3, 4 } );

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, deck);
        }

        [TestMethod]
        public void PutOnTop_SingleCard_CardPutOnTopOfDeck() {
            var deck = new Deck<int>(new[] { 2, 3 });

            deck.PutOnTop(1);

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, deck);
        }

        [TestMethod]
        public void PutOnTop_ThreeCards_CardsPutOnTopOfDeck() {
            var deck = new Deck<int>(new[] { 4 });

            deck.PutOnTop(new[] { 1, 2, 3 });

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, deck);
        }
    }
}