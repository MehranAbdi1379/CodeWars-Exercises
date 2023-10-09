// See https://aka.ms/new-console-template for more information

var input = SinglePermutations("abc");

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
    return permutations;
}

static void Reccursive(List<string> permutations , List<char> elements, string result)
{
    result += elements[0];
    elements.Remove(elements[0]);
    if(elements.Count > 0 )
        Reccursive(permutations,elements, result);
    else
    {
        permutations.Add(result);
    }
    
}