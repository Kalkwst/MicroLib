using System.Collections.Immutable;

namespace Collections.Functors.Predicates;

public class FunctorUtils
{
    /// <summary>
    /// Creates an <see cref="ImmutableArray{T}"/> of the predicates to ensure that the internal reference cannot be
    /// changed.
    /// </summary>
    /// <param name="predicates">The predicates to copy.</param>
    /// <typeparam name="T">The type parameter of the <see cref="IPredicate{T}"/>.</typeparam>
    /// <returns>An <see cref="ImmutableArray{T}"/> of predicates.</returns>
    public static IPredicate<T>[] Copy<T>(params IPredicate<T>[] predicates)
    {
        return predicates.ToArray();
    }

    public static void EnsureNotNull<T>(params IPredicate<T>[] predicates)
    {
        ArgumentNullException.ThrowIfNull(predicates, nameof(predicates));
        for (var i = 0; i < predicates.Length; i++)
        {
            ArgumentNullException.ThrowIfNull(predicates[i], $"predicates[{i}]");
        }
    }
}