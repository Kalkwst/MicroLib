namespace Text.Similarity;

/// <summary>
/// Interface for <a href="http://en.wikipedia.org/wiki/Edit_distance">Edit Distance</a>.
/// <para>
/// An edit distance is a formal metric on the Kleene closure (<em>X<sup>*</sup></em>)  over an alphabet (<em>X</em>).
/// Note that a <a href="https://en.wikipedia.org/wiki/Metric_(mathematics)">metric</a> on a set <em>S</em> is a function
/// <code>
/// d: [S * S] -&gt; [0, INFINITY)
/// </code>
/// such that the following hold for <em>x, y, z</em> in the set <em>S</em>:
/// </para>
/// <list type="bullet">
///     <item>
///         <em>d(x,y) &gt;= 0</em>, non-negativity or separation axiom
///     </item>
///     <item>
///         <em>d(x,y) == 0</em>, if and only if, <em>code x == y</em>
///     </item>
///     <item>
///         <em>d(x,y) == d(y,x)</em>, symmetry, and
///     </item>
///     <item>
///         <em>d(x,z) &lt;=  d(x,y) + d(y,z)</em>, the triangle inequality.
///     </item>
/// </list>
/// </summary>
/// <typeparam name="T">The type of similarity score unit used by this EditDistance.</typeparam>
public interface IEditDistance<T> : ISimilarityScore<T>
{
    /// <summary>
    /// Compares two strings.
    /// </summary>
    /// <param name="left">The first string.</param>
    /// <param name="right">The second string.</param>
    /// <returns>The similarity score between two strings.</returns>
    public new T Calculate(string left, string right);
}