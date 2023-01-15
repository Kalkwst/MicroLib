namespace Graph;

/// <summary>
/// Represents a graph data structure.
/// </summary>
/// <typeparam name="TVertex">The Graph's vertices type.</typeparam>
/// <typeparam name="TEdge">The Graph's edges type.</typeparam>
public interface IGraph<TVertex, TEdge>
{
    /// <summary>
    /// Returns the total set of Vertices in the graph.
    /// </summary>
    /// <returns>The total set of vertices in the graph.</returns>
    public IReadOnlyCollection<TVertex> GetVertices();

    /// <summary>
    /// Returns the <em>order</em> (the number of vertices) of the graph.
    /// </summary>
    /// <returns>The <em>order</em> of the graph.</returns>
    public int GetOrder();

    /// <summary>
    /// Returns the total set of Edges in the graph.
    /// </summary>
    /// <returns>The total set of edges in the graph.</returns>
    public IReadOnlyCollection<TVertex> GetEdges();

    /// <summary>
    /// Returns the <em>size</em> (the number of edges) of a graph.
    /// </summary>
    /// <returns>The <em>size</em> of the graph.</returns>
    public int GetSize();

    /// <summary>
    /// The degree (or valency) of a vertex of a graph.
    /// </summary>
    /// <param name="v">The vertex which degree has to be returned.</param>
    /// <returns>The number of edges incident to the vertex.</returns>
    public int GetDegree(TVertex v);

    /// <summary>
    /// Returns all vertices which touch this vertex.
    /// </summary>
    /// <param name="v">The vertex which connected vertices have to be returned.</param>
    /// <returns>All vertices which touch this vertex.</returns>
    public IReadOnlyCollection<TVertex> GetConnectedVertices(TVertex v);

    /// <summary>
    /// Returns the edge with vertex source and target.
    /// </summary>
    /// <param name="source">The source vertex.</param>
    /// <param name="target">The target vertex.</param>
    /// <returns>The edge with vertex source and target.</returns>
    public TEdge GetEdge(TVertex source, TVertex target);

    /// <summary>
    /// Returns the set of vertices on the input edge (2 for normal edges, &gt; 2 for HyperEdges)
    /// </summary>
    /// <param name="e">The input edge.</param>
    /// <returns>The set of vertices on this edge.</returns>
    public VertexPair<TVertex> GetVertices(TEdge e);

    /// <summary>
    /// Returns true if the vertex is contained into the graph.
    /// </summary>
    /// <param name="v">The vertex to be checked.</param>
    /// <returns>Returns true if the vertex is contained into the graph, false otherwise.</returns>
    public bool ContainsVertex(TVertex v);

    /// <summary>
    /// Returns true if the edge is contained into the graph.
    /// </summary>
    /// <param name="e">The edge to be checked.</param>
    /// <returns>Returns true if the edge is contained into the graph, false otherwise.</returns>
    public bool ContainsEdge(TEdge e);
}