using System;

namespace labs_sources
{
    public static class Lab1
    {
        public static int CalculateCyclicDistance(string SA, string SB)
        {
            int length = SA.Length;
            int result = 0;

            for (int i = 0; i < length; i++)
            {
                result += CalculateDistance(SA[i], SB[i]);
            }

            return result;
        }

        private static int CalculateDistance(char a, char b)
        {
            int distance = Math.Abs((int)a - (int)b);
            if (distance > 13)
            {
                distance = 26 - distance;
            }
            return distance;
        }
    }
}