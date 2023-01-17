using System.Globalization;

namespace Text.Similarity.Fuzzy;

public class FuzzyScore
{
    private readonly CultureInfo info;

    public FuzzyScore(CultureInfo? info)
    {
        ArgumentNullException.ThrowIfNull(info, nameof(info));
        this.info = info;
    }

    public int CalculateFuzzyScore(string? term, string? query)
    {
        ArgumentNullException.ThrowIfNull(term, nameof(term));
        ArgumentNullException.ThrowIfNull(query, nameof(query));

        var lowerCaseTerm = term.ToLower(info);
        var lowerCaseQuery = query.ToLower(info);

        // the resulting score
        var score = 0;

        // the position in the term which will be scanned next for potential
        // query character matches
        var termIndex = 0;

        // index of the previously matched character in the term
        var previousMatchingCharacterIndex = int.MinValue;

        foreach (var queryChar in lowerCaseQuery)
        {
            for (; termIndex < lowerCaseTerm.Length; termIndex++)
            {
                var termChar = lowerCaseTerm[termIndex];

                if (queryChar == termChar)
                {
                    // simple character matches result in one point
                    score++;

                    // subsequent character matches further improve
                    // the score.
                    if (previousMatchingCharacterIndex + 1 == termIndex)
                        score += 2;

                    previousMatchingCharacterIndex = termIndex;

                    // we can leave the nested loop. Every character in the
                    // query can match at most one character in the term.
                    break;
                }
            }
        }

        return score;
    }
}