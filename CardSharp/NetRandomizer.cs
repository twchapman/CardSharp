using System;

namespace CardSharp {
    public class DotNetRandomizer : IRandomizer<int> {
        private readonly Random random;

        public DotNetRandomizer(int seed) {
            this.random = new Random(seed);
        }

        public int Next(int max) => random.Next(max);
    }
}
