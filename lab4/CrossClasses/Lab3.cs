using System;
using System.IO;
using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLines = File.ReadAllLines("INPUT.TXT");
            int n = int.Parse(inputLines[0]);

            int[,] rectangles = new int[n, 4];
            for (int i = 0; i < n; i++)
            {
                string[] coordinates = inputLines[i + 1].Split(' ');
                for (int j = 0; j < 4; j++)
                {
                    rectangles[i, j] = int.Parse(coordinates[j]);
                }
            }

            int maxArea = FindMaxArea(rectangles, n);

            File.WriteAllText("OUTPUT.TXT", maxArea.ToString());
        }

        static int FindMaxArea(int[,] rectangles, int n)
        {
            int maxArea = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue; // Skip the same rectangle

                    int minX = Math.Max(rectangles[i, 0], rectangles[j, 0]);
                    int minY = Math.Max(rectangles[i, 1], rectangles[j, 1]);
                    int maxX = Math.Min(rectangles[i, 2], rectangles[j, 2]);
                    int maxY = Math.Min(rectangles[i, 3], rectangles[j, 3]);

                    if (minX < maxX && minY < maxY)
                    {
                        int area = (maxX - minX) * (maxY - minY);
                        maxArea = Math.Max(maxArea, area);
                    }
                }
            }

            return maxArea;
        }
    }

