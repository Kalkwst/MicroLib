using Text.Similarity.Jaccard;

namespace TextTests.Similarity.Jaccard;

[TestFixture]
public class JaccardSimilarityTests
{
    private JaccardSimilarity similarity;

    [SetUp]
    public void Init()
    {
        similarity = new JaccardSimilarity();
    }

    [TestCase("", "", 1.0)]
    [TestCase("left", "", 0.0)]
    [TestCase("", "right", 0.0)]
    [TestCase("frog", "fog", (3.0/4))]
    [TestCase("fly", "ant", (0.0))]
    [TestCase("elephant", "hippo", (2.0/9))]
    [TestCase("ABC Corporation", "ABC Corp", (7.0/11))]
    [TestCase("ABC Corporation", "ABC Corp", (7.0/11))]
    [TestCase("D N H Enterprises Inc", "D & H Enterprises, Inc.", (13.0/17))]
    [TestCase("My Gym Children's Fitness Center", "My Gym. Childrens Fitness", (16.0/18))]
    [TestCase("PENNSYLVANIA", "PENNCISYLVNIA", (9.0/10))]
    [TestCase("left", "right", (1.0/8))]
    
    public void JaccardDistanceWithValidStrings(string left, string right, double expected)
    {
        Assert.That(similarity.Calculate(left, right), Is.EqualTo(expected));
    }

    [TestCase("left", null)]
    [TestCase(null, "right")]
    [TestCase(null, null)]
    public void JaccardDistanceWithSomeNullStrings(string left, string right)
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            similarity.Calculate(left, right);
        });
    }
}