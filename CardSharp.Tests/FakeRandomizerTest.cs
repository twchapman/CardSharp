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

            Assert.AreEqual(1, randomizer.Next());
            Assert.AreEqual(1, randomizer.Next());
        }

        [TestMethod]
        public void GetNext_GivenSequence_ReturnsSequenceInOrder() {
            var randomizer = new FakeRandomizer(1, 2, 3, 4);

            var sequence = new[] { randomizer.Next(), randomizer.Next(), randomizer.Next(), randomizer.Next() };
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, sequence);
        }
    }
}
