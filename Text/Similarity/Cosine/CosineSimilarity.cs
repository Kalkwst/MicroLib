using Text.Similarity.Tokenizers;

namespace Text.Similarity.Cosine;

/// <summary>
/// Measures the Cosine similarity of two vectors of an inner product space and compares the angle between them.
/// </summary>
public class CosineSimilarity : ISimilarityScore<double>
{
    private readonly ITokenizer<string> _tokenizer = new WordTokenizer();

    /// <summary>
    /// Calculates the cosine similarity for two given strings.
    /// </summary>
    /// <param name="left">The first string.</param>
    /// <param name="right">The second string.</param>
    /// <returns>The cosine similarity between the two strings.</returns>
    public double Calculate(string? left, string? right)
    {
        var leftTokens = _tokenizer.Tokenize(left);
        var rightTokens = _tokenizer.Tokenize(right);

        var leftVector = Counter.Of(leftTokens);
        var rightVector = Counter.Of(rightTokens);

        return GetCosineSimilarity(leftVector, rightVector);
    }

    private static double GetCosineSimilarity(Dictionary<string, int> leftVector, Dictionary<string, int> rightVector)
    {
        if (leftVector == null || rightVector == null)
        {
            throw new ArgumentNullException(leftVector == null ? nameof(leftVector) : nameof(rightVector),
                "Vectors cannot be null");
        }

        var intersection = GetIntersection(leftVector, rightVector);
        var dotProduct = GetDotProduct(leftVector, rightVector, intersection);

        var d1 = leftVector.Values.Sum(value => Math.Pow(value, 2));
        var d2 = rightVector.Values.Sum(value => Math.Pow(value, 2));

        if (d1 <= 0.0 || d2 <= 0.0)
            return 0.0;
        else
            return dotProduct / (Math.Sqrt(d1) * Math.Sqrt(d2));
    }

    private static double GetDotProduct(
        IReadOnlyDictionary<string, int> leftVector,
        IReadOnlyDictionary<string, int> rightVector,
        IEnumerable<string> intersection)
    {
        return intersection.Aggregate(0L, (current, key) => current + (leftVector[key] * rightVector[key]));
    }

    private static IEnumerable<string> GetIntersection(
        Dictionary<string, int> leftVector,
        Dictionary<string, int> rightVector)
    {
        var intersection = new HashSet<string>();
        intersection.UnionWith(leftVector.Keys);
        intersection.IntersectWith(rightVector.Keys);

        return intersection;
    }
}