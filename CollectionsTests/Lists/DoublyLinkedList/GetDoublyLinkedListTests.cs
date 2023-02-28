using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class GetDoublyLinkedListTests
    {
        [Test]
        public void Get_ThrowsExceptionWhenOutOfRange() 
        {
            var list = new DoublyLinkedList<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(5));
        }
        [Test]
        public void Get_ReturnsCorrectInteger()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            var integer = list.Get(2);
            Assert.That(integer, Is.EqualTo(3));
        }
        [Test]
        public void Get_ReturnsCorrectString()
        {
            var list = new DoublyLinkedList<string>();
            list.AddFirst("one");
            list.AddLast("two");
            list.AddLast("three");
            list.AddLast("four");
            list.AddLast("five");
            var integer = list.Get(4);
            Assert.That(integer, Is.EqualTo("five"));
        }
        [Test]
        public void Get_ReturnsCorrectObject()
        {
            var list = new DoublyLinkedList<object>();
            list.AddFirst(1);
            list.AddLast("two");
            list.AddLast(2.3);
            list.AddLast(55.2f);
            var integer = list.Get(3);
            Assert.That(integer, Is.EqualTo(55.2f));
        }
    }
}
