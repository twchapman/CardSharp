using System;
using System.Collections;
using System.Collections.Generic;

namespace CardSharp {
    public class Deck<T> : List<T>, IDeck<T> {
        public Deck() : base() { }
        public Deck(IEnumerable<T> cards) : base(cards) { }

        public bool Empty => Count == 0;

        public T Draw() {
            if (Empty) throw new DeckEmptyException();

            var item = this[0];
            RemoveAt(0);
            return item;
        }
    }
}