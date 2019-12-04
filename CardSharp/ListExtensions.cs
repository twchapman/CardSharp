using System.Collections.Generic;

namespace CardSharp {
    public static class ListExtensions {
        public static IList<T> Swap<T>(this IList<T> list, int firstIndex, int secondIndex) {
            T temp = list[secondIndex];
            list[secondIndex] = list[firstIndex];
            list[firstIndex] = temp;
            return list;
        }
    }
}
