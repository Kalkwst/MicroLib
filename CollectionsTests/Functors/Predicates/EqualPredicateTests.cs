using System.Collections;
using Collections.Functors.Predicates;

namespace CollectionsTests.Functors.Predicates;

[TestFixture]
public class EqualPredicateTests
{
    [Test]
    public void EqualPredicate_WithNullComparer_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var equalPredicate = new EqualPredicate<string>(null, null);
        });
    }

    [Test]
    public void EqualPredicate_WithNullInternalStateAndNullInput_ReturnsTrue()
    {
        var predicate = new EqualPredicate<string>(null, StringComparer.Ordinal);
        
        Assert.That(predicate.Evaluate(null), Is.True);
    }

    [Test]
    public void EqualPredicate_WithValidInternalStateAndNullInput_ReturnsFalse()
    {
        var predicate = new EqualPredicate<string>("x", StringComparer.Ordinal);
        
        Assert.That(predicate.Evaluate(null), Is.False);
    }

    [Test]
    public void EqualPredicate_WithValidInternalStateAndValidInput_ReturnsTrue()
    {
        var predicate = new EqualPredicate<string>("x", StringComparer.InvariantCulture);
        
        Assert.That(predicate.Evaluate("x"), Is.True);
    }

    [Test]
    public void EqualPredicate_WithValidInternalStateAndValidInput_ReturnsFalse()
    {
        var predicate = new EqualPredicate<string>("x", StringComparer.InvariantCulture);
        
        Assert.That(predicate.Evaluate("X"), Is.False);
    }
}