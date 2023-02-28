using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class GetFirstDoublyLinkedListTests
    {
        [Test]
        public void GetFirst_WhenEmpty_ReturnsDefaultValue() 
        {
            var list = new DoublyLinkedList<object>();
            var first = list.GetFirst();
            Assert.IsNull(first);
        }
        [Test]
        public void GetFirst_WhenNotEmpty_ReturnsValue()
        {
            var list = new DoublyLinkedList<object>();
            list.AddFirst(1.1f);
            list.AddLast(3);
            list.AddFirst("last");
            var first = list.GetFirst();
            Assert.That(first, Is.EqualTo("last"));
        }
    }
}
