namespace Collections.Functors.Predicates;

/// <summary>
/// Predicate implementation that returns true if the input is not null.
/// </summary>
/// <typeparam name="T"></typeparam>
public class NotNullPredicate<T> : IPredicate<T>
{
    /// <summary>
    /// Determines that the value provided to this <see cref="IPredicate{T}"/> is not null.
    /// </summary>
    /// <param name="element">The element to evaluate.</param>
    /// <returns>true if the element is not null, false otherwise.</returns>
    public bool Evaluate(T element)
    {
        return element != null;
    }
}