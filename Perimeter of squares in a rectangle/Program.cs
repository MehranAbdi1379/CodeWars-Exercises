// See https://aka.ms/new-console-template for more information
using System;
using System.Numerics;

Console.WriteLine(perimeter(new BigInteger(8)));

static BigInteger perimeter(BigInteger n)
{
    BigInteger finalResult = 0;
    BigInteger num1 = 0;
    BigInteger num2 = 0;
    for (int i = 1; i < n+1; i++)
    {
        BigInteger temp = 0;
        if (i == 1)
        {
            num1 = 1;
            finalResult += 1;
        }
        else if (i == 2)
        {
            num2 = 1;
            finalResult += 1;
        }
        else
        {
            temp = num1 + num2;
            num1 = num2;
            num2 = temp;
            finalResult += temp;
        }
    }
    return finalResult * 4;
}