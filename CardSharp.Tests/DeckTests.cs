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
            var deck = new Deck<int>(new[] { 1, 2, 3 });

            var topCard = deck.Draw();
            deck.PutOnBottom(topCard);

            CollectionAssert.AreEqual(new[] { 2, 3, 1 }, deck);
        }

        [TestMethod]
        public void PutOnBottom_ThreeCards_CardsPutOnBottomOfDeck() {
            var deck = new Deck<int>(new[] { 1, 2, 3, 4 });

            var topThree = deck.Draw(3);
            deck.PutOnBottom(topThree);

            CollectionAssert.AreEqual(new[] { 4, 1, 2, 3 }, deck);
        }
    }
}