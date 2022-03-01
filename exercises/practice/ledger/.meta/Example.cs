using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string description, decimal change)
    {
        Date = date;
        Description = description;
        Change = change;
    }

    public DateTime Date { get; }
    public string Description { get; }
    public decimal Change { get; }
}

public static class Ledger
{
    private const int TruncateLength = 25;
    private const string TruncateSuffix = "...";

    public static LedgerEntry CreateEntry(string date, string description, int change) =>
        new LedgerEntry(ParseDate(date), description, ParseChange(change));

    private static DateTime ParseDate(string date) => DateTime.Parse(date, System.Globalization.CultureInfo.InvariantCulture);

    private static decimal ParseChange(int change) => change / 100.0m;

    private static CultureInfo CultureInfo(string locale)
    {
        switch (locale)
        {
            case "en-US": return new CultureInfo("en-US");
            case "nl-NL": return new CultureInfo("nl-NL");
            default: throw new ArgumentException("Invalid locale");
        }
    }

    private static string CurrencySymbol(string currency)
    {
        switch (currency)
        {
            case "USD": return "$";
            case "EUR": return "€";
            default: throw new ArgumentException("Invalid currency");
        }
    }

    private static int CurrencyNegativePattern(string locale)
    {
        switch (locale)
        {
            case "en-US": return 0;
            case "nl-NL": return 12;
            default: throw new ArgumentException("Invalid locale");
        }
    }

    private static string ShortDateFormat(string locale)
    {
        switch (locale)
        {
            case "en-US": return "MM/dd/yyyy";
            case "nl-NL": return "dd/MM/yyyy";
            default: throw new ArgumentException("Invalid locale");
        }
    }

    private static CultureInfo getCulture(string currency, string locale)
    {
        var culture = CultureInfo(locale);
        culture.NumberFormat.CurrencySymbol = CurrencySymbol(currency);
        culture.NumberFormat.CurrencyNegativePattern = CurrencyNegativePattern(locale);
        culture.DateTimeFormat.ShortDatePattern = ShortDateFormat(locale);
        return culture;
    }

    private static string FormatHeader(CultureInfo culture)
    {
        switch (culture.Name)
        {
            case "en-US": return "Date       | Description               | Change       ";
            case "nl-NL": return "Datum      | Omschrijving              | Verandering  ";
            default: throw new ArgumentException("Invalid locale");
        }
    }

    private static string FormatDate(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

    private static string FormatDescription(string description) =>
        description.Length <= TruncateLength ? description : description.Substring(0, TruncateLength - TruncateSuffix.Length) + TruncateSuffix;

    private static string FormatChange(IFormatProvider culture, decimal change) =>
        change < 0.0m ? change.ToString("C", culture) : change.ToString("C", culture) + " ";

    private static string FormatEntry(IFormatProvider culture, LedgerEntry entry) =>
        string.Format("{0} | {1,-25} | {2,13}", FormatDate(culture, entry.Date), FormatDescription(entry.Description), FormatChange(culture, entry.Change));

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
