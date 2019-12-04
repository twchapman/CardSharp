using System.Collections.Generic;

namespace CardSharp {
    internal interface IDeck<T> : IEnumerable<T> {
        bool Empty { get; }

        Card<T>[] Draw(int count = 1);
        void PutOnBottom(Card<T>[] cards);
        void PutOnTop(Card<T>[] cards);
    }
}
