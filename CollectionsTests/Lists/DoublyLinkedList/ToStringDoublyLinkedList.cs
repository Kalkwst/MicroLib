using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class ToStringDoublyLinkedList
    {
        [Test]
        public void ToString_PrintsDoublyLinkedList()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            Assert.That(list.ToString(),Is.EqualTo("{3, 2, 1}"));
        }
    }
}
