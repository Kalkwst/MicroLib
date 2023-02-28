using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class ContainsDoublyLinkedListTests
    {
        [Test]
        public void Contains_ReturnsTrueWhenItContainsItem()
        {
            var list = new DoublyLinkedList<string>();
            list.AddFirst("1");
            list.AddLast("2");
            list.AddLast("3");
            Assert.IsTrue(list.Contains("1"));
        }
        [Test]
        public void Contains_ReturnsFalseWhenItDoesntContainItem() 
        {
            var list = new DoublyLinkedList<string>();
            list.AddFirst("1");
            list.AddLast("2");
            list.AddLast("3");
            Assert.IsFalse(list.Contains("0"));
        }
    }
}
