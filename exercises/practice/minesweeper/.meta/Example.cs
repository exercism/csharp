using System;
using System.Collections.Generic;

public class Minesweeper
{
    public static string[] Annotate(string[] input)
    {
        var results = new List<string>();

        var board = input;

        for (int i = 0; i < board.Length; i++)
        {
            var result = string.Empty;

            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == '*')
                {
                    result += '*';
                }
                else
                {
                    var numMines = GetCountForSquare(board, i, j);
                    result += numMines == 0
                        ? " "
                        : numMines.ToString();
                }
            }

            results.Add(result);
        }

        return results.ToArray();
    }

    private static int GetCountForSquare(string[] board, int x, int y)
    {
        var result = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                try
                {
                    if (board[x + i][y + j] == '*')
                    {
                        result++;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
        }

        return result;
    }
}
