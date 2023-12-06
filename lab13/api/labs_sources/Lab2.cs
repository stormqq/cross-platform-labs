// Lab2.cs in labs_lib
using System;

namespace labs_sources
{
    public static class Lab2
    {
        public static long CalculateEnts(int K, int P)
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
}