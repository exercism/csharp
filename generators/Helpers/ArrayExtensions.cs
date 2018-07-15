using System.Linq;

namespace Exercism.CSharp.Helpers
{
    public static class ArrayExtensions
    {
        public static T[][] Rows<T>(this T[,] array)
        {
            return Enumerable.Range(0, array.GetLength(0))
                .Select(Row)
                .ToArray();
            
            T[] Row(int row) => Enumerable.Range(0, array.GetLength(1)).Select(col => array[row, col]).ToArray();
        }
    }
}