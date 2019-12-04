using System;
using System.Collections.Generic;
using System.Linq;

namespace CardSharp {
    public class Deck<T> : List<Card<T>>, IDeck<T> {
        public Deck() : base() { }
        public Deck(Card<T>[] cards) : base(cards) { }
        public Deck<T> Clone() {
            var cardData = ToArray().Select(card => card.Data).ToArray();
            var clonedCards = Card.Make(cardData);
            return new Deck<T>(clonedCards);
        }

        public bool Empty => Count == 0;

        public Card<T>[] Draw(int count = 1) {
            if (Empty) throw new DeckEmptyException();

            count = Math.Min(count, Count);
            var items = GetRange(0, count);
            RemoveRange(0, count);
            return items.ToArray();
        }

        public void PutOnBottom(Card<T>[] cards) {
            AddRange(cards);
        }

        public void PutOnTop(Card<T>[] cards) {
            InsertRange(0, cards);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => ToArray().Select(card => card.Data).GetEnumerator();
        internal void Add(T data) => Add(new Card<T>(data));

    }
}