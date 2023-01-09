using Text;

namespace TextTests;

[TestFixture]
public class WordUtilsTests
{
    [TestCase("012 3456789", 0, 5, null, "012")]
    [TestCase("01234 56789", 5, 10, null, "01234")]
    [TestCase("01 23 45 67 89", 9, -1, null, "01 23 45 67")]
    [TestCase("01 23 45 67 89", 9, 10, null, "01 23 45 6")]
    [TestCase("0123456789", 15, 20, null, "0123456789")]
    public void Abbreviate_ForLowerValue_ReturnsExpectedResults(
        string str, int lower, int upper, string appendToEnd, string expected)
    {
        Assert.That(WordUtils.Abbreviate(str, lower, upper, appendToEnd), Is.EqualTo(expected));
    }

    [TestCase("012 3456789", 0, 5, null, "012")]
    [TestCase("01234 56789", 5, 10, "-", "01234-")]
    [TestCase("01 23 45 67 89", 9, -1, "abc", "01 23 45 67abc")]
    [TestCase("01 23 45 67 89", 9, 10, null, "01 23 45 6")]
    public void Abbreviate_LowerValueSetAndAppendedString_AbbreviatedStringReturned(
        string str, int lower, int upper, string appendToEnd, string expected)
    {
        Assert.That(WordUtils.Abbreviate(str, lower, upper, appendToEnd), Is.EqualTo(expected));
    }

    [TestCase(null, 1, -1, null, null)]
    [TestCase("", 1, -1, "", "")]
    [TestCase("01234567890", 0, 0, "", "")]
    [TestCase(" 01234567890", 0, -1, null, "")]
    public void Abbreviate_ForNullAndEmptyString_ReturnsInputString(
        string str, int lower, int upper, string appendToEnd, string expected)
    {
        Assert.That(WordUtils.Abbreviate(str, lower, upper, appendToEnd), Is.EqualTo(expected));
    }

    [TestCase("0123456789", 0, 5, "", "01234")]
    [TestCase("012 3456789", 2, 5, "", "012")]
    [TestCase("0123456789", 0, -1, "", "0123456789")]
    public void Abbreviate_ForUpperLimit_ReturnsExpectedResults(
        string str, int lower, int upper, string appendToEnd, string expected
    )
    {
        Assert.That(WordUtils.Abbreviate(str, lower, upper, appendToEnd), Is.EqualTo(expected));
    }

    [TestCase("0123456789", 0, 5, "-", "01234-")]
    [TestCase("012 3456789", 2, 5, null, "012")]
    [TestCase("0123456789", 0, -1, "", "0123456789")]
    public void Abbreviate_ForUpperLimitAndAppendedString_ReturnsExpectedResults(
        string str, int lower, int upper, string appendToEnd, string expected
    )
    {
        Assert.That(WordUtils.Abbreviate(str, lower, upper, appendToEnd), Is.EqualTo(expected));
    }

    [TestCase(null, null)]
    [TestCase("", "")]
    [TestCase(" ", " ")]
    [TestCase("I", "I")]
    [TestCase("i", "I")]
    [TestCase("i am here 123", "I Am Here 123")]
    [TestCase("I Am Here 123", "I Am Here 123")]
    [TestCase("I Am HERE 123", "I Am HERE 123")]
    [TestCase("I AM HERE 123", "I AM HERE 123")]
    public void Capitalize_ReturnsExpectedResults(string str, string expected)
    {
        Assert.That(WordUtils.Capitalize(str), Is.EqualTo(expected));
    }

    [TestCase(null, null)]
    [TestCase("", "")]
    [TestCase(" ", " ")]
    [TestCase("I", "I")]
    [TestCase("i", "I")]
    [TestCase("i am here 123", "I Am Here 123")]
    [TestCase("I Am Here 123", "I Am Here 123")]
    [TestCase("I Am HERE 123", "I Am Here 123")]
    [TestCase("I AM HERE 123", "I Am Here 123")]
    public void CapitalizeFully_ReturnsExpectedResults(string str, string expected)
    {
        Assert.That(WordUtils.CapitalizeFully(str), Is.EqualTo(expected));
    }

    [TestCase("I", "I")]
    [TestCase("i", "I")]
    [TestCase("i-am here+123", "I-Am Here+123")]
    [TestCase("I Am+Here-123", "I Am+Here-123")]
    [TestCase("i+am-HERE 123", "I+Am-Here 123")]
    [TestCase("I-AM HERE+123", "I-Am Here+123")]
    public void CapitalizeFully_WithDelimiters_ReturnsExpectedResults(string str, string expected)
    {
        char[] delimiters = { '-', '+', ' ', '@' };
        Assert.That(WordUtils.CapitalizeFully(str, delimiters), Is.EqualTo(expected));
    }

