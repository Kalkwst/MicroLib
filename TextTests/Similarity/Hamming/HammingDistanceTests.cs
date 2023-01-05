using Text.Similarity.Hamming;

namespace TextTests.Similarity.Hamming;

[TestFixture]
public class HammingDistanceTests
{
    private HammingDistance distance;

    [SetUp]
    public void Init()
    {
        distance = new HammingDistance();
    }

    [TestCase("", "", 0)]
    [TestCase("pappa", "pappa", 0)]
    [TestCase("papaa", "pappa", 1)]
    [TestCase("karolin", "kathrin", 3)]
    [TestCase("karolin", "kerstin", 3)]
    [TestCase("1011101", "1001001", 2)]
    [TestCase("2173896", "2233796", 3)]
    [TestCase("ATCG", "ACCC", 2)]
    public void HammingDistanceValidStrings(string leftValue, string rightValue, int expectedDistance)
    {
        // Arrange
        // The distance object is initialized in the SetUp method

        // Act
        int actualDistance = distance.Calculate(leftValue, rightValue);

        // Assert
        Assert.That(actualDistance, Is.EqualTo(expectedDistance));
    }

    [Test]
    public void HammingDistanceNullLeftValue()
    {
        // Arrange
        // The distance object is initialized in the SetUp method

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => distance.Calculate(null, ""));
    }

    [Test]
    public void HammingDistanceNullRightValue()
    {
        // Arrange
        // The distance object is initialized in the SetUp method

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => distance.Calculate("", null));
    }
}