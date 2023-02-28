using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class AddLastDoublyLinkedListTests
    {
        [Test]
        public void AddLast_WhenListIsEmpty_NodeAddedBecomesHeadAndTail()
        {
            var list = new DoublyLinkedList<object>();
            list.AddLast("one");
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list.GetFirst(), Is.EqualTo("one"));
            Assert.That(list.GetLast(), Is.EqualTo("one"));
        }
        [Test]
        public void AddLast_WhenListIsNotEmpty_NodeAddedAsTail()
        {
            var list = new DoublyLinkedList<object>();
            list.AddLast("one");
            list.AddLast("two");
            Assert.That(list.GetLast(), Is.EqualTo("two"));
        }
    }
}
