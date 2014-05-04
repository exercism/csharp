using System.Text.RegularExpressions;

public class PhoneNumber
{
    private static readonly Regex DigitsOnly = new Regex(@"[^\d]");

    public string Number { get; private set; }
    public string AreaCode { get; private set; }

    public PhoneNumber(string phoneNumber)
    {
        Number = GetValidatedPhoneNumber(phoneNumber);
        AreaCode = Number.Substring(0, 3);
    }

    private static string GetValidatedPhoneNumber(string phoneNumber)
    {
        var stripped = StripOutNonNumerics(phoneNumber);

        if (IsInvalidPhoneNumber(stripped))
            return GetInvalidPhoneNumberReplacement(stripped);

        return stripped;
    }

    private static string StripOutNonNumerics(string value)
    {
        return DigitsOnly.Replace(value, "");
    }

    private static bool IsInvalidPhoneNumber(string phoneNumber)
    {
        return phoneNumber.Length != 10;
    }

    private static string GetInvalidPhoneNumberReplacement(string phoneNumber)
    {
        return IsPhoneNumberWithUSAreaCode(phoneNumber) ? phoneNumber.Substring(1) : "0000000000";
    }

    private static bool IsPhoneNumberWithUSAreaCode(string value)
    {
        return value.Length == 11 && value.StartsWith("1");
    }

    public override string ToString()
    {
        return string.Format("({0}) {1}-{2}", AreaCode, Number.Substring(3, 3), Number.Substring(6));
    }
}