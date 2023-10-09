// See https://aka.ms/new-console-template for more information


using System.Diagnostics;

var stopWatch = new Stopwatch();
stopWatch.Start();
var input = SinglePermutations("abcfddssdfd");
stopWatch.Stop();

Console.WriteLine(stopWatch.ElapsedMilliseconds);



static List<string> SinglePermutations(string s)
{
    var permutations = new List<string>();
    List<char> elements = s.ToList();
    var result = "";
    Reccursive(permutations, elements, result);
    permutations.Distinct();
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