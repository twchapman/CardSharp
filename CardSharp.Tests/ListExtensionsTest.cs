using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CardSharp.Tests {
    [TestClass]
    public class ListExtensionsTest {
        [TestMethod]
        public void Swap_TwoItemsInList_ItemsSwitchPosition() {
            List<int> list = new List<int> { 1, 2 };
            list.Swap(0, 1);
            CollectionAssert.AreEqual(list, new List<int> { 2, 1 });
        }
    }
}
