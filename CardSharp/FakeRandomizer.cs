using System;
using System.Collections.Generic;
using System.Text;

namespace CardSharp {
    internal class FakeRandomizer : IRandomizer<int> {
        private readonly int[] sequence;
        private int _currentIndex;
        private int currentIndex {
            get => _currentIndex;
            set {
                if (value >= sequence.Length) _currentIndex = 0;
                else _currentIndex = value;
            }
        }

        public FakeRandomizer(params int[] sequence) {
            this.sequence = sequence;
        }

        public int Next() {
            int value = sequence[currentIndex];
            currentIndex++;
            return value;
        }
    }
}
