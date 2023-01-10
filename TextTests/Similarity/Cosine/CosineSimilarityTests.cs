using Text.Similarity.Cosine;

namespace TextTests.Similarity.Cosine;

[TestFixture]
public class CosineSimilarityTests
{
    [Test]
    public void CosineSimilarityReturnsDoubleWhereByteValueIsZero()
    {
        var cosineSimilarity = new CosineSimilarity();

        Assert.Throws<ArgumentException>(() => cosineSimilarity.Calculate("", ""));
    }

    [Test]
    public void CosineSimilarityThrowsArgumentNullExceptionForNullDictionary()
    {
        var cosineSimilarity = new CosineSimilarity();

        Assert.Throws<ArgumentException>(() => cosineSimilarity.Calculate("string", null));
    }
}