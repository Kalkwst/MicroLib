namespace Collections.Functors.Predicates;

/// <summary>
/// Predicate implementation that returns true the first time an object is passed into the predicate.
/// </summary>
/// <typeparam name="T">The type parameter of this predicate.</typeparam>
public class UniquePredicate<T> : IPredicate<T>
{
    /// <summary>
    /// The set of previously seen objects.
    /// </summary>
    private readonly HashSet<T> _internalSet = new HashSet<T>();
    
    /// <summary>
    /// Determines whether the predicate hasn't receive the given element before.
    /// </summary>
    /// <param name="element">The element to add in the internal set.</param>
    /// <returns>true if the element is not present in the set, false otherwise.</returns>
    public bool Evaluate(T element)
    {
        return _internalSet.Add(element);
    }
}