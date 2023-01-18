using System.Collections.Immutable;

namespace Collections.Functors.Predicates;

public abstract class AbstractQuantifierPredicate<T> : IPredicateDecorator<T>
{
    /// <summary>
    /// The array of predicates to call.
    /// </summary>
    protected IPredicate<T>[] _predicates;

    /// <summary>
    /// Constructor that performs no validation.
    /// </summary>
    /// <param name="predicates">The predicates to check.</param>
    public AbstractQuantifierPredicate(params IPredicate<T>[] predicates)
    {
        _predicates = predicates;
    }
    
    public abstract bool Evaluate(T element);

    /// <summary>
    /// Gets the predicates.
    /// </summary>
    /// <returns>A copy of the predicates.</returns>
    public ImmutableArray<IPredicate<T>> GetPredicates()
    {
        return FunctorUtils.Copy(_predicates);
    }
}