using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CardSharp.Tests {
    [TestClass]
    public class CardTests {
        [TestMethod]
        public void Card_SingleCard_ConvertToList() {
            var card = new Card<int>();

            CollectionAssert.AreEqual(new[] { card }, (List<Card<int>>)card);
        }

        [TestMethod]
        public void Card_ListOf1Cards_ConvertToSingleCard() {
            var card = new Card<int>();

            Assert.AreEqual<Card<int>>(card, new List<Card<int>> { card });
        }

        [TestMethod]
        public void Card_ListOf3CardsCard_Throws() {
            var card = new Card<int>();

            var list = new List<Card<int>> { card, card };

            var exception = Assert.ThrowsException<InvalidCastException>(() => (Card<int>)list);
            Assert.AreEqual(exception.Message, "Can only cast a List of 1 cards to a Single card, found 2 instead.");
        }
    }
}