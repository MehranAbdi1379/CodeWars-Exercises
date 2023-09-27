using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;

//var firstInput = Console.ReadLine();
//var n = int.Parse(firstInput.Split(' ')[0]);
//var m = int.Parse(firstInput.Split(' ')[1]);
//var paths = new List<Path>();

//for (int i = 0; i < m; i++)
//{
//    var secondInputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
//    if (secondInputArray[0] != secondInputArray[1])
//        paths.Add(new Path() { StartPoint = secondInputArray[0], EndPoint = secondInputArray[1], Weight = secondInputArray[2] });
//}

//var resultSting = "0";

//for (int i = 2; i <= n; i++)
//{
//        var totalWeights = new List<int>();
//        var totalWeight = 0;
//        ReccursiveMethod(i, totalWeight, paths, totalWeights);
//    if (totalWeights.Count == 0)
//        resultSting += " " + "-1";
//    else
//        resultSting += " " + totalWeights.Min();
//}

//Console.WriteLine(resultSting);

//static void ReccursiveMethod(int currentEndPoint ,int totalWeight , List<Path> paths , List<int> totalWeights)
//{
//    foreach (var path in paths)
//    {
//        if (path.EndPoint == currentEndPoint && path.StartPoint == 1)
//        {
//            totalWeight += path.Weight;
//            totalWeights.Add(totalWeight);
//            totalWeight -= path.Weight;
//        }
//        else if (path.EndPoint == currentEndPoint)
//        {
//            var newTotalWeight = totalWeight;
//            newTotalWeight += path.Weight;
//            var newPaths = new List<Path>();
//            foreach (var item in paths)
//            {
//                newPaths.Add(item);
//            }
//            newPaths.RemoveAll(p => p.EndPoint == currentEndPoint || p.StartPoint == currentEndPoint);
//            ReccursiveMethod(path.StartPoint, newTotalWeight, newPaths , totalWeights);
//        }
//    }
//}

//public class Path
//{
//    public int StartPoint { get; set; }
//    public int EndPoint { get; set; }
//    public int Weight { get; set; }
//}


var input = Console.ReadLine().Split(' ');
var n = int.Parse(input[0]);
var m = int.Parse(input[1]);
var vertexes = new Vertex[n];
var results = new Result[n];

for (int i = 0; i < n; i++)
{
    vertexes.Append(new Vertex() { Id = i });
}

for (int i = 0; i < m; i++)
{
    var edges = Console.ReadLine().Split(' ').ToArray();
    if (edges[0] != edges[1])
        vertexes[int.Parse(edges[0]) - 1].Edges.Add((int.Parse(edges[1]) - 1 , long.Parse(edges[2])));
}

var currentVertex = vertexes[0];

while(vertexes.Length > 0)
{
    var neighbors = vertexes.Where(v => currentVertex.Edges.Any(e => e.Item1 == v.Id)).ToList();
    vertexes.Remove(currentVertex);
    if (vertexes.Count == 0)
        break;
    if (neighbors.Count == 0)
    {
        currentVertex = vertexes.Where(v => v.Id == tables.Where(t => vertexes.Any(v => v.Id == t.VertexId))
            .MinBy(t => t.ShortestDistanceFromFirstNode).VertexId).First();
    }
    else
    {
        currentVertex = FindMinimum(neighbors, vertexes, currentVertex, tables);
    }
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

static Vertex FindMinimum(List<Vertex> neighbors , List<Vertex> vertexes , Vertex currentVertex, List<Table> tables)
{
    List<(int , long)> distances = new List<(int, long)>();
    foreach (var neighbor in neighbors)
    {
        var nodeTable = tables.Where(t => t.VertexId == neighbor.Id).First();
        var currentNodeTable = tables.Where(t => t.VertexId == currentVertex.Id).First();
        var minEdge = currentVertex.Edges.Where(e => e.Item1 == neighbor.Id).Select(e => e.Item2).Min();
        var finalDistance = minEdge + currentNodeTable.ShortestDistanceFromFirstNode;
        if (finalDistance < nodeTable.ShortestDistanceFromFirstNode)
            nodeTable.ShortestDistanceFromFirstNode = finalDistance;
        nodeTable.PreviousVertexId = currentVertex.Id;
        distances.Add((neighbor.Id , finalDistance));
    }
    distances = distances.OrderBy(d => d.Item2).ToList();
    return vertexes.Where(v => v.Id == distances[0].Item1).First();
}

var vertexesArr = new int[3];

public class Vertex
{
    public int Id { get; set; }
    public List<(int, long)> Edges = new List<(int, long)>();
    public int ShortestPath { get; set; }
    public int PreviousVertexId { get; set; }
}

public class Result
{
    public int VertexId { get; set; }
    public int ShortestPath { get; set; }
}