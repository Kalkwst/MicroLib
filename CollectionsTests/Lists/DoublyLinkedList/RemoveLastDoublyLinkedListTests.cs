using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class RemoveLastDoublyLinkedListTests
    {
        [Test]
        public void RemoveLast_RemovesLastNode()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(3);
            list.AddFirst(4);
            list.AddFirst(99);
            var last = list.GetLast();
            list.RemoveLast();
            Assert.That(list.GetLast(), Is.Not.EqualTo(last));
        }
    }
}
