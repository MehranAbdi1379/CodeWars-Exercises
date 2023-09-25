// See https://aka.ms/new-console-template for more information


using System.Numerics;

Console.WriteLine(GetLastDigit(BigInteger.Parse("3715290469715693021198967285016729344580685479654510946723"), BigInteger.Parse("68819615221552997273737174557165657483427362207517952651")));

static int GetLastDigit(BigInteger n1, BigInteger n2)
{
    if (n2 == 0) return 1;
    else if (n1 == 0) return 0;
    
	switch (n1.ToString()[n1.ToString().Length-1]){
		case '0':
			return 0;
        case '1':
            return 1;
        case '2':
            switch ((int)BigInteger.Remainder(n2, 4))
            {
                case 0:
                    return 6;
                case 1:
                    return 2;
                case 2:
                    return 4;
                default:
                    return 8;
            }
        case '3':
            switch ((int)BigInteger.Remainder(n2, 4))
            {
                case 0:
                    return 1;
                case 1:
                    return 3;
                case 2:
                    return 9;
                default:
                    return 7;
            }
        case '4':
            switch ((int)BigInteger.Remainder(n2, 2))
            {
                case 0:
                    return 6;
                default:
                    return 4;
            }
        case '5':
            return 5;
        case '6':
            return 6;
        case '7':
            switch ((int)BigInteger.Remainder(n2, 4))
            {
                case 0:
                    return 1;
                case 1:
                    return 7;
                case 2:
                    return 9;
                default:
                    return 3;
            }
        case '8':
            switch ((int)BigInteger.Remainder(n2, 4))
            {
                case 0:
                    return 6;
                case 1:
                    return 8;
                case 2:
                    return 4;
                default:
                    return 2;
            }
        case '9':
            switch ((int)BigInteger.Remainder(n2, 2))
            {
                case 0:
                    return 1;
                default:
                    return 9;
            }
        default: 
            return -1;
    }
}
