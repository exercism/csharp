public static class EliudsEggs
{
    public static int EggCount(int encodedCount)
    {
        var count = 0;
        
        while (encodedCount > 0)
        {
            count += encodedCount & 1;
            encodedCount >>= 1;
        }

        return count;
    }
}
