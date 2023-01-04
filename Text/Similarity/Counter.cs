namespace Text.Similarity;

/// <summary>
/// C# implementation of Python's collections Counter module.
/// </summary>
public sealed class Counter
{
    /// <summary>
    /// Counts how many times each element provided occurred in an array and returns a dictionary with the element as key
    /// and the count as value.
    /// </summary>
    /// <param name="tokens">The array of tokens.</param>
    /// <returns>A dictionary where the elements are key and the count the value.</returns>
    public static Dictionary<string, int> Of(IEnumerable<string> tokens)
    {
        var innerCounter = new Dictionary<string, int>();

        foreach (var token in tokens)
        {
            innerCounter.TryGetValue(token, out var count);
            innerCounter[token] = count != 0 ? count+ 1 : 1;
        }

        return innerCounter;
    }
}