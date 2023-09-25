// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

Console.WriteLine(ToUnderscore("TestController98This"));

static string ToUnderscore(string str)
{
    var result = str[0].ToString();
	for (int i = 1; i < str.Length; i++)
	{
		var isNumber = int.TryParse(str[i].ToString(), out int a);
		if (Char.IsUpper(str[i])&& !isNumber)
			result += $"_";
		result += str[i];
	}
	return result.ToLower();
}