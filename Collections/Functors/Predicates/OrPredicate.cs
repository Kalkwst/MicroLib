using System.Collections.Immutable;

namespace Collections.Functors.Predicates;

public class OrPredicate<T> : IPredicateDecorator<T>
{
    /// <summary>
    /// The first predicate to call.
    /// </summary>
    private readonly IPredicate<T> _firstPredicate;

    /// <summary>
    /// The second predicate to call.
    /// </summary>
    private readonly IPredicate<T> _secondPredicate;

    public OrPredicate(IPredicate<T> firstPredicate, IPredicate<T> secondPredicate)
    {
        ArgumentNullException.ThrowIfNull(firstPredicate, nameof(firstPredicate));
        ArgumentNullException.ThrowIfNull(secondPredicate, nameof(secondPredicate));

        _firstPredicate = firstPredicate;
        _secondPredicate = secondPredicate;
    }

    /// <summary>
    /// Evaluates that any of the predicates return true for the given input.
    /// </summary>
    /// <param name="element">The element to evaluate.</param>
    /// <returns>true if both decorated predicates return true, false otherwise.</returns>
    public bool Evaluate(T element)
    {
        return _firstPredicate.Evaluate(element) || _secondPredicate.Evaluate(element);
    }

    ///<inheritdoc cref="IPredicateDecorator{T}.GetPredicates"/>
    public ImmutableArray<IPredicate<T>> GetPredicates()
    {
        return new ImmutableArray<IPredicate<T>>() { _firstPredicate, _secondPredicate };
    }
}