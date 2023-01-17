using System.Collections;

namespace Collections.Extensions;

public static class CollectionExtensions
{
    /// <summary>
    /// Adds all the elements in the provided collection <paramref name="elements"/> to this collection.
    /// </summary>
    /// <param name="collection">The collection to add the elements to.</param>
    /// <param name="elements">The collection containing the items to be added.</param>
    /// <typeparam name="T">The type parameter of this collection.</typeparam>
    public static void AddAll<T>(this ICollection<T> collection, IEnumerable<T> elements)
    {
        foreach (var item in elements)
        {
            collection.Add(item);
        }
    }

    /// <summary>
    /// Determines whether the <see cref="ICollection{T}"/> contains the specified values.
    /// </summary>
    /// <param name="collection">The collection to search in.</param>
    /// <param name="elements">The elements to locate in the <see cref="ICollection{T}"/></param>
    /// <typeparam name="T">The type parameter of the elements.</typeparam>
    /// <returns>true if all <see cref="elements"/> are found in the collection, false otherwise.</returns>
    public static bool ContainsAll<T>(this ICollection<T> collection, IEnumerable<T> elements)
    {
        return elements.All(collection.Contains);
    }

    /// <summary>
    /// Determines whether the <see cref="ICollection{T}"/> is empty.
    /// </summary>
    /// <param name="collection">The collection to check.</param>
    /// <typeparam name="T">The type parameter of this collection.</typeparam>
    /// <returns>true if the <see cref="ICollection{T}"/> has no elements, false otherwise.</returns>
    public static bool IsEmpty<T>(this ICollection<T> collection)
    {
        return collection.Count == 0;
    }

    /// <summary>
    /// Removes all occurrences of the specified objects from the <see cref="ICollection{T}"/>.
    /// </summary>
    /// <param name="collection">The collection to remove elements from.</param>
    /// <param name="elements">The objects to remove from the <see cref="ICollection{T}"/>.</param>
    /// <typeparam name="T">The type parameter of the <see cref="ICollection{T}"/>.</typeparam>
    /// <returns>true if the <see cref="ICollection{T}"/> changed as a result of the call, false otherwise.</returns>
    public static bool RemoveAll<T>(this ICollection<T> collection, IEnumerable<T> elements)
    {
        var count = collection.Count;
        foreach (var element in elements)
        {
            while (collection.Contains(element))
                collection.Remove(element);
        }

        return collection.Count != count;
    }
}