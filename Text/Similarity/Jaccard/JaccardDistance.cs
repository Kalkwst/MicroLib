namespace Text.Similarity.Jaccard;

/// <summary>
/// Measures the Jaccard distance of two strings. Jaccard distance is the dissimilarity between two sets. It is the
/// complementary of Jaccard similarity.
/// </summary>
public class JaccardDistance : IEditDistance<double>
{
    private readonly JaccardSimilarity similarity = new();

    /// <summary>
    /// Calculates the Jaccard distance of two strings passed as input.
    /// </summary>
    /// <param name="left">The first string.</param>
    /// <param name="right">The second string.</param>
    /// <returns>The Jaccard distance.</returns>
    /// <exception cref="ArgumentNullException">If any of the strings is null.</exception>
    public double Calculate(string left, string right)
    {
        if (left == null || right == null)
        {
            throw new ArgumentNullException(left == null ? nameof(left) : nameof(right),
                "Input cannot be null");
        }

        return 1.0 - similarity.Calculate(left, right);
    }
}