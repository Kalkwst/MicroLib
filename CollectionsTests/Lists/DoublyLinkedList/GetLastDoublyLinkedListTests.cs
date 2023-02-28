using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class GetLastDoublyLinkedListTests
    {
        [Test]
        public void GetLast_WhenEmpty_ReturnsDefaultValue()
        {
            var list = new DoublyLinkedList<object>();
            var last = list.GetLast();
            Assert.IsNull(last);
        }
        [Test]
        public void GetLast_WhenNotEmpty_ReturnsValue()
        {
            var list = new DoublyLinkedList<object>();
            list.AddFirst(1.1f);
            list.AddLast(3);
            list.AddLast("last");
            var last = list.GetLast();
            Assert.That(last, Is.EqualTo("last"));
        }
    }
}
