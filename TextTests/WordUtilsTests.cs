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
}