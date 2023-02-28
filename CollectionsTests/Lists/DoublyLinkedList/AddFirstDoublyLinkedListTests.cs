using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class AddFirstDoublyLinkedListTests
    {
        [Test]
        public void AddFirst_WhenListIsEmpty_NodeAddedBecomesHeadAndTail()
        {
            var list = new DoublyLinkedList<object>();
            list.AddFirst("one");
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list.GetFirst(), Is.EqualTo("one"));
            Assert.That(list.GetLast(), Is.EqualTo("one"));
        }

        [Test]
        public void AddFirst_WhenListIsEmpty_NodeAddedBecomesFirst()
        {
            var list = new DoublyLinkedList<object>();
            list.AddFirst("one");
            list.AddFirst("two");
            Assert.That(list.GetFirst(), Is.EqualTo("two"));
        }
    }
}
