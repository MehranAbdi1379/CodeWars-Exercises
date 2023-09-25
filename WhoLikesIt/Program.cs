// See https://aka.ms/new-console-template for more information

Console.WriteLine(Likes(new string[0]));
Console.WriteLine(Likes(new string[] { "Jacob", "Alex" }));


static string Likes(string[] names)
{
    return names switch
    {
        string[] name when name.Length == 0 => "no one likes this",
        string[] name when name.Length == 1 => $"{name[0]} likes this",
        string[] name when name.Length == 2 => $"{name[0]} and {name[1]} like this",
        string[] name when name.Length == 3 => $"{name[0]}, {name[1]} and {name[2]} like this",
        string[] name when name.Length > 3 => $"{name[0]}, {name[1]} and {name.Length - 2} others like this"
    };
}