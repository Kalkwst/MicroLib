using Collections.Functors.Predicates;

namespace CollectionsTests.Functors.Predicates;

[TestFixture]
public class NotNullPredicateTests
{
    [Test]
    public void NotNullPredicate_ForNullValues_ReturnsFalse()
    {
        var predicate = new NotNullPredicate<string>();
        
        Assert.That(predicate.Evaluate(null), Is.False);
    }

    [Test]
    public void NotNullPredicate_ForNotNullValues_ReturnsTrue()
    {
        var predicate = new NotNullPredicate<string>();
        
        Assert.That(predicate.Evaluate("null"), Is.True);
    }
}