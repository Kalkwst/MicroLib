namespace Text.Similarity.Jaccard;

/// <summary>
/// Measures the Jaccard similarity (aka Jaccard index of two strings. Jaccard similarity is the size of the intersection
/// divided by the size of the union of the two sets.
/// </summary>
public class JaccardSimilarity : ISimilarityScore<double>
{
    /// <summary>
    /// Calculates the Jaccard Similarity of two strings passed as input.
    /// </summary>
    /// <param name="left">The first string.</param>
    /// <param name="right">The second string.</param>
    /// <returns>The Jaccard index.</returns>
    /// <exception cref="ArgumentException">If either string is null.</exception>
    public double Calculate(string left, string right)
    {
        ArgumentNullException.ThrowIfNull(left, nameof(left));
        ArgumentNullException.ThrowIfNull(right, nameof(right));

        return CalculateJaccardSimilarity(left, right);
    }

    private static double CalculateJaccardSimilarity(string left, string right)
    {
        var leftLength = left.Length;
        var rightLength = right.Length;

        if (leftLength == 0 && rightLength == 0)
            return 1d;
        if (leftLength == 0 || rightLength == 0)
            return 0d;

        var leftSet = new HashSet<char>();
        for (var i = 0; i < leftLength; i++)
            leftSet.Add(left[i]);

        var rightSet = new HashSet<char>();
        for (var i = 0; i < rightLength; i++)
            rightSet.Add(right[i]);

        var unionSet = new HashSet<char>(leftSet);
        unionSet.UnionWith(rightSet);

        var intersectionSize = leftSet.Count + rightSet.Count - unionSet.Count;
        return 1.0d * intersectionSize / unionSet.Count;
    }
}