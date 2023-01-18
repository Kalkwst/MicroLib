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
    private readonly IEqualityComparer<T> _comparer;

    public EqualPredicate(T internalValue, IEqualityComparer<T> comparer)
    {
        _internalValue = internalValue;
        _comparer = comparer;
    }

    /// <summary>
    /// Determines whether the input equals the internal value.
    /// </summary>
    /// <param name="element">The value to check.</param>
    /// <returns>true if the input equals the internal value, false otherwise.</returns>
    public bool Evaluate(T element)
    {
        return _comparer.Equals(_internalValue, element);
    }
}