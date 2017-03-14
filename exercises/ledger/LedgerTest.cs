using Xunit;

public class LedgerTest
{
    [Fact]
    public void Empty_ledger()
    {
        var currency = "USD";
        var locale = "en-US";
        var entries = new LedgerEntry[0];
        var expected =
            "Date       | Description               | Change       ";

        Assert.Equal(expected, Ledger.Format(currency, locale, entries));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_entry()
    {
        var currency = "USD";
        var locale = "en-US";
        var entries = new[] 
        {
            Ledger.CreateEntry("2015-01-01", "Buy present", -1000)
        };
        var expected =
            "Date       | Description               | Change       \n" +
            "01/01/2015 | Buy present               |      ($10.00)";

        Assert.Equal(expected, Ledger.Format(currency, locale, entries));
    }

    [Fact(Skip = "Remove to run test")]
    public void Credit_and_debit()
    {
        var currency = "USD";
        var locale = "en-US";
        var entries = new[] 
        {
            Ledger.CreateEntry("2015-01-02", "Get present", 1000),
            Ledger.CreateEntry("2015-01-01", "Buy present", -1000)
        };
        var expected =
            "Date       | Description               | Change       \n" +
            "01/01/2015 | Buy present               |      ($10.00)\n" +
            "01/02/2015 | Get present               |       $10.00 ";

        Assert.Equal(expected, Ledger.Format(currency, locale, entries));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_entries_on_same_date_ordered_by_description()
    {
        var currency = "USD";
        var locale = "en-US";
        var entries = new[] 
        {
            Ledger.CreateEntry("2015-01-01", "Buy present", -1000),
            Ledger.CreateEntry("2015-01-01", "Get present", 1000)
        };
        var expected =
            "Date       | Description               | Change       \n" +
            "01/01/2015 | Buy present               |      ($10.00)\n" +
            "01/01/2015 | Get present               |       $10.00 ";

        Assert.Equal(expected, Ledger.Format(currency, locale, entries));
    }

    [Fact(Skip = "Remove to run test")]
    public void Final_order_tie_breaker_is_change()
    {
        var currency = "USD";
        var locale = "en-US";
        var entries = new[] 
        {
            Ledger.CreateEntry("2015-01-01", "Something", 0),
            Ledger.CreateEntry("2015-01-01", "Something", -1),
            Ledger.CreateEntry("2015-01-01", "Something", 1)
        };
        var expected =
            "Date       | Description               | Change       \n" +
            "01/01/2015 | Something                 |       ($0.01)\n" +
            "01/01/2015 | Something                 |        $0.00 \n" +
            "01/01/2015 | Something                 |        $0.01 ";

        Assert.Equal(expected, Ledger.Format(currency, locale, entries));
    }

    [Fact(Skip = "Remove to run test")]
    public void Overlong_descriptions()
    {
        var currency = "USD";
        var locale = "en-US";
        var entries = new[] 
        {
            Ledger.CreateEntry("2015-01-01", "Freude schoner Gotterfunken", -123456)
        };
        var expected =
            "Date       | Description               | Change       \n" +
            "01/01/2015 | Freude schoner Gotterf... |   ($1,234.56)";

        Assert.Equal(expected, Ledger.Format(currency, locale, entries));
    }

    [Fact(Skip = "Remove to run test")]
    public void Euros()
    {
        var currency = "EUR";
        var locale = "en-US";
        var entries = new[] 
        {
            Ledger.CreateEntry("2015-01-01", "Buy present", -1000)
        };
        var expected =
            "Date       | Description               | Change       \n" +
            "01/01/2015 | Buy present               |      (€10.00)";

        Assert.Equal(expected, Ledger.Format(currency, locale, entries));
    }

    [Fact(Skip = "Remove to run test")]
    public void Dutch_locale()
    {
        var currency = "USD";
        var locale = "nl-NL";
        var entries = new[] 
        {
            Ledger.CreateEntry("2015-03-12", "Buy present", 123456)
        };
        var expected =
            "Datum      | Omschrijving              | Verandering  \n" +
            "12-03-2015 | Buy present               |   $ 1.234,56 ";

        Assert.Equal(expected, Ledger.Format(currency, locale, entries));
    }

    [Fact(Skip = "Remove to run test")]
    public void Dutch_negative_number_with_3_digits_before_decimal_point()
    {
        var currency = "USD";
        var locale = "nl-NL";
        var entries = new[] 
        {
            Ledger.CreateEntry("2015-03-12", "Buy present", -12345)
        };
        var expected =
            "Datum      | Omschrijving              | Verandering  \n" +
            "12-03-2015 | Buy present               |     $ -123,45";

        Assert.Equal(expected, Ledger.Format(currency, locale, entries));
    }

    [Fact(Skip = "Remove to run test")]
    public void American_negative_number_with_3_digits_before_decimal_point()
    {
        var currency = "USD";
        var locale = "en-US";
        var entries =   new[] 
        {
            Ledger.CreateEntry("2015-03-12", "Buy present", -12345)
        };
        var expected =
            "Date       | Description               | Change       \n" +
            "03/12/2015 | Buy present               |     ($123.45)";

        Assert.Equal(expected, Ledger.Format(currency, locale, entries));
    }
}