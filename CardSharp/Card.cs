using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CardSharp {
    public static class Card {
        public static Card<T> Make<T>(T dataModel) => Make(new[] { dataModel }).First();
        public static Card<T>[] Make<T>(params T[] dataModels) => dataModels.Select(data => new Card<T>(data)).ToArray();
    }

    public class Card<T> {
        public Card() { }
        public Card(T data) {
            Data = data;
        }

        public T Data { get; set; }

        public IEnumerator<Card<T>> GetEnumerator() {
            yield return this;
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            var isArrayOfThis = typeof(Card<T>[]).Equals(obj.GetType());
            if (!GetType().Equals(obj.GetType()) && !isArrayOfThis) return false;

            Card<T> card;
            if (isArrayOfThis) {
                var array = obj as Card<T>[];
                if (array.Length != 1) return false;
                card = array.First();
            } else {
                card = obj as Card<T>;
            }

            return card.Data.Equals(Data);
        }

        public override int GetHashCode() {
            return base.GetHashCode() ^ Data.GetHashCode();
        }

        public static implicit operator Card<T>[](Card<T> card) => new[] { card };
        public static implicit operator Card<T>(Card<T>[] cards) {
            if (cards.Length != 1) throw new InvalidCastException($"Can only cast a List of 1 cards to a Single card, found {cards.Length} instead.");
            return cards.First();
        }

        public static implicit operator Card<T>(T data) => new Card<T>(data);
    }
}
