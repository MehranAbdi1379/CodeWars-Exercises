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

var inputArray = Console.ReadLine().Split(' ');

    Dijkstra graph = new Dijkstra(int.Parse(inputArray[0]));

for (int i = 0; i < int.Parse(inputArray[1]); i++)
{
    var anotherInput = Console.ReadLine().Split(' ');
    graph.AddEdge(int.Parse(anotherInput[0]) - 1, int.Parse(anotherInput[1]) - 1, int.Parse(anotherInput[2]));
}

int source = 0;

    graph.ShortestPath(source);

class Dijkstra
{
    private int V; 
    private List<(int, int)>[] adj;

    public Dijkstra(int v)
    {
        V = v;
        adj = new List<(int, int)>[v];
        for (int i = 0; i < v; ++i)
        {
            adj[i] = new List<(int, int)>();
        }
    }

    public void AddEdge(int u, int v, int weight)
    {
        adj[u].Add((v, weight));
    }

    public void ShortestPath(int source)
    {
        int[] dist = new int[V];
        bool[] visited = new bool[V];

        for (int i = 0; i < V; ++i)
        {
            dist[i] = int.MaxValue;
            visited[i] = false;
        }

        dist[source] = 0;

        var priorityQueue = new SortedSet<(int, int)>();

        priorityQueue.Add((0, source));

        while (priorityQueue.Count > 0)
        {
            var (d, u) = priorityQueue.First();
            priorityQueue.Remove((d, u));

            if (visited[u]) continue;
            visited[u] = true;

            foreach ((int, int) edge in adj[u])
            {
                int v = edge.Item1;
                int weight = edge.Item2;

                if (!visited[v] && dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                {
                    dist[v] = dist[u] + weight;
                    priorityQueue.Add((dist[v], v));
                }
            }
        }

        PrintResult(dist);
    }

    private int FindMinDistance(int[] dist, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < V; ++v)
        {
            if (!visited[v] && dist[v] <= min)
            {
                min = dist[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    private void PrintResult(int[] dist)
    {
        for (int i = 0; i < dist.Length; i++)
        {
            if (i != 0)
            {
                if (dist[i] == int.MaxValue)
                    Console.Write(" -1") ;
                else
                    Console.Write(" " + dist[i]);
            }
                
            else Console.Write("0");
        }
    }

    
}