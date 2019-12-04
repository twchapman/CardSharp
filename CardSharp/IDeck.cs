using System.Collections.Generic;

namespace CardSharp {
    internal interface IDeck<T> {
        T Draw();
        IEnumerable<T> Draw(int count);
    }
}
