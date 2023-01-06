using Text.Similarity.JaroWinkler;

namespace TextTests.Similarity.JaroWinkler;

[TestFixture]
public class JaroWinklerDistanceTests
{
    private JaroWinklerDistance distance;

    [SetUp]
    public void Init()
    {
        distance = new JaroWinklerDistance();
    }


    [TestCase(null, null)]
    [TestCase(null, "clear")]
    [TestCase(" ", null)]
    public void JaroWinklerDistance_WithNullStrings_ThrowsArgumentNullException(string left, string right)
    {
        Assert.Throws<ArgumentNullException>(() => { distance.Calculate(left, right); });
    }

    [TestCase("", "", 1 - 1d, 0.00001d)]
    [TestCase("foo", "foo", 1 - 1d, 0.00001d)]
    [TestCase("foo", "foo ", 1 - 0.94166d, 0.00001d)]
    [TestCase("foo", "foo  ", 1 - 0.90666d, 0.00001d)]
    [TestCase("foo", " foo ", 1 - 0.86666d, 0.00001d)]
    [TestCase("foo", "  foo", 1 - 0.51111d, 0.00001d)]
    [TestCase("frog", "fog", 1 - 0.92499d, 0.00001d)]
    [TestCase("fly", "ant", 1 - 0.0d, 0.00000000000000000001d)]
    [TestCase("elephant", "hippo", 1 - 0.44166d, 0.00001d)]
    [TestCase("ABC Corporation", "ABC Corp", 1 - 0.90666d, 0.00001d)]
    [TestCase("D N H Enterprises Inc", "D & H Enterprises, Inc.", 1 - 0.95251d, 0.00001d)]
    [TestCase("My Gym Children's Fitness Center", "My Gym. Childrens Fitness", 1 - 0.942d, 0.00001d)]
    [TestCase("PENNSYLVANIA", "PENNCISYLVNIA", 1 - 0.898018d, 0.00001d)]
    [TestCase("/opt/software1", "/opt/software2", 1 - 0.971428d, 0.00001d)]
    [TestCase("aaabcd", "aaacdb", 1 - 0.941666d, 0.00001d)]
    [TestCase("John Horn", "John Hopkins", 1 - 0.911111d, 0.00001d)]
    public void JaroWinklerDistance_WithValidStrings_ReturnsExpectedDistance(string left, 
        string right, double expected, double threshold)
    {
        Assert.That(distance.Calculate(left, right), Is.EqualTo(expected).Within(threshold));
    }
}