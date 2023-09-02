internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(StripComments("Apples #this that those !bracelets" , new string[] { "#" , "!"}));
    }

    public static string StripComments(string text, string[] commentSymbols)
    {
        return "";
    }
}