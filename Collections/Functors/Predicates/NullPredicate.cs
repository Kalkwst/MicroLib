namespace Collections.Functors.Predicates;

/// <summary>
/// Predicate implementation that returns true if the input is null.
/// </summary>
/// <typeparam name="T">The type parameter of the predicate.</typeparam>
public class NullPredicate<T> : IPredicate<T>
{
    /// <summary>
    /// Determines whether the provided input is null.
    /// </summary>
    /// <param name="element">The element to determine if its null.</param>
    /// <returns>true if the element is null, false otherwise.</returns>
    public bool Evaluate(T element)
    {
        return element == null;
    }
}