namespace Text.Similarity.JaroWinkler;

/// <summary>
/// A similarity algorithm indicating the percentage of matched characters between two strings.
/// </summary>
public class JaroWinklerSimilarity : ISimilarityScore<double>
{
    /// <summary>
    /// Calculate the Jaro-Winkler string matches, half transpositions, prefix array.
    /// </summary>
    /// <param name="first">The first string</param>
    /// <param name="second">The second string</param>
    /// <returns>Matches, transpositions, and prefix</returns>
    protected static int[] Matches(string first, string second)
    {
        string max = first.Length > second.Length ? first : second;
        string min = first.Length > second.Length ? second : first;

        var range = Math.Max(max.Length / 2 - 1, 0);

        var matchIndices = new int[min.Length];
        for (var i = 0; i < matchIndices.Length; i++)
        {
            matchIndices[i] = -1;
        }

        var matchFlags = new bool[max.Length];
        var matches = 0;

        for (var minIndex = 0; minIndex < min.Length; minIndex++)
        {
            var c1 = min[minIndex];
            var xn = Math.Min(minIndex + range + 1, max.Length);

            for (var xi = Math.Max(minIndex - range, 0); xi < xn; xi++)
            {
                if (!matchFlags[xi] && c1 == max[xi])
                {
                    matchIndices[minIndex] = xi;
                    matchFlags[xi] = true;
                    matches++;
                    break;
                }
            }
        }

        var ms1 = new char[matches];
        var ms2 = new char[matches];
        var si = 0;

        for (var i = 0; i < min.Length; i++)
        {
            if (matchIndices[i] != -1)
            {
                ms1[si] = min[i];
                si++;
            }
        }

        si = 0;
        for (var i = 0; i < max.Length; i++)
        {
            if (matchFlags[i])
            {
                ms2[si] = max[i];
                si++;
            }
        }

        var halfTranspositions = 0;
        for (var mi = 0; mi < ms1.Length; mi++)
        {
            if (ms1[mi] != ms2[mi])
            {
                halfTranspositions++;
            }
        }

        var prefix = 0;
        for (var mi = 0; mi < Math.Min(4, min.Length); mi++)
        {
            if (first[mi] != second[mi])
                break;

            prefix++;
        }

        return new[] { matches, halfTranspositions, prefix };
    }

    /// <summary>
    /// Computes the Jaro Winkler Similarity between two character sequences.
    /// </summary>
    /// <param name="left">The first string, must not be null.</param>
    /// <param name="right">The second string, must not be null.</param>
    /// <returns>The similarity</returns>
    /// <exception cref="ArgumentException">If any of the strings is null.</exception>
    public double Calculate(string left, string right)
    {
        const double defaultScalingFactor = 0.1;

        if (left == null || right == null)
            throw new ArgumentNullException(left == null ? nameof(left) : nameof(right), "Strings must not be null");

        if (left.Equals(right))
            return 1d;

        var mpt = Matches(left, right);
        double m = mpt[0];

        if (m == 0)
            return 0d;

        var j = (m / left.Length + m / right.Length + (m - (double)mpt[1] / 2) / m) / 3;
        return j < 0.7d ? j : j + defaultScalingFactor * mpt[2] * (1d - j);
    }
}