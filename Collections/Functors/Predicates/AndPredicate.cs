using System.Collections.Immutable;

namespace Collections.Functors.Predicates;

/// <summary>
/// Predicate implementation that returns true if both the predicates return true.
/// </summary>
/// <typeparam name="T"></typeparam>
public class AndPredicate<T> : IPredicateDecorator<T>
{
    /// <summary>
    /// The first predicate to call.
    /// </summary>
    private readonly IPredicate<T> _firstPredicate;

    /// <summary>
    /// The second predicate to call.
    /// </summary>
    private readonly IPredicate<T> _secondPredicate;

    public AndPredicate(IPredicate<T> firstPredicate, IPredicate<T> secondPredicate)
    {
        ArgumentNullException.ThrowIfNull(firstPredicate, nameof(firstPredicate));
        ArgumentNullException.ThrowIfNull(secondPredicate, nameof(secondPredicate));
        
        _firstPredicate = firstPredicate;
        _secondPredicate = secondPredicate;
    }

    /// <summary>
    /// Evaluates that both predicates return true for the given input.
    /// </summary>
    /// <param name="element">The element to evaluate.</param>
    /// <returns>true if both decorated predicates return true, false otherwise.</returns>
    public bool Evaluate(T element)
    {
        return _firstPredicate.Evaluate(element) && _secondPredicate.Evaluate(element);
    }

    ///<inheritdoc cref="IPredicateDecorator{T}.GetPredicates"/>
    public ImmutableArray<IPredicate<T>> GetPredicates()
    {
        return new ImmutableArray<IPredicate<T>>() { _firstPredicate, _secondPredicate };
    }
}