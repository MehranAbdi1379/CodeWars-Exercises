using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;



var input = Console.ReadLine().Split(' ');
var n = int.Parse(input[0]);
var m = int.Parse(input[1]);
var vertexes = new List<Vertex>();
var tables = new List<Table>();

for (int i = 0; i < n; i++)
{
    vertexes.Add(new Vertex() { Id = i });
    if (i == 0)
        tables.Add(new Table() { VertexId = i, ShortestDistanceFromFirstNode = 0, PreviousVertexId = 0 });
    else
        tables.Add(new Table() { VertexId = i });
}

for (int i = 0; i < m; i++)
{
    var edges = Console.ReadLine().Split(' ').ToArray();
    if (edges[0] != edges[1])
        vertexes[int.Parse(edges[0]) - 1].Edges.Add((int.Parse(edges[1]) - 1, long.Parse(edges[2])));
}

var currentVertex = vertexes[0];

while (vertexes.Count > 0)
{
    var neighbors = vertexes.Where(v => currentVertex.Edges.Any(e => e.Item1 == v.Id)).ToList();
    vertexes.Remove(currentVertex);
    if (neighbors.Count == 0)
        break;
    currentVertex = FindMinimum(neighbors, vertexes, currentVertex, tables);
}

string result = "0";
tables.Remove(tables[0]);

foreach (var table in tables)
{
    if (table.ShortestDistanceFromFirstNode == long.MaxValue)
        result += " " + "-1";
    else
        result += " " + table.ShortestDistanceFromFirstNode;
}

Console.WriteLine(result);

static Vertex FindMinimum(List<Vertex> neighbors, List<Vertex> vertexes, Vertex currentVertex, List<Table> tables)
{
    List<(int, long)> distances = new List<(int, long)>();
    foreach (var neighbor in neighbors)
    {
        var nodeTable = tables.Where(t => t.VertexId == neighbor.Id).First();
        var currentNodeTable = tables.Where(t => t.VertexId == currentVertex.Id).First();
        var minEdge = currentVertex.Edges.Where(e => e.Item1 == neighbor.Id).Select(e => e.Item2).Min();
        var finalDistance = minEdge + currentNodeTable.ShortestDistanceFromFirstNode;
        if (finalDistance < nodeTable.ShortestDistanceFromFirstNode)
            nodeTable.ShortestDistanceFromFirstNode = finalDistance;
        nodeTable.PreviousVertexId = currentVertex.Id;
        distances.Add((neighbor.Id, finalDistance));
    }
    distances = distances.OrderBy(d => d.Item2).ToList();
    return vertexes.Where(v => v.Id == distances[0].Item1).First();
}


public class Vertex
{
    public int Id { get; set; }
    public List<(int, long)> Edges = new List<(int, long)>();
}

public class Table
{
    public int VertexId { get; set; }
    public long ShortestDistanceFromFirstNode { get; set; } = long.MaxValue;
    public int? PreviousVertexId { get; set; }
}