namespace Text.Similarity.Cosine;

/// <summary>
/// Measures the cosine distance between two strings.
/// <para>
/// It utilizes the <see cref="CosineSimilarity"/> to compute the distance. Strings are converted into vectors through
/// a simple tokenizer that works with a regular expression to split words in a sentence.
/// </para>
/// </summary>
public class CosineDistance : IEditDistance<double>
{
    private readonly CosineSimilarity _cosineSimilarity = new();

    /// <summary>
    /// Compares two strings.
    /// </summary>
    /// <param name="left">The first string.</param>
    /// <param name="right">The second string.</param>
    /// <returns>The similarity score between the two strings.</returns>
    public double Calculate(string left, string right)
    {
        var similarity = _cosineSimilarity.Calculate(left, right);
        return 1.0 - similarity;
    }
}