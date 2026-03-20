public static class LineUp
{
    public static string Format(string name, int number) =>
        $"{name}, you are the {number}{Suffix(number)} customer we serve today. Thank you!";

    private static string Suffix(int number)
    {
        int lastTwoDigits = number % 100;
        int lastDigit = number % 10;

        if (lastTwoDigits >= 11 && lastTwoDigits <= 13)
        {
            return "th";
        }

        return lastDigit switch
        {
            1 => "st",
            2 => "nd",
            3 => "rd",
            _ => "th",
        };
    }
}
