using System.Collections.Immutable;

namespace Collections.Functors.Predicates;

/// <summary>
/// Predicate implementation that returns the opposite of the decorated predicate.
/// </summary>
/// <typeparam name="T">The type parameter of the predicate.</typeparam>
public class NotPredicate<T> : IPredicateDecorator<T>
{
    /// <summary>
    /// The predicate to decorate.
    /// </summary>
    private readonly IPredicate<T> _predicate;

    public NotPredicate(IPredicate<T> predicate)
    {
        _predicate = predicate;
    }

    /// <summary>
    /// Evaluates the predicate returning the opposite of the stored predicate.
    /// </summary>
    /// <param name="element">The element to evaluate.</param>
    /// <returns>true if the internal predicate evaluates to false, false otherwise.</returns>
    public bool Evaluate(T element)
    {
        return !_predicate.Evaluate(element);
    }

    /// <summary>
    /// Returns the predicate being evaluated.
    /// </summary>
    /// <returns>The predicate that is being evaluated.</returns>
    public ImmutableArray<IPredicate<T>> GetPredicates()
    {
        return new ImmutableArray<IPredicate<T>>() { _predicate };
    }
}