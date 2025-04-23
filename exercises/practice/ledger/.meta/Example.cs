using System.Globalization;

public record LedgerEntry(DateTime Date, string Description, decimal Change);

public static class Ledger
{
    private const int TruncateLength = 25;
    private const string TruncateSuffix = "...";

    public static LedgerEntry CreateEntry(string date, string description, int change) =>
        new(ParseDate(date), description, ParseChange(change));

    private static DateTime ParseDate(string date) => DateTime.Parse(date, System.Globalization.CultureInfo.InvariantCulture);

    private static decimal ParseChange(int change) => change / 100.0m;

    private static CultureInfo CultureInfo(string locale) =>
        locale switch
        {
            "en-US" => new CultureInfo("en-US", false),
            "nl-NL" => new CultureInfo("nl-NL", false),
            _ => throw new ArgumentException("Invalid locale")
        };

    private static string CurrencySymbol(string currency) =>
        currency switch
        {
            "USD" => "$",
            "EUR" => "€",
            _ => throw new ArgumentException("Invalid currency")
        };

    private static int CurrencyNegativePattern(string locale) =>
        locale switch
        {
            "en-US" => 0,
            "nl-NL" => 12,
            _ => throw new ArgumentException("Invalid locale")
        };

    private static string ShortDateFormat(string locale) =>
        locale switch
        {
            "en-US" => "MM/dd/yyyy",
            "nl-NL" => "dd/MM/yyyy",
            _ => throw new ArgumentException("Invalid locale")
        };

    private static CultureInfo getCulture(string currency, string locale)
    {
        var culture = CultureInfo(locale);
        culture.NumberFormat.CurrencySymbol = CurrencySymbol(currency);
        culture.NumberFormat.CurrencyNegativePattern = CurrencyNegativePattern(locale);
        culture.DateTimeFormat.ShortDatePattern = ShortDateFormat(locale);
        return culture;
    }

    private static string FormatHeader(CultureInfo culture) =>
        culture.Name switch
        {
            "en-US" => "Date       | Description               | Change       ",
            "nl-NL" => "Datum      | Omschrijving              | Verandering  ",
            _ => throw new ArgumentException("Invalid locale")
        };

    private static string FormatDate(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

    private static string FormatDescription(string description) =>
        description.Length <= TruncateLength ? description : description.Substring(0, TruncateLength - TruncateSuffix.Length) + TruncateSuffix;

    private static string FormatChange(IFormatProvider culture, decimal change)
    {
        var formatChange = change.ToString("C", culture);
        var suffix = change >= 0 || formatChange.Contains('-') ? " " : ""; 
        return $"{formatChange}{suffix}";
    }

    private static string FormatEntry(IFormatProvider culture, LedgerEntry entry) =>
        $"{FormatDate(culture, entry.Date)} | {FormatDescription(entry.Description),-25} | {FormatChange(culture, entry.Change),13}";

    private static IEnumerable<LedgerEntry> OrderEntries(LedgerEntry[] entries) =>
        entries
            .OrderBy(x => x.Date)
            .ThenBy(x => x.Description)
            .ThenBy(x => x.Change);

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var culture = getCulture(currency, locale);
        var header = FormatHeader(culture);
        var printedEntries = OrderEntries(entries).Select(entry => FormatEntry(culture, entry));
        var lines = new[] { header }.Concat(printedEntries);

        return string.Join("\n", lines);
    }
}
