namespace Text.Similarity.Hamming;

/// <summary>
/// The hamming distance between two strings of equal length is the number of positions at which the corresponding
/// symbols are different.
/// </summary>
public class HammingDistance : IEditDistance<int>
{
    /// <summary>
    /// Find the Hamming Distance between two strings with the same length.
    /// <br/><br/>
    /// The distance starts with zero, and for each occurrence of a different character in either string, it increments
    /// the distance by 1, and finally return its value.
    /// <br/><br/>
    /// Since the Hamming Distance can only be calculated between strings of equal length, input of different lengths
    /// will throw an <see cref="ArgumentException"/>.
    /// </summary>
    /// <param name="left">The first string, must not be null.</param>
    /// <param name="right">The second string, must not be null.</param>
    /// <returns>The number of differences between the two strings</returns>
    /// <exception cref="ArgumentNullException">If any of the two strings is null.</exception>
    /// <exception cref="ArgumentException">If the strings do not have the same length.</exception>
    public int Calculate(string? left, string? right)
    {
        if (left == null || right == null)
            throw new ArgumentNullException(left == null ? nameof(left) : nameof(right), "Strings must not be null");

        if (left.Length != right.Length)
            throw new ArgumentException("Strings must have the same length");

        left = left.ToLower();
        right = right.ToLower();

        return left.Where((t, i) => t != right[i]).Count();
    }
}