// Lab3.cs in labs_lib
using System;

namespace labs_sources
{
    public static class Lab3
    {
        public static int FindMaxArea(List<int[]> rectangles, int n)
        {
            int maxArea = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue; // Skip the same rectangle

                    int minX = Math.Max(rectangles[i][0], rectangles[j][0]);
                    int minY = Math.Max(rectangles[i][1], rectangles[j][1]);
                    int maxX = Math.Min(rectangles[i][2], rectangles[j][2]);
                    int maxY = Math.Min(rectangles[i][3], rectangles[j][3]);

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
}