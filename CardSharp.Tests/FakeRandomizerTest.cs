using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardSharp.Tests {
    [TestClass]
    public class FakeRandomizerTest {
        [TestMethod]
        public void GetNext_GivenSingleNumber_ReturnsNumber() {
            var randomizer = new FakeRandomizer(1);

            Assert.AreEqual(1, randomizer.Next(0));
            Assert.AreEqual(1, randomizer.Next(0));
        }

        [TestMethod]
        public void GetNext_GivenSequence_ReturnsSequenceInOrder() {
            var randomizer = new FakeRandomizer(1, 2, 3, 4);

            var sequence = new[] { randomizer.Next(0), randomizer.Next(0), randomizer.Next(0), randomizer.Next(0) };
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, sequence);
        }
    }
}
