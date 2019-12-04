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

        public void PutOnBottom(T card) {
            PutOnBottom(new[] { card });
        }

        public void PutOnBottom(IEnumerable<T> cards) {
            AddRange(cards);
        }

        private T Pull(int index = 0) {
            var item = this[index];
            RemoveAt(index);
            return item;
        }
    }
}