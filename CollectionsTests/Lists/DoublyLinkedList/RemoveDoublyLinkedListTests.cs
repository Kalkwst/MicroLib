using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class RemoveDoublyLinkedListTests
    {
        [Test]
        public void Remove_RemovesNodeThatExistsInList()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(1);
            list.AddFirst(1);
            list.AddFirst(1);
            list.Remove(1);
            Assert.That(list.Count, Is.EqualTo(0));

        }
        [Test]
        public void Remove_DoesNotRemoveFromListNodeThatDoesNotExist()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(1);
            list.AddFirst(1);
            list.AddFirst(1);
            list.Remove(2);
            Assert.That(list.Count, Is.EqualTo(4));

        }
    }
}
