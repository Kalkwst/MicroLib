using System.Text;

namespace Text;

public static class WordUtils
{
    /// <summary>
    /// Abbreviates the words nicely.
    /// <para>
    /// This method searches for the first space after the lower limit and abbreviates the string there. It will also
    /// append any string passed as a parameter to the end of the string. The upper limit can be specified to forcibly
    /// abbreviate a string.
    /// </para>
    /// </summary>
    /// <param name="str">
    /// The string to be abbreviated. If null is passed, null will be returned. If the empty string is passed, the empty
    /// string will be returned.
    /// </param>
    /// <param name="lower">
    /// The lower limit; negative value is treated as zero.
    /// </param>
    /// <param name="upper">
    /// The upper limit; set to -1 if no limit is desired. The upper limit cannot be lower than the upper limit.
    /// </param>
    /// <param name="appendToEnd">
    /// The string to be appended to the end of the abbreviated string. This is appended ONLY if the string was indeed
    /// abbreviated. The append does not count towards the lower or upper limits.
    /// </param>
    /// <returns>The abbreviated string.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// If the upper limit is less than -1, or if the upper value is less than the lower value.
    /// </exception>
    /// <example>
    /// WordUtils.Abbreviate("Now is the time for all good men", 0, 40, null));     = "Now"<br/>
    /// WordUtils.Abbreviate("Now is the time for all good men", 0, 40, " ..."));   = "Now ..."
    /// </example>
    public static string Abbreviate(string str, int lower, int upper, string appendToEnd)
    {
        if (upper < -1)
            throw new ArgumentOutOfRangeException(nameof(upper), "Upper value cannot be less than -1");
        if (upper < lower && upper != -1)
            throw new ArgumentOutOfRangeException(nameof(upper), "Upper value is less than lower value");

        if (string.IsNullOrEmpty(str))
            return str;
    
        // If the lower value is greater than the lenght of the string, set to the length of the string
        if (lower > str.Length)
            lower = str.Length;
    
        // If the upper value is -1 (meaning there is no limit) or is greater than the length of the string, set to the
        // length of the string.
        if (upper == -1 || upper > str.Length)
            upper = str.Length;

        var index = str.IndexOf(" ", lower, StringComparison.Ordinal);

        if (index == -1)
        {
            // only if abbreviation has occurred do we append the appendToEnd value
            return upper != str.Length ? str.Substring(0, upper) + appendToEnd : str;
        }

        return str.Substring(0, Math.Min(index, upper)) + appendToEnd;
    }

    /// <summary>
    /// Capitalizes all the whitespace separated words in a string. Only the first character of each word is changed.
    /// </summary>
    /// <param name="str">The string to capitalize, may be null.</param>
    /// <returns>The capitalized string, or null for null string input.</returns>
    /// <example>
    /// WordUtils.Capitalize(null) = null <br/>
    /// WordUtils.Capitalize("") = "" <br/>
    /// WordUtils.Capitalize("i am FINE") = "I Am FINE"
    /// </example>
    /// <seealso cref="CapitalizeFully"/>
    /// <seealso cref="Uncapitalize"/>
    public static string Capitalize(string str)
    {
        return Capitalize(str, null);
    }

    /// <summary>
    /// Capitalizes all the delimiter separated words in a string. Only the first character of each word is changed.
    /// </summary>
    /// <param name="str">The string to capitalize, may be null.</param>
    /// <param name="delimiters">A set of characters to determine capitalization. Null is treated as whitespace.</param>
    /// <returns>The capitalized string, or null for null string input.</returns>
    /// <remarks>
    /// The delimiters represent a set of characters understood to separate words. The first string character and the
    /// first non-delimiter character after a delimiter will be capitalized.
    /// </remarks>
    /// <example>
    /// WordUtils.Capitalize(null, '*') = null <br/>
    /// WordUtils.Capitalize("", '*') = null <br/>
    /// WordUtils.Capitalize("i am fine", null) = "I Am Fine" <br/>
    /// WordUtils.Capitalize("I am fine", new char[]{}) = "I am fine"
    /// </example>
    /// <seealso cref="CapitalizeFully"/>
    /// <seealso cref="Uncapitalize"/>
    public static string Capitalize(string str, params char[]? delimiters)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        var delimiterSet = GenerateDelimiterSet(delimiters);
        var sb = new StringBuilder(str.Length);

        var capitalizeNext = true;
        foreach (var c in str)
        {
            if (delimiterSet.Contains(c))
            {
                capitalizeNext = true;
                sb.Append(c);
            }
            else if (capitalizeNext)
            {
                sb.Append(char.ToUpper(c));
                capitalizeNext = false;
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    private static HashSet<int> GenerateDelimiterSet(IReadOnlyList<char>? delimiters)
    {
        var delimiterHashSet = new HashSet<int>();
        if (delimiters == null || delimiters.Count == 0)
        {
            if (delimiters == null)
            {
                delimiterHashSet.Add(' ');
            }
            return delimiterHashSet;
        }

        foreach (var t in delimiters)
        {
            delimiterHashSet.Add(t);
        }
        return delimiterHashSet;
    }
}