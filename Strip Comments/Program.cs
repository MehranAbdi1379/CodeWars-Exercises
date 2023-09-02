using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(StripComments("\n \n   \n \n a #b\nc      \nd $e f g", new string[] { "#" }));
    }

    public static string StripComments(string text, string[] commentSymbols)
    {
        text += "\n";
        foreach (var symbol in commentSymbols)
        {
            var reg = new Regex($"{symbol}.*");
            if (symbol == "$")
                reg = new Regex("\\$.*");
            text = reg.Replace(text, "");
            var regEx = new Regex("\\s*\n");
            text = regEx.Replace(text, "\n");
            text = text.Replace(symbol, "");
        }
                text = text.Remove(text.Length - 1, 1);
        return text;
    }
}