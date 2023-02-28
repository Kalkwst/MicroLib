namespace CollectionsTests.Lists.DoublyLinkedList
{
    [TestFixture]
    internal class AddBeforeDoublyLinkedListTests
    {
        [Test]
        public void AddBefore_WhenListIsEmpty_ThrowsKeyNotFoundException()
        {
            var list = new DoublyLinkedList<int>();
            Assert.Throws<KeyNotFoundException>(() => list.AddBefore(2, 9));
        }
        [Test]
        public void AddAfter_WhenListIsNotEmpty_AddsAfterSpecificNode()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddBefore(1, 555);
            Assert.That(list.First(), Is.EqualTo(555));
        }
    }
}
