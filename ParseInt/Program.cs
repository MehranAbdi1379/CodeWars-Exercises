// See https://aka.ms/new-console-template for more information


using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine(ParseInt("five million"));

static int ParseInt(string s)
{
    s = s.Replace(" and ", " ");

    var words = s.Split(' ');

    switch (words.Length)
    {
        case 1:
            return CheckForOneWord(words[0]);
        case 2:
            return CheckForTwoWords(words);
        default:
            return CheckForMoreThanTwoWords(words);
    }
}

static int CheckForOneWord(string s)
{
    if (CheckForOneDigitNumbers(s) != -1)
        return CheckForOneDigitNumbers(s);
    else if (CheckForTwoDigitUnusualNumbers(s) != -1)
        return CheckForTwoDigitUnusualNumbers(s);
    else return CheckForTwoDigitUsualNumbers(s);
}

static int CheckForMoreThanTwoWords(string[] words)
{
    var wordsList = words.ToList();
    var result = 0;
    if (words.Contains("thousand"))
    {
        var beforeThousand = new List<string>();
        var afterThousands = new List<string>();

        SplitListToBeforeThousandAndAfter(words, beforeThousand, afterThousands);

        if (beforeThousand.Count == 1)
            result += CheckForOneWord(beforeThousand[0]) * 1000;
        else if (beforeThousand.Count == 2)
            result += CheckForOneDigitNumbers(beforeThousand[0]) * 100000;
        else if (beforeThousand.Count == 3)
            result += (CheckForOneDigitNumbers(beforeThousand[0]) * 100000) + (CheckForOneWord(words[2]) * 1000);

        if (afterThousands.Count == 1)
            result += CheckForOneWord(afterThousands[0]);
        else if (afterThousands.Count == 2)
            result += CheckForOneDigitNumbers(afterThousands[0]) * 100;
        else if (afterThousands.Count == 3)
            result += (CheckForOneDigitNumbers(afterThousands[0]) * 100) + CheckForOneWord(afterThousands[2]);
    }
    else
    {
        result += (CheckForOneDigitNumbers(words[0]) * 100) + CheckForOneWord(words[2]);
    }
    return result;
}

static void SplitListToBeforeThousandAndAfter(string[] words , List<string> beforeThousand , List<string> afterThousand)
{
    var foundSplitElement = false;

    foreach (string item in words)
    {
        if (item == "thousand")
        {
            foundSplitElement = true;
            continue;
        }
        if (!foundSplitElement)
        {
            beforeThousand.Add(item);
        }
        else
        {
            afterThousand.Add(item);
        }
    }
}

static int CheckForOneDigitNumbers(string number)
{
    return number switch
    {
        string newNumber when newNumber == "zero" => 0,
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
        string newNumber when newNumber == "ninety" => 90,
        _ => -1
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

static int CheckForTwoWords(string[] words)
{
    var multiplier = words switch
    {
        string[] tempWords when tempWords[1] == "hundred" => 100,
        string[] tempWords when tempWords[1] == "thousand" => 1000,
        string[] tempWords when tempWords[1] == "million" => 1000000,
        _ => -1
    };
    return CheckForOneWord(words[0]) * multiplier;
}