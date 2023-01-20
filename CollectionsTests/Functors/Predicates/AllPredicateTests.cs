using Collections.Functors.Predicates;

namespace CollectionsTests.Functors.Predicates;

[TestFixture]
public class AllPredicateTests
{
    [Test]
    public void AllPredicate_WhenAnyPredicateInTheListIsNull_ThrowsNullArgumentException()
    {
        var predicates = new IPredicate<string>[]
        {
            new NullPredicate<string>(),
            new NotNullPredicate<string>(),
            null
        };

        Assert.Throws<ArgumentNullException>(() => new AllPredicate<string>(predicates));
    }

    [Test]
    public void AllPredicate_WhenAllPredicatesEvaluateTrue_ReturnsTrue()
    {
        var predicates = new IPredicate<string>[]
        {
            new NotNullPredicate<string>(),
            new UniquePredicate<string>(),
            new TypeOfPredicate<string>(typeof(string))
        };

        var values = new[] { "a", "b", "c", "d", "e", "f" };
        var predicate = new AllPredicate<string>(predicates);

        foreach (var value in values)
            Assert.That(predicate.Evaluate(value), Is.True);
    }

    [Test]
    public void AllPredicate_WhenAnyPredicateEvaluatesFalse_ReturnsFalse()
    {
        var predicates = new IPredicate<object>[]
        {
            new NotNullPredicate<object>(),
            new UniquePredicate<object>(),
            new TypeOfPredicate<object>(typeof(string))
        };

        const int value = 1;
        var predicate = new AllPredicate<object>(predicates);

            Assert.That(predicate.Evaluate(value), Is.False);
    }

    [Test]
    public void AllPredicate_ReturnsInternalPredicatesCorrectly()
    {
        var first = new NotNullPredicate<string>();
        var second = new NullPredicate<string>();

        var predicate = new AllPredicate<string>(first, second);
        var expectedArray = new IPredicate<string>[] { first, second };

        Assert.That(predicate.GetPredicates(), Is.EquivalentTo(expectedArray));
    }
}