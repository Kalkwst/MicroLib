using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class ClearDoublyLinkedListTests
    {
        [Test]
        public void Clear_ClearsEverythingAndMakesCountEqualToZero() 
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            list.Clear();
            Assert.That(list.Count, Is.EqualTo(0));
            Assert.That(list.GetFirst(), Is.EqualTo(0));
            Assert.That(list.GetLast(), Is.EqualTo(0));
        }
    }
}
