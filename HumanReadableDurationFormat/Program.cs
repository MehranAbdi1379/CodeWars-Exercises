// See https://aka.ms/new-console-template for more information



using System.Linq;

static string formatDuration(int inputSeconds)
{
    var result = "";
    var remainder = 0;
    var secondsOfAYear = 31536000;
    var secondsOfADay = 86400;
    var secondsOfAnHour = 3600;

    if (inputSeconds == 0)
    {
        return "Now";
    }
    if((inputSeconds / secondsOfAYear) >= 1)
    {
        var year = (int)inputSeconds / secondsOfAYear;
        inputSeconds = (int)inputSeconds % secondsOfAYear;
        if(year > 1)
        {
            result += $"{year} years, ";
        }
        else
        {
            result += $"{year} year, ";
        }
    }
    if((inputSeconds / secondsOfADay) >= 1)
    {
        var days = (int)inputSeconds / secondsOfADay;
        inputSeconds = (int)inputSeconds % secondsOfADay;
        if (days > 1)
        {
            result += $"{days} days, ";
        }
        else
        {
            result += $"{days} day, ";
        }
    }
    if((inputSeconds / secondsOfAnHour) >= 1)
    {
        var hours = (int)inputSeconds / secondsOfAnHour;
        inputSeconds = (int)inputSeconds % secondsOfAnHour;
        if (hours > 1)
        {
            result += $"{hours} hours, ";
        }
        else
        {
            result += $"{hours} hour, ";
        }
    }
    if ((inputSeconds / 60) >= 1)
    {
        var minutes = (int)inputSeconds / 60;
        inputSeconds = (int)inputSeconds % 60;
        if (minutes > 1)
        {
            result += $"{minutes} minutes, ";
        }
        else
        {
            result += $"{minutes} minute, ";
        }
    }
    if (inputSeconds > 0)
    {
        var seconds = inputSeconds;
        if (seconds > 1)
        {
            result += $"{seconds} seconds, ";
        }
        else
        {
            result += $"{seconds} second, ";
        }
    }

    var commaCountInReesult = result.Count(x => x.ToString() == ",");

    switch (commaCountInReesult)
    {
        case 1:
            result = result.Substring(0 , result.Length - 2); break;
        case >= 2:
            result = result.Substring(0, result.Length - 2);
            var firstPart = result.Substring(0, result.LastIndexOf(","));
            var secondPart = result.Substring(result.LastIndexOf(",") + 1);
            result = firstPart + " and"+secondPart;
            break;
        default: break;
    }
    return result ;
}