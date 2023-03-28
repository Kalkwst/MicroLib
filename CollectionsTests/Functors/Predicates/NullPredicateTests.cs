using Collections.Functors.Predicates;

namespace CollectionsTests.Functors.Predicates;

[TestFixture]
public class NullPredicateTests
{
    [Test]
    public void NullPredicate_ForNullValues_ReturnsTrue()
    {
        var predicate = new NullPredicate<string>();
        
        Assert.That(predicate.Evaluate(null), Is.True);
    }

    [Test]
    public void NullPredicate_ForNotNullValues_ReturnsFalse()
    {
        var predicate = new NullPredicate<string>();
        
        Assert.That(predicate.Evaluate("null"), Is.False);
    }
}