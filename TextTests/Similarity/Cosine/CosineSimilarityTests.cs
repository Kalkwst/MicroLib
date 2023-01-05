using Text.Similarity.Cosine;

namespace TextTests.Similarity.Cosine;

[TestFixture]
public class CosineSimilarityTests
{
    [Test]
    public void CosineSimilarityReturnsDoubleWhereByteValueIsZero()
    {
        var cosineSimilarity = new CosineSimilarity();

        var result = cosineSimilarity.Calculate("", "");

        Assert.That(result, Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void CosineSimilarityThrowsArgumentNullExceptionForNullDictionary()
    {
        var cosineSimilarity = new CosineSimilarity();
        
        Assert.Throws<ArgumentNullException>(() =>
        {
            cosineSimilarity.Calculate("string", null);
        });
    }
}