using Text.Similarity.Jaccard;

namespace TextTests.Similarity.Jaccard;

[TestFixture]
public class JaccardDistanceTests
{
    private JaccardDistance distance = null!;

    [SetUp]
    public void Init()
    {
        distance = new JaccardDistance();
    }

    [TestCase("", "", 0.0)]
    [TestCase("left", "", 1.0)]
    [TestCase("", "right", 1.0)]
    [TestCase("frog", "fog", 1.0 - (3.0 / 4))]
    [TestCase("fly", "ant", 1.0)]
    [TestCase("elephant", "hippo", 1.0 - (2.0 / 9))]
    [TestCase("ABC Corporation", "ABC Corp", 1.0 - (7.0 / 11))]
    [TestCase("ABC Corporation", "ABC Corp", 1.0 - (7.0 / 11))]
    [TestCase("D N H Enterprises Inc", "D & H Enterprises, Inc.", 1.0 - (13.0 / 17))]
    [TestCase("My Gym Children's Fitness Center", "My Gym. Childrens Fitness", 1.0 - (16.0 / 18))]
    [TestCase("PENNSYLVANIA", "PENNCISYLVNIA", 1.0 - (9.0 / 10))]
    [TestCase("left", "right", 1.0 - (1.0 / 8))]

    public void JaccardDistanceWithValidStrings(string left, string right, double expected)
    {
        Assert.That(distance.Calculate(left, right), Is.EqualTo(expected));
    }

    [TestCase("left", null)]
    [TestCase(null, "right")]
    [TestCase(null, null)]
    public void JaccardDistanceWithSomeNullStrings(string left, string right)
    {
        Assert.Throws<ArgumentNullException>(() => distance.Calculate(left, right));
    }
}