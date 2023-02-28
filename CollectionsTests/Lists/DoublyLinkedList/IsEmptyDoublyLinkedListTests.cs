using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class IsEmptyDoublyLinkedListTests
    {
        [Test]
        public void IsEmpty_ReturnsFalseWhenNotEmpty()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            Assert.IsFalse(list.IsEmpty());
        }

        [Test]
        public void IsEmpty_ReturnsTrueWhenEmpty()
        {
            var list = new DoublyLinkedList<int>();

            Assert.IsTrue(list.IsEmpty());
        }
    }
}
