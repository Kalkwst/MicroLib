namespace Collections.Functors.Predicates;

/// <summary>
/// Predicate implementation that returns true if the input is the same object as the one stored in this predicate.
/// </summary>
/// <typeparam name="T">The type parameter of the <see cref="IPredicate{T}"/>.</typeparam>
public class EqualPredicate<T> : IPredicate<T>
{

    /// <summary>
    /// The value to compare to.
    /// </summary>
    private readonly T _internalValue;

    /// <summary>
    /// The comparer to use for comparison.
    /// </summary>
    private readonly IComparer<T> _comparer;

    /// <summary>
    /// Creates a new EqualPredicate with a specific <paramref name="internalValue"/> and a specific <paramref name="comparer"/>.
    /// </summary>
    /// <param name="internalValue">The internal value of the predicate, can be null.</param>
    /// <param name="comparer">The comparer to use, cannot be null.</param>
    public EqualPredicate(T internalValue, IComparer<T> comparer)
    {
        _internalValue = internalValue;
        
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));
        _comparer = comparer;
    }

    /// <summary>
    /// Determines whether the input equals the internal value.
    /// </summary>
    /// <param name="element">The value to check.</param>
    /// <returns>true if the input equals the internal value, false otherwise.</returns>
    public bool Evaluate(T element)
    {
        return _comparer.Compare(_internalValue, element) == 0;
    }
}