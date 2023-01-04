namespace Text.Similarity;

/// <summary>
/// Interface for the concept of a string similarity score.
/// <para>
/// A string similarity score is intended to have <em>some</em> of the properties of a metric, yet allowing for
/// exceptions, namely the Jaro-Winkler similarity score.
/// </para>
/// <para>
/// We define a SimilarityScore to be a function
/// <code>
/// d: [ X * X ] -&gt; [ 0, INFINITY ]
/// </code>
/// with the following properties:
/// </para>
/// <list type="bullet">
///     <item>
///             <em>d(x,y) &gt;= 0</em>, non-negativity or separation axiom
///     </item>
///     <item>
///             <em>d(x,y) == d(y,x)</em>, symmetry.
///     </item>
/// </list>
/// <para>
/// Notice, these are two of the properties that contribute to <em>d</em> being a metric.
/// </para>
/// </summary>
/// <typeparam name="T">The type of similarity score unit used by this EditDistance.</typeparam>
public interface ISimilarityScore<T>
{
    /// <summary>
    /// Compares two strings.
    /// </summary>
    /// <param name="left">The first string.</param>
    /// <param name="right">The second string.</param>
    /// <returns>The similarity score between two strings.</returns>
    public T Calculate(string left, string right);
}