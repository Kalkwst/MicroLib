namespace Collections.Functors.Predicates;

/// <summary>
/// Defines a functor interface implemented by classes that perform a predicate test on an object.
/// </summary>
/// <typeparam name="T">The type parameter of the predicate queries.</typeparam>
public interface IPredicate<T>
{
    /// <summary>
    /// Use the specified parameter to perform a test that returns true or false.
    /// </summary>
    /// <param name="element">The element to evaluate, should not be changed.</param>
    /// <returns>true if the evaluation succeeds, false otherwise.</returns>
    public bool Evaluate(T element);
}