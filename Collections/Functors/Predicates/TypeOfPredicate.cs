namespace Collections.Functors.Predicates;

/// <summary>
/// Predicate implementation that returns true if the input is of the same type as the type stored in the predicate.
/// </summary>
/// <typeparam name="T">The type parameter of the predicate</typeparam>
public class TypeOfPredicate<T> : IPredicate<T>
{
    /// <summary>
    /// The type to compare to.
    /// </summary>
    private readonly Type _internalType;

    public TypeOfPredicate(Type type)
    {
        _internalType = type;
    }

    /// <summary>
    /// Determines whether the provided input is of the same type as the input stored in this <see cref="IPredicate{T}"/>.
    /// </summary>
    /// <param name="element">The element to get the type of.</param>
    /// <returns>true if the element has the same type as the stored value, false otherwise.</returns>
    public bool Evaluate(T element)
    {
        return element.GetType() == _internalType;
    }
}