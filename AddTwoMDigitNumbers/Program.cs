// See https://aka.ms/new-console-template for more information

int carry = 0;
string number1 = "235", number2 = "826";
string sum = "" , sumReversed = "";
int NumberLength = number1.ToString().Length;
bool hasCarry = false;

for (int i = NumberLength-1; i >= 0; i--)
{
    carry = int.Parse(number1[i].ToString()) + int.Parse(number2[i].ToString()) ;
    if (hasCarry)
        carry++;
    if(carry > 9)
    {
        carry = carry - 10;
        hasCarry = true;
    }
    else
        hasCarry = false;
    if (i == 0 && hasCarry)
        sum += $"{carry}1";
    else 
        sum += carry;
}

for (int i = sum.Length-1; i >=0; i--)
{
    sumReversed += sum[i];
}

Console.WriteLine(sumReversed);