    [TestCase(null, null, false)]
    [TestCase(null, new string[] { "" }, false)]
    [TestCase(null, new string[] { "ab" }, false)]
    public void ContainsAllWords_WithNullString_ReturnsFalse(string str, string[] terms, bool expected)
    {
        Assert.That(WordUtils.ContainsAllWords(str, terms), Is.EqualTo(expected));
    }

    [TestCase("", null, false)]
    [TestCase("", new string[] { "" }, false)]
    [TestCase("", new string[] { "ab" }, false)]
    public void ContainsAllWords_WithEmptyString_ReturnsFalse(string str, string[] terms, bool expected)
    {
        Assert.That(WordUtils.ContainsAllWords(str, terms), Is.EqualTo(expected));
    }

    [TestCase("foo", null, false)]
    [TestCase("bar", new string[] { "" }, false)]
    [TestCase("zzabyyxdxx", new string[] { "ab" }, false)]
    [TestCase("lorem ipsum dolor sit amet", new string[] { "ipsum", "lorem", "dolor" }, true)]
    [TestCase("lorem ipsum dolor sit amet", new string[] { "ipsum", null, "lorem", "dolor" }, false)]
    [TestCase("lorem null ipsum dolor sit amet", new string[] { "ipsum", null, "lorem", "dolor" }, false)]
    public void ContainsAllWords_WithValidStringAndTerms_ReturnsExpectedResults(string str, string[] terms,
        bool expected)
    {
        Assert.That(WordUtils.ContainsAllWords(str, terms), Is.EqualTo(expected));
    }

    [TestCase(null, null)]
    [TestCase("", "")]
    [TestCase(" ", " ")]
    public void SwapCase_WithNullOrEmptyInput_ReturnsExpectedResults(string str, string expected)
    {
        Assert.That(WordUtils.SwapCase(str), Is.EqualTo(expected));
    }

    [TestCase("I", "i")]
    [TestCase("i", "I")]
    [TestCase("i am here 123", "I AM HERE 123")]
    [TestCase("I Am Here 123", "i aM hERE 123")]
    [TestCase("i am HERE 123", "I AM here 123")]
    [TestCase("I AM HERE 123", "i am here 123")]
    public void SwapCase_WithVariousCasesInput_ReturnsExpectedResults(string str, string expected)
    {
        Assert.That(WordUtils.SwapCase(str), Is.EqualTo(expected));
    }

    [TestCase(null, null)]
    [TestCase("", "")]
    [TestCase(" ", " ")]
    public void Uncapitalize_WithoutDelimiterListAndEmptyInput_ReturnsExpectedResults(string str, string expected)
    {
        Assert.That(WordUtils.Uncapitalize(str), Is.EqualTo(expected));
    }

    [TestCase("I", "i")]
    [TestCase("i", "i")]
    [TestCase("i am here 123", "i am here 123")]
    [TestCase("I Am Here 123", "i am here 123")]
    [TestCase("i am HERE 123", "i am hERE 123")]
    [TestCase("I AM HERE 123", "i aM hERE 123")]
    public void Uncapitalize_WithoutDelimiterListAndRandomCasedStringInput_ReturnsExpectedResults(string str,
        string expected)
    {
        Assert.That(WordUtils.Uncapitalize(str), Is.EqualTo(expected));
    }

    [TestCase(null, null, null)]
    [TestCase("", new char[]{}, "")]
    [TestCase(" ", new char[]{}, " ")]
    public void Uncapitalize_WithEmptyDelimiterListAndEmptyInput_ReturnsExpectedResults(string str, char[]? delimiters,
        string expected)
    {
        Assert.That(WordUtils.Uncapitalize(str, delimiters), Is.EqualTo(expected));
    }
    
    [TestCase("I", new char[]{'-', '+', ' ', '@'}, "i")]
    [TestCase("i", new char[]{'-', '+', ' ', '@'}, "i")]
    [TestCase("i am-here+123", new char[]{'-', '+', ' ', '@'}, "i am-here+123")]
    [TestCase("I+Am Here-123", new char[]{'-', '+', ' ', '@'}, "i+am here-123")]
    [TestCase("i-am+HERE 123", new char[]{'-', '+', ' ', '@'}, "i-am+hERE 123")]
    [TestCase("I AM-HERE+123", new char[]{'-', '+', ' ', '@'}, "i aM-hERE+123")]
    public void Uncapitalize_WithDelimiterListAndInput_ReturnsExpectedResults(string str, char[]? delimiters,
        string expected)
    {
        Assert.That(WordUtils.Uncapitalize(str, delimiters), Is.EqualTo(expected));
    }

}