using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class IndexOfDoublyLinkedListTests
    {
        [Test]
        public void IndexOf_ReturnsNegativeOneIfNotExists()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            var indexOf = list.IndexOf(3);
            Assert.That(indexOf, Is.EqualTo(-1));
        }

        [Test]
        public void IndexOf_ReturnsActualIndexOfNode()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(3);
            list.AddFirst(2);
            list.AddLast(9);
            var indexOf = list.IndexOf(9);
            Assert.That(indexOf, Is.EqualTo(3));
        }

    }
}
