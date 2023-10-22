using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Read input from the file
        string[] input = File.ReadAllText("INPUT.TXT").Trim().Split(' ');
        int K = int.Parse(input[0]);
        int P = int.Parse(input[1]);

        // Calculate the result using the given formula
        long result = CalculateEnts(K, P);

        // Write output to the file
        File.WriteAllText("OUTPUT.TXT", result.ToString());
    }

    static long CalculateEnts(int K, int P)
    {
        if (K == 1) return 1 % P;
        long[] dp = new long[K + 1];
        dp[1] = 1;
        long total = 1;
        for (int i = 2; i <= K; i++)
        {
            if (i % 2 == 0)
            {
                dp[i] = (dp[i / 2] + dp[i - 1]) % P;
            }
            else
            {
                dp[i] = (dp[i - 1]) % P;
            }
            total += dp[i];
        }
        return total % P;
    }
}
