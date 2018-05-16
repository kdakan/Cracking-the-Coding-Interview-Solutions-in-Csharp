using System;

namespace AlgorithmPractice
{
    public class Paint
    {
        public static void BrushFill(int x, int y, bool[][] screenPixels, int xScreenSize, int yScreenSize)
        {
            if (x < 0 || x >= xScreenSize || y < 0 || y >= yScreenSize || screenPixels[y][x])
                return;

            screenPixels[y][x] = true;

            BrushFill(x - 1, y, screenPixels, xScreenSize, yScreenSize);
            BrushFill(x + 1, y, screenPixels, xScreenSize, yScreenSize);
            BrushFill(x, y - 1, screenPixels, xScreenSize, yScreenSize);
            BrushFill(x, y + 1, screenPixels, xScreenSize, yScreenSize);

        }
    }
}