public class BinarySearch
{
    private readonly int[] _input;

    public BinarySearch(int[] input) => _input = input;

    public int Find(int target)
    {
        if (_input.Length == 0)
            return -1;
        
        return FindHelper(target, 0, _input.Length - 1);
    }

    private int FindHelper(int target, int minIndex, int maxIndex)
    {
        var middleIndex = (minIndex + maxIndex) / 2;

        if (_input[middleIndex] == target)
            return middleIndex;

        if (middleIndex <= 0 || middleIndex >= _input.Length - 1 || minIndex == maxIndex)
            return -1;

        if (_input[middleIndex] > target)
            return FindHelper(target, minIndex, middleIndex - 1);

        return FindHelper(target, middleIndex + 1, maxIndex);
    }
}