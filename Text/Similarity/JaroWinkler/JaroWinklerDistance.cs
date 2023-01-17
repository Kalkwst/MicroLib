namespace Text.Similarity.JaroWinkler;

/// <summary>
/// Measures the Jaro-Winkler distance of two strings. It is the complementary of Jaro-Winkler distance.
/// </summary>
public class JaroWinklerDistance : IEditDistance<double>
{
    private readonly JaroWinklerSimilarity similarity = new();

    /// <summary>
    /// Computes the Jaro-Winkler distance between two strings.
    /// </summary>
    /// <param name="left">The first string, must not be null.</param>
    /// <param name="right">The second string, must not be null.</param>
    /// <returns>The Jaro Winkler similarity.</returns>
    /// <exception cref="ArgumentNullException">If any of the two strings is null.</exception>
    public double Calculate(string left, string right)
    {
        ArgumentNullException.ThrowIfNull(left, nameof(left));
        ArgumentNullException.ThrowIfNull(right, nameof(right));

        return 1 - similarity.Calculate(left, right);
    }
}