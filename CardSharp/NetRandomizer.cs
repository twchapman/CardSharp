using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardSharp {
    public class DotNetRandomizer : IRandomizer<int> {
        private readonly Random random;

        public DotNetRandomizer(int seed) {
            this.random = new Random(seed);
        }

        public int Next(int max) => random.Next(max);
    }
}
