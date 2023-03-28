using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTests.Lists;

[TestFixture]
internal class DoublyLinkedListTests
{
    [Test]
    public void AddAfter_WhenListIsEmpty_ThrowsKeyNotFoundException()
    {
        var list = new DoublyLinkedList<int>();
        Assert.Throws<KeyNotFoundException>(() => list.AddAfter(2, 9));
    }

    [Test]
    public void AddAfter_WhenListIsNotEmpty_AddsAfterSpecificNode()
    {
        var list = new DoublyLinkedList<int>();
        list.AddFirst(1);
        list.AddLast(2);
        list.AddAfter(2, 555);
        Assert.That(list.GetLast(), Is.EqualTo(555));
    }

    [Test]
    public void AddBefore_WhenListIsEmpty_ThrowsKeyNotFoundException()
    {
        var list = new DoublyLinkedList<int>();
        Assert.Throws<KeyNotFoundException>(() => list.AddBefore(2, 9));
    }

    [Test]
    public void AddBefore_WhenListIsNotEmpty_AddsAfterSpecificNode()
    {
        var list = new DoublyLinkedList<int>();
        list.AddFirst(1);
        list.AddLast(2);
        list.AddBefore(1, 555);
        Assert.That(list.First(), Is.EqualTo(555));
    }

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

    }
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

    [Test]
    public void IndexOf_ReturnsNegativeOneIfNotExists()
    {
        var list = new DoublyLinkedList<int>();
        list.AddFirst(1);
        var indexOf = list.IndexOf(3);
        Assert.That(indexOf, Is.EqualTo(-1));
    }

    [Test]
    public void IndexOf_ReturnsActualIndexOfNode()
    {
        var list = new DoublyLinkedList<int>();
        list.AddFirst(1);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(9);
        var indexOf = list.IndexOf(9);
        Assert.That(indexOf, Is.EqualTo(3));
    }

    [Test]
    public void IsEmpty_ReturnsFalseWhenNotEmpty()
    {
        var list = new DoublyLinkedList<int>();
        list.AddFirst(1);
        Assert.IsFalse(list.IsEmpty());
    }

    [Test]
    public void IsEmpty_ReturnsTrueWhenEmpty()
    {
        var list = new DoublyLinkedList<int>();

        Assert.IsTrue(list.IsEmpty());
    }

    [Test]
    public void Remove_RemovesNodeThatExistsInList()
    {
        var list = new DoublyLinkedList<int>();
        list.AddFirst(1);
        list.AddFirst(1);
        list.AddFirst(1);
        list.AddFirst(1);
        list.Remove(1);
        Assert.That(list.Count, Is.EqualTo(0));

    }

    [Test]
    public void Remove_DoesNotRemoveFromListNodeThatDoesNotExist()
    {
        var list = new DoublyLinkedList<int>();
        list.AddFirst(1);
        list.AddFirst(1);
        list.AddFirst(1);
        list.AddFirst(1);
        list.Remove(2);
        Assert.That(list.Count, Is.EqualTo(4));

    }

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

    [Test]
    public void RemoveLast_RemovesLastNode()
    {
        var list = new DoublyLinkedList<int>();
        list.AddFirst(1);
        list.AddFirst(3);
        list.AddFirst(4);
        list.AddFirst(99);
        var last = list.GetLast();
        list.RemoveLast();
        Assert.That(list.GetLast(), Is.Not.EqualTo(last));
    }

    [Test]
    public void ToString_PrintsDoublyLinkedList()
    {
        var list = new DoublyLinkedList<int>();
        list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);
        Assert.That(list.ToString(), Is.EqualTo("{3, 2, 1}"));
    }
}
