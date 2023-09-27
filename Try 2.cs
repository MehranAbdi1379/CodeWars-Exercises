using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

var firstInput = Console.ReadLine();
var n = int.Parse(firstInput.Split(' ')[0]);
var m = int.Parse(firstInput.Split(' ')[1]);
var paths = new List<Path>();

for (int i = 0; i < m; i++)
{
    var secondInputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
    if (secondInputArray[0] != secondInputArray[1])
        paths.Add(new Path() { StartPoint = secondInputArray[0], EndPoint = secondInputArray[1], Weight = secondInputArray[2] });
}

var resultSting = "0";

for (int i = 2; i <= n; i++)
{
        var totalWeights = new List<int>();
        var totalWeight = 0;
        ReccursiveMethod(i, totalWeight, paths, totalWeights);
    if (totalWeights.Count == 0)
        resultSting += " " + "-1";
    else
        resultSting += " " + totalWeights.Min();
}

Console.WriteLine(resultSting);

static void ReccursiveMethod(int currentEndPoint ,int totalWeight , List<Path> paths , List<int> totalWeights)
{
    foreach (var path in paths)
    {
        if (path.EndPoint == currentEndPoint && path.StartPoint == 1)
        {
            totalWeight += path.Weight;
            totalWeights.Add(totalWeight);
            totalWeight -= path.Weight;
        }
        else if (path.EndPoint == currentEndPoint)
        {
            var newTotalWeight = totalWeight;
            newTotalWeight += path.Weight;
            var newPaths = new List<Path>();
            foreach (var item in paths)
            {
                newPaths.Add(item);
            }
            newPaths.RemoveAll(p => p.EndPoint == currentEndPoint || p.StartPoint == currentEndPoint);
            ReccursiveMethod(path.StartPoint, newTotalWeight, newPaths , totalWeights);
        }
    }
}

public class Path
{
    public int StartPoint { get; set; }
    public int EndPoint { get; set; }
    public int Weight { get; set; }
}