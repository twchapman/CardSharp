using System;
using System.Collections.Generic;
using System.Linq;

namespace CardSharp {
    public class Card<T> {
        public Card() { }
        public Card(T data) {
            Data = data;
        }

        public T Data { get; set; }

        public static implicit operator List<Card<T>>(Card<T> card) => new List<Card<T>> { card };
        public static implicit operator Card<T>(List<Card<T>> cards) {
            if (cards.Count != 1) throw new InvalidCastException($"Can only cast a List of 1 cards to a Single card, found {cards.Count} instead.");
            return cards.First();
        }
    }
}
