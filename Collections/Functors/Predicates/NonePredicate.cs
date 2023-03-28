namespace Collections.Functors.Predicates;

/// <summary>
/// Predicate implementation that returns true if none of the predicates returns true.
/// </summary>
/// <typeparam name="T">The type parameter of the predicate.</typeparam>
public class NonePredicate<T> : AbstractQuantifierPredicate<T>
{
    public NonePredicate(params IPredicate<T>[] predicates) : base(predicates)
    {
    }

    /// <summary>
    /// Determines whether all stored <see cref="IPredicate{T}"/>s return false for the given input.
    /// </summary>
    /// <param name="element">The element to check.</param>
    /// <returns>true if all the predicates return false, false otherwise.</returns>
    public override bool Evaluate(T element)
    {
        return _predicates.All(predicate => !predicate.Evaluate(element));
    }
}