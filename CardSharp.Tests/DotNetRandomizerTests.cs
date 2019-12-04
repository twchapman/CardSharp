using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardSharp.Tests {
    [TestClass]
    public class DotNetRandomizerTests {
        [TestMethod]
        public void Next_GivenKnownSeed_ReplicatesValues() {
            int seed = 43770;
            var systemRandom = new Random(seed);
            var randomizer = new DotNetRandomizer(seed);

            var systemValues = new[] { systemRandom.Next(10), systemRandom.Next(10), systemRandom.Next(10) };
            var randomizerValues = new[] { randomizer.Next(10), randomizer.Next(10), randomizer.Next(10) };

            CollectionAssert.AreEqual(systemValues, randomizerValues);
        }
    }
}