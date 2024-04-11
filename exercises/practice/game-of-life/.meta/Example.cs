using System;

public static class GameOfLife
{
    public static int[,] Tick(int[,] matrix)
    {
        var rowCount = matrix.GetLength(0);
        var columnCount = matrix.GetLength(1);
        var result = new int[rowCount, columnCount];
        for (var i = 0; i < rowCount; i++) {
            for (var j = 0; j < columnCount; j++) {
                var neighbors = 0;
                for (var k = -1; k <= 1; k++) {
                    for (var l = -1; l <= 1; l++) {
                        if (k == 0 && l == 0) continue;
                        if (i + k >= 0 && i + k < rowCount && j + l >= 0 && j + l < columnCount) {
                            neighbors += matrix[i + k, j + l];
                        }
                    }
                }
                if (matrix[i, j] == 1 && (neighbors == 2 || neighbors == 3)) {
                    result[i, j] = 1;
                } else if (matrix[i, j] == 0 && neighbors == 3) {
                    result[i, j] = 1;
                }
            }
        }
        return result;
    }
}
