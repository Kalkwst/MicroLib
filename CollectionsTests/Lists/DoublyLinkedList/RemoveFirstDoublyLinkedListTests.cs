using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class RemoveFirstDoublyLinkedListTests
    {
        [Test]
        public void RemoveFirst_RemovesFirstNode() 
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(3);
            list.AddFirst(4);
            list.AddFirst(99);
            var first = list.GetFirst();
            list.RemoveFirst();
            Assert.That(list.GetFirst(), Is.Not.EqualTo(first));
        }
    }
}
