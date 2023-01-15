namespace Graph;

public interface IDirectedGraph<TVertex, TEdge> : IGraph<TVertex, TEdge>
{
    /// <summary>
    /// For a vertex, the number of head endpoints adjacent to a node is called the in-degree.
    /// </summary>
    /// <param name="vertices">The vertex which in-degree has to be returned.</param>
    /// <returns>The number of head endpoints adjacent to a vertex.</returns>
    public int GetInDegree(TVertex vertices);

    /// <summary>
    /// Returns the set of edges which are inbound to the vertex.
    /// </summary>
    /// <param name="vertex">The vertex which inbound edges have to be returned.</param>
    /// <returns>The set of edges which are inbound to the vertex.</returns>
    public IReadOnlyCollection<TVertex> GetInbound(TVertex vertex);

    /// <summary>
    /// For a vertex, the number of tail endpoints adjacent to a node is called the out-degree.
    /// </summary>
    /// <param name="vertex">The vertex which outbound vertices have to be returned.</param>
    /// <returns>The number of tail endpoints adjacent to the vertex.</returns>
    public int GetOutDegree(TVertex vertex);

    /// <summary>
    /// Returns the set of edges which are outbound to the vertex.
    /// </summary>
    /// <param name="vertices">The vertex which outbound edges have to be returned. </param>
    /// <returns>The set of edges which are outbound to the vertex.</returns>
    public IReadOnlyCollection<TVertex> GetOutbound(TVertex vertices);
}