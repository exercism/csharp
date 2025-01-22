public static class SquareRoot
{
    public static int Root(int number)
    {
        var i = 1;
        var result = 1;

        while (result <= number)
        {
            i++;
            result = i * i;
        }

        return i - 1;
    }
}