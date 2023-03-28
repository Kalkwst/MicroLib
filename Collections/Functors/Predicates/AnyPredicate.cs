namespace Collections.Functors.Predicates;

/// <summary>
/// Predicate implementation that returns true if any of the predicates return true.
/// </summary>
/// <typeparam name="T">The type parameter of the predicate</typeparam>
public class AnyPredicate<T> : AbstractQuantifierPredicate<T>
{
    public AnyPredicate(params IPredicate<T>[] predicates) : base(predicates)
    {
    }

    /// <summary>
    /// Determines whether any of the <see cref="IPredicate{T}"/>s in the list returns true for the provided input.
    /// </summary>
    /// <param name="element">The element to evaluate.</param>
    /// <returns>true if any of the predicates evaluates to true, false otherwise.</returns>
    public override bool Evaluate(T element)
    {
        return _predicates.Any(predicate => predicate.Evaluate(element));
    }
}