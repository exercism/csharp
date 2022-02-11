public static class BinarySearch
{
    public static int Find(int[] input, int target)
    {
        if (input.Length == 0)
            return -1;
        
        return FindHelper(input, target, 0, input.Length - 1);
    }

    private static int FindHelper(int[] input, int target, int minIndex, int maxIndex)
    {
        var middleIndex = (minIndex + maxIndex) / 2;

        if (input[middleIndex] == target)
            return middleIndex;

        if (middleIndex <= 0 || middleIndex >= input.Length - 1 || minIndex == maxIndex)
            return -1;

        if (input[middleIndex] > target)
            return FindHelper(input, target, minIndex, middleIndex - 1);

        return FindHelper(input, target, middleIndex + 1, maxIndex);
    }
}