// See https://aka.ms/new-console-template for more information


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

var stopWatch = new Stopwatch();
stopWatch.Start();
var input = SinglePermutations("aabb");
stopWatch.Stop();

Console.WriteLine(stopWatch.ElapsedMilliseconds);

foreach (var item in input)
{
    Console.WriteLine(item);
}



static List<string> SinglePermutations(string s)
{
    var permutations = new List<string>();
    List<char> elements = s.ToList();
    var result = "";
    Reccursive(permutations, elements, result);
    permutations = permutations.Distinct().ToList();
    return permutations;
}

static void Reccursive(List<string> permutations , List<char> elements,string result)
{
    for (int i = 0; i < elements.Count; i++)
    {
        result += elements[i];
        var tempElements = new List<char>();

        foreach (var element in elements)
        {
            tempElements.Add(element);
        }

        tempElements.Remove(tempElements[i]);

        if (tempElements.Count > 0)
        {
            Reccursive(permutations, tempElements, result);
            result = result.Remove(result.Length-1,1);
        }
        else
        {
            permutations.Add(result);

        }
    }
}