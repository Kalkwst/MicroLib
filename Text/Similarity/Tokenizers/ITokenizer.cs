namespace Text.Similarity.Tokenizers;

/// <summary>
/// A tokenizer. Can produce arrays of tokens from a given type.
/// </summary>
/// <typeparam name="T">The type of tokens generated.</typeparam>
public interface ITokenizer<T>
{
    /// <summary>
    /// Returns an array of tokens.
    /// </summary>
    /// <param name="text">The input text.</param>
    /// <returns>An array of tokens.</returns>
    public T[] Tokenize(string text);
}