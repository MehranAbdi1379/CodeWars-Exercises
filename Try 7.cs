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
    private List<(int, long)>[] adj;

    public Dijkstra(int v)
    {
        V = v;
        adj = new List<(int, long)>[v];
        for (int i = 0; i < v; ++i)
        {
            adj[i] = new List<(int, long)>();
        }
    }

    public void AddEdge(int u, int v, long weight)
    {
        adj[u].Add((v, weight));
    }

    public void ShortestPath(int source)
    {
        long[] dist = new long[V];
        bool[] visited = new bool[V];

        for (int i = 0; i < V; ++i)
        {
            dist[i] = long.MaxValue;
            visited[i] = false;
        }

        dist[source] = 0;

        var priorityQueue = new MinHeap<(long, int)>((a, b) => a.Item1.CompareTo(b.Item1));

        priorityQueue.Push((0, source));

        while (priorityQueue.Count > 0)
        {
            var (d, u) = priorityQueue.Pop();

            if (visited[u]) continue;
            visited[u] = true;

            foreach ((int, int) edge in adj[u])
            {
                int v = edge.Item1;
                int weight = edge.Item2;

                if (!visited[v] && dist[u] != long.MaxValue && dist[u] + weight < dist[v])
                {
                    dist[v] = dist[u] + weight;
                    priorityQueue.Push((dist[v], v));
                }
            }
        }

        PrintResult(dist);
    }

    private int FindMinDistance(int[] dist, bool[] visited)
    {
        long min = long.MaxValue;
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

    private void PrintResult(long[] dist)
    {
        for (int i = 0; i < dist.Length; i++)
        {
            if (i != 0)
            {
                if (dist[i] == long.MaxValue)
                    Console.Write(" -1");
                else
                    Console.Write(" " + dist[i]);
            }

            else Console.Write("0");
        }
    }


}

class MinHeap<T>
{
    private List<T> heap;
    private Comparison<T> compare;

    public MinHeap(Comparison<T> comparison)
    {
        heap = new List<T>();
        compare = comparison;
    }

    public int Count => heap.Count;

    public void Push(T item)
    {
        heap.Add(item);
        int i = heap.Count - 1;

        while (i > 0)
        {
            int parent = (i - 1) / 2;

            if (compare(heap[parent], heap[i]) <= 0)
                break;

            (heap[i], heap[parent]) = (heap[parent], heap[i]);
            i = parent;
        }
    }

    public T Pop()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        T item = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);

        int i = 0;
        while (true)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int smallest = i;

            if (left < heap.Count && compare(heap[left], heap[smallest]) < 0)
                smallest = left;

            if (right < heap.Count && compare(heap[right], heap[smallest]) < 0)
                smallest = right;

            if (smallest == i)
                break;

            (heap[i], heap[smallest]) = (heap[smallest], heap[i]);
            i = smallest;
        }

        return item;
    }
}