// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

Console.WriteLine("Hello, World!");


static int CountSheeps(bool[] sheeps)
{
    return sheeps.Where(s => s == true).Count();
}