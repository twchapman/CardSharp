using System.Collections.Generic;

namespace CardSharp {
    internal interface IDeck<T> : IEnumerable<T> {
        bool Empty { get; }

        IEnumerable<Card<T>> Draw(int count = 1);
        void PutOnBottom(IEnumerable<Card<T>> cards);
        void PutOnTop(IEnumerable<Card<T>> cards);
    }
}
