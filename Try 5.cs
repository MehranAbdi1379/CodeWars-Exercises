using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;

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

        for (int count = 0; count < V - 1; ++count)
        {
            int u = FindMinDistance(dist, visited);

            visited[u] = true;

            foreach ((int, int) edge in adj[u])
            {
                int v = edge.Item1;
                int weight = edge.Item2;

                if (!visited[v] && dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                {
                    dist[v] = dist[u] + weight;
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
                    Console.Write(" -1");
                else
                    Console.Write(" " + dist[i]);
            }

            else Console.Write("0");
        }
    }


}