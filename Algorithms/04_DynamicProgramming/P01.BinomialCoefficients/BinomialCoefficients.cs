
using System;

public class Program
{
    const int MAX = 100;
    static int[,] binomCoeff = new int[MAX, MAX];

    static void Main()
    {
        Console.Write("n = ");
        var n = int.Parse(Console.ReadLine());

        Console.Write("k = ");
        var k = int.Parse(Console.ReadLine());

        var coeff = FindBinomCoefficient(n, k);
        Console.WriteLine("C ({0} over {1}) = {2}", n, k, coeff);
    }

    private static int FindBinomCoefficient(int n, int k)
    {
        if (k > n)
        {
            return 0;
        }
        else if(k == n || k == 0)
        {
            return 1;
        }
        else if(binomCoeff[n, k] == 0)
        {
            binomCoeff[n, k] = FindBinomCoefficient(n - 1, k - 1) + FindBinomCoefficient(n - 1, k);
        }

        return binomCoeff[n, k];
    }
}
