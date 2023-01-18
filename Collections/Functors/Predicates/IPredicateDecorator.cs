using System.Collections.Immutable;

namespace Collections.Functors.Predicates;

/// <summary>
/// Defines an <see cref="IPredicate{T}"/> that decorates one or more <see cref="IPredicate{T}"/>s.
/// </summary>
/// <typeparam name="T">The type parameter of the predicates.</typeparam>
public interface IPredicateDecorator<T> : IPredicate<T>
{
    /// <summary>
    /// Gets the predicates being decorated as an array.
    /// </summary>
    /// <returns>The predicates being decorated.</returns>
    public ImmutableArray<IPredicate<T>> GetPredicates();
}