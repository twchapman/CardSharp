using System;
using System.Collections.Generic;
using System.Linq;

namespace CardSharp {
    public class Deck<T> : List<T>, IDeck<T> {
        public Deck() : base() { }
        public Deck(IEnumerable<T> cards) : base(cards) { }

        public bool Empty => Count == 0;

        public T Draw() {
            return Draw(1).First();
        }

        public IEnumerable<T> Draw(int count) {
            if (Empty) throw new DeckEmptyException();

            count = Math.Min(count, Count);
            var items = GetRange(0, count);
            RemoveRange(0, count);
            return items;
        }
    }
}