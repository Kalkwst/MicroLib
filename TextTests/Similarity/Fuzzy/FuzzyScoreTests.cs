using System.Globalization;
using Text.Similarity.Fuzzy;

namespace TextTests.Similarity.Fuzzy;

[TestFixture]
public class FuzzyScoreTests
{
    private static readonly FuzzyScore EnglishScore = new(CultureInfo.GetCultureInfo("en-US"));

    [TestCase("", "", 0)]
    [TestCase("Workshop", "b", 0)]
    [TestCase("Room", "o", 1)]
    [TestCase("Workshop", "w", 1)]
    [TestCase("Workshop", "ws", 2)]
    [TestCase("Workshop", "wo", 4)]
    public void TestGetFuzzyScore(string term, string query, int expectedScore)
    {
        Assert.That(EnglishScore.CalculateFuzzyScore(term, query), Is.EqualTo(expectedScore));
    }

    [Test]
    public void FuzzyScore_NullNullLocale_ThrowsArgumentException()
    {
        Assert.That(() => EnglishScore.CalculateFuzzyScore(null, null), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void FuzzyScore_NullStringLocale_ThrowsArgumentException()
    {
        Assert.That(() => EnglishScore.CalculateFuzzyScore(null, "not null"), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void FuzzyScore_StringNullLocale_ThrowsArgumentException()
    {
        Assert.That(() => EnglishScore.CalculateFuzzyScore("not null", null), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Constructor_NullLocale_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentNullException>(() => new FuzzyScore(null));
    }
}