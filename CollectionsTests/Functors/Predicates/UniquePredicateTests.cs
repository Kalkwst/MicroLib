using Collections.Functors.Predicates;

namespace CollectionsTests.Functors.Predicates;

[TestFixture]
public class UniquePredicateTests
{
    [Test]
    public void UniquePredicate_WithAllUniqueItems_ReturnsTrue()
    {
        var elements = new[] { "a", "b", "c", "d", };
        var predicate = new UniquePredicate<string>();

        foreach (var element in elements)
        {
            Assert.That(predicate.Evaluate(element), Is.True);
        }
    }

    [Test]
    public void UniquePredicate_WithNotAllElementsUnique_ReturnsFalse()
    {
        var elements = new[] { "a", "b", "c", "d", };
        var predicate = new UniquePredicate<string>();

        foreach (var element in elements)
        {
            predicate.Evaluate(element);
        }
        
        Assert.That(predicate.Evaluate("a"), Is.False);
    }
}