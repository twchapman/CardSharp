using System;
using System.Collections.Generic;
using System.Linq;

namespace CardSharp {
    public class Deck<T> : List<Card<T>>, IDeck<T> {
        public Deck() : base() { }
        public Deck(IEnumerable<Card<T>> cards) : base(cards) { }

        public bool Empty => Count == 0;

        public IEnumerable<Card<T>> Draw(int count = 1) {
            if (Empty) throw new DeckEmptyException();

            count = Math.Min(count, Count);
            var items = GetRange(0, count);
            RemoveRange(0, count);
            return items;
        }

        public void PutOnBottom(IEnumerable<Card<T>> cards) {
            AddRange(cards);
        }

        public void PutOnTop(IEnumerable<Card<T>> cards) {
            InsertRange(0, cards);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => ToArray().Select(card => card.Data).GetEnumerator();
        internal void Add(T data) => Add(new Card<T>(data));

    }
}