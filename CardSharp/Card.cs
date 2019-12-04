using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CardSharp {
    public class Card<T> : IEnumerable<Card<T>> {
        public Card() { }
        public Card(T data) {
            Data = data;
        }

        public T Data { get; set; }

        public IEnumerator<Card<T>> GetEnumerator() {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public static implicit operator List<Card<T>>(Card<T> card) => new List<Card<T>> { card };
        public static implicit operator Card<T>(List<Card<T>> cards) {
            if (cards.Count != 1) throw new InvalidCastException($"Can only cast a List of 1 cards to a Single card, found {cards.Count} instead.");
            return cards.First();
        }

        public static implicit operator Card<T>(T data) => new Card<T>(data);
    }
}
