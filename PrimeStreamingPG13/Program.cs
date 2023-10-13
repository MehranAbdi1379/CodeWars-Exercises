// See https://aka.ms/new-console-template for more information

int limit = 854858642; // Approximate value for the 1 millionth prime
bool[] isPrime = new bool[limit + 1];

for (int i = 2; i <= limit; i++)
{
    isPrime[i] = true;
}

List<int> PrimeNumbers = new List<int>();

for (int p = 2; p * p <= limit; p++)
{
    if (isPrime[p])
    {
        for (int i = p * p; i <= limit; i += p)
        {
            isPrime[i] = false;
        }
    }
}

for (int i = 2; i <= limit; i++)
{
    if (isPrime[i])
    {
        PrimeNumbers.Add(i);
    }

    if (PrimeNumbers.Count == 50000000)
    {
        break;
    }
}

foreach (var item in PrimeNumbers.GetRange(0 , 200))
{
    Console.WriteLine(item);
}