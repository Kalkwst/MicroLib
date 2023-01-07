using System.Text;
using System;

namespace Text;

public class WordUtils
{
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

}