public static class BinarySearch
{
    public static int Search(int[] input, int target)
    {
        if (input.Length == 0)
        {
            return -1;
        }
        
        return SearchHelper(input, target, 0, input.Length - 1);
    }

    public static int SearchHelper(int[] input, int target, int minIndex, int maxIndex)
    {
        var middleIndex = (minIndex + maxIndex) / 2;

        if (input[middleIndex] == target)
        {
            return middleIndex;
        }

        if (middleIndex <= 0 || middleIndex >= input.Length - 1)
        {
            return -1;
        }

        if (input[middleIndex] > target)
        {
            return SearchHelper(input, target, minIndex, middleIndex - 1);
        }

        return SearchHelper(input, target, middleIndex + 1, maxIndex);
    }
}