using System.Text;
using System;

namespace Text;

public class WordUtils
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

}