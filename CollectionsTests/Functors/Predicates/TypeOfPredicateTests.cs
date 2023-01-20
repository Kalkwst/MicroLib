using Collections.Functors.Predicates;

namespace CollectionsTests.Functors.Predicates;

[TestFixture]
public class TypeOfPredicateTests
{

    [Test]
    public void TypeOfPredicate_ForTheSameType_ReturnsTrue()
    {
        var type = typeof(int);
        var predicate = new TypeOfPredicate<object>(type);
        
        Assert.That(predicate.Evaluate(32), Is.True);
    }

    [Test]
    public void TypeOfPredicate_ForDifferentType_ReturnsFalse()
    {
        var type = typeof(int);
        var predicate = new TypeOfPredicate<object>(type);
        
        Assert.That(predicate.Evaluate("32"), Is.False);
    }
}