public static class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var spiral = new int[size, size];
        int numbersToPlace = size * size;

        int currentSpiralValue = 1;
        int firstPivot = 0, secondPivot = size - 1;

        while (currentSpiralValue <= numbersToPlace)
        {
            for (int i = firstPivot; i <= secondPivot; i++)
            {
                spiral[firstPivot, i] = currentSpiralValue++;
            }

            for (int j = firstPivot + 1; j <= secondPivot; j++)
            {
                spiral[j, secondPivot] = currentSpiralValue++;
            }

            for (int i = secondPivot - 1; i >= firstPivot; i--)
            {
                spiral[secondPivot, i] = currentSpiralValue++;
            }

            for (int j = secondPivot - 1; j >= firstPivot + 1; j--)
            {
                spiral[j, firstPivot] = currentSpiralValue++;
            }

            firstPivot++;
            secondPivot--;
        }

        return spiral;
    }
}

