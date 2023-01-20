using System.Collections.Immutable;
using Collections.Functors.Predicates;

namespace CollectionsTests.Functors.Predicates;

[TestFixture]
public class AndPredicateTests
{
    [Test]
    public void AndPredicate_WithNullFirstArgument_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var predicate = new AndPredicate<string>(null, new EqualPredicate<string>("a", Comparer<string>.Default));
        });
    }
    
    [Test]
    public void AndPredicate_WithNullSecondArgument_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var predicate = new AndPredicate<string>(new EqualPredicate<string>("a", Comparer<string>.Default), null);
        });
    }

    [Test]
    public void AndPredicate_WithTwoPassingPredicates_ReturnsTrue()
    {
        var first = new NotNullPredicate<string>();
        var second = new NotNullPredicate<string>();

        var predicate = new AndPredicate<string>(first, second);
        
        Assert.That(predicate.Evaluate("x"), Is.True);
    }

    [Test]
    public void AndPredicate_WithOnePassingPredicate_ReturnsFalse()
    {
        var first = new NotNullPredicate<string>();
        var second = new NullPredicate<string>();

        var predicate = new AndPredicate<string>(first, second);
        
        Assert.That(predicate.Evaluate("x"), Is.False);
    }

    [Test]
    public void AndPredicate_ReturnsInternalPredicatesCorrectly()
    {
        var first = new NotNullPredicate<string>();
        var second = new NullPredicate<string>();

        var predicate = new AndPredicate<string>(first, second);
        var expectedArray = new IPredicate<string>[] { first, second };

        Assert.That(predicate.GetPredicates(), Is.EquivalentTo(expectedArray));
    }
}