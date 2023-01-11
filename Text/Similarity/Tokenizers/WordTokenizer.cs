using System.Text.RegularExpressions;

namespace Text.Similarity.Tokenizers;

/// <summary>
/// A simple word tokenizer that utilizes regex to find words. It applies a regex <em>(\w)+</em> over the input text to
/// extract words from a given character sequence.
/// </summary>
public sealed class WordTokenizer : ITokenizer<string>
{
    private const string _pattern = @"(\w)+";

    /// <summary>
    /// Splits the provided string to words.
    /// </summary>
    /// <param name="text">The string to tokenize.</param>
    /// <returns>
    /// A string array containing all of the words generated from the provided <paramref name="text"/>.
    /// </returns>
    /// <exception cref="ArgumentException">If the <paramref name="text"/> is null, empty or whitespace only.</exception>
    public string[] Tokenize(string? text)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Text must not be null, empty or whitespace only");

        var tokens = new List<string>();

        foreach (Match m in Regex.Matches(text, _pattern).Cast<Match>())
        {
            tokens.Add(m.Value);
        }

        return tokens.ToArray();
    }
}