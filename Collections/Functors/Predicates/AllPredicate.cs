using System.Collections.Immutable;

namespace Collections.Functors.Predicates;

/// <summary>
/// Predicate implementation that returns true if all the predicates return true.
/// </summary>
/// <typeparam name="T"></typeparam>
public class AllPredicate<T> : AbstractQuantifierPredicate<T>
{
    public AllPredicate(params IPredicate<T>[] predicates) : base(predicates)
    {
    }

    /// <summary>
    /// Evaluates the predicate returning true if all predicates return true.
    /// </summary>
    /// <param name="element">The input element.</param>
    /// <returns>true if all decorated predicates return true, false otherwise.</returns>
    public override bool Evaluate(T element)
    {
        return _predicates.All(predicate => predicate.Evaluate(element));
    }
}