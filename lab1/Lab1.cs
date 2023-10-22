using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFilePath = "INPUT.TXT";
        string outputFilePath = "OUTPUT.TXT";

        string[] inputLines = File.ReadAllLines(inputFilePath);
        string SA = inputLines[0];
        string SB = inputLines[1];

        int result = CalculateCyclicDistance(SA, SB);

        File.WriteAllText(outputFilePath, result.ToString());
    }

    static int CalculateCyclicDistance(string SA, string SB)
    {
        int length = SA.Length;
        int result = 0;

        for (int i = 0; i < length; i++)
        {
            result += CalculateDistance(SA[i], SB[i]);
        }

        return result;
    }

    static int CalculateDistance(char a, char b)
    {
        int distance = Math.Abs((int)a - (int)b);
        if (distance > 13)
        {
            distance = 26 - distance;
        }
        return distance;
    }
}