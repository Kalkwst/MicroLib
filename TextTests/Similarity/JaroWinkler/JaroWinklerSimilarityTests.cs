using Text.Similarity.JaroWinkler;

namespace TextTests.Similarity.JaroWinkler;

[TestFixture]
public class JaroWinklerSimilarityTests
{
    private JaroWinklerSimilarity similarity;

    [SetUp]
    public void Init()
    {
        similarity = new JaroWinklerSimilarity();
    }

    [TestCase(null, null)]
    [TestCase(null, "clear")]
    [TestCase(" ", null)]
    public void JaroWinklerSimilarity_WithNullStrings_ThrowsArgumentNullException(string left, string right)
    {
        Assert.Throws<ArgumentNullException>(() => { similarity.Calculate(left, right); });
    }

    [TestCase("", "", 1d, 0.00001d)]
    [TestCase("foo", "foo", 1d, 0.00001d)]
    [TestCase("foo", "foo ", 0.94166d, 0.00001d)]
    [TestCase("foo", "foo  ", 0.90666d, 0.00001d)]
    [TestCase("foo", " foo ", 0.86666d, 0.00001d)]
    [TestCase("foo", "  foo", 0.51111d, 0.00001d)]
    [TestCase("frog", "fog", 0.92499d, 0.00001d)]
    [TestCase("fly", "ant", 0.0d, 0.00000000000000000001d)]
    [TestCase("elephant", "hippo", 0.44166d, 0.00001d)]
    [TestCase("ABC Corporation", "ABC Corp", 0.90666d, 0.00001d)]
    [TestCase("D N H Enterprises Inc", "D & H Enterprises, Inc.", 0.95251d, 0.00001d)]
    [TestCase("My Gym Children's Fitness Center", "My Gym. Childrens Fitness", 0.942d, 0.00001d)]
    [TestCase("PENNSYLVANIA", "PENNCISYLVNIA", 0.898018d, 0.00001d)]
    [TestCase("/opt/software1", "/opt/software2", 0.971428d, 0.00001d)]
    [TestCase("aaabcd", "aaacdb", 0.941666d, 0.00001d)]
    [TestCase("John Horn", "John Hopkins", 0.911111d, 0.00001d)]
    public void JaroWinklerSimilarity_WithValidStrings_ReturnsExpectedSimilarity(string left,
        string right, double expected, double threshold)
    {
        Assert.That(similarity.Calculate(left, right), Is.EqualTo(expected).Within(threshold));
    }
}