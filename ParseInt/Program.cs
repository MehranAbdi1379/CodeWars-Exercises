// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

static int ParseInt(string s)
{
    s = s.Replace("and ", "");

    var words = s.Split(' ');

    switch (words.Length)
    {
        case 0:
            if (CheckForOneDigitNumbers(s) == -1)
                return CheckForTwoDigitUsualNumbers(s);
            else return CheckForOneDigitNumbers(s);
        case 1:
            return 0;
        case 2:
            return 0;
        default:
            return 0;
    }
}

static int CheckForOneDigitNumbers(string number)
{
    return number switch
    {
        string newNumber when newNumber == "one" => 1,
        string newNumber when newNumber == "two" => 2,
        string newNumber when newNumber == "three" => 3,
        string newNumber when newNumber == "four" => 4,
        string newNumber when newNumber == "five" => 5,
        string newNumber when newNumber == "six" => 6,
        string newNumber when newNumber == "seven" => 7,
        string newNumber when newNumber == "eight" => 8,
        string newNumber when newNumber == "nine" => 9,
        _ => -1
    };
}

static int CheckForTwoDigitUnusualNumbers(string number)
{
    return number switch
    {
        string newNumber when newNumber == "ten" => 10,
        string newNumber when newNumber == "eleven" => 11,
        string newNumber when newNumber == "twelve" => 12,
        string newNumber when newNumber == "thirteen" => 13,
        string newNumber when newNumber == "fourteen" => 14,
        string newNumber when newNumber == "fifteen" => 15,
        string newNumber when newNumber == "sixteen" => 16,
        string newNumber when newNumber == "seventeen" => 17,
        string newNumber when newNumber == "eighteen" => 18,
        string newNumber when newNumber == "nineteen" => 19,
        string newNumber when newNumber == "twenty" => 20,
        string newNumber when newNumber == "thirty" => 30,
        string newNumber when newNumber == "forty" => 40,
        string newNumber when newNumber == "fifty" => 50,
        string newNumber when newNumber == "sixty" => 60,
        string newNumber when newNumber == "seventy" => 70,
        string newNumber when newNumber == "eighty" => 80,
        string newNumber when newNumber == "ninety" => 90
    };
}

static int CheckForTwoDigitUsualNumbers(string number)
{
    var result = 0;
    var tens = number.Split('-')[0];
    result += CheckForTwoDigitUnusualNumbers(tens);

    var ones = number.Split('-')[1];
    result += CheckForOneDigitNumbers(ones);

    return result;
}