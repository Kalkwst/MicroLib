using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class AddAfterDoublyLinkedListTests
    {
        [Test]
        public void AddAfter_WhenListIsEmpty_ThrowsKeyNotFoundException()
        {
            var list = new DoublyLinkedList<int>();
            Assert.Throws<KeyNotFoundException>(() => list.AddAfter(2, 9));
        }

        public void AddAfter_WhenListIsNotEmpty_AddsAfterSpecificNode()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddAfter(2,555);
            Assert.That(list.GetLast(), Is.EqualTo(555));
        }
    }
}
