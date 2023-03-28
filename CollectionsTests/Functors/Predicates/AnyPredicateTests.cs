using Collections.Functors.Predicates;

namespace CollectionsTests.Functors.Predicates;

public class AnyPredicateTests
{
    [Test]
    public void AnyPredicate_WhenAnyPredicateInTheListIsNull_ThrowsNullArgumentException()
    {
        var predicates = new IPredicate<string>[]
        {
            new NullPredicate<string>(),
            new NotNullPredicate<string>(),
            null
        };

        Assert.Throws<ArgumentNullException>(() => new AnyPredicate<string>(predicates));
    }

    [Test]
    public void AnyPredicate_WhenAnyPredicateEvaluateTrue_ReturnsTrue()
    {
        var predicates = new IPredicate<object>[]
        {
            new NotNullPredicate<object>(),
            new UniquePredicate<object>(),
            new TypeOfPredicate<object>(typeof(string))
        };

        var values = new object[] { "a", "b", "c", "d", "e", "f" , "f", 1};
        var predicate = new AnyPredicate<object>(predicates);

        foreach (var value in values)
            Assert.That(predicate.Evaluate(value), Is.True);
    }

    [Test]
    public void AnyPredicate_WhenAllPredicateEvaluatesFalse_ReturnsFalse()
    {
        var predicates = new IPredicate<object>[]
        {
            new UniquePredicate<object>(),
            new TypeOfPredicate<object>(typeof(string))
        };

        var values = new object[] { 1, 1 };
        var predicate = new AnyPredicate<object>(predicates);

        predicate.Evaluate(1);
        Assert.That(predicate.Evaluate(1), Is.False);
    }

    [Test]
    public void AnyPredicate_ReturnsInternalPredicatesCorrectly()
    {
        var first = new NotNullPredicate<string>();
        var second = new NullPredicate<string>();

        var predicate = new AnyPredicate<string>(first, second);
        var expectedArray = new IPredicate<string>[] { first, second };

        Assert.That(predicate.GetPredicates(), Is.EquivalentTo(expectedArray));
    }
}