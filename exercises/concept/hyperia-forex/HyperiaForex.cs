using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // TODO: implement equality operators

    public static bool operator ==(CurrencyAmount @this, CurrencyAmount other)
    {
        throw new NotImplementedException("Please implement the == operator.");
    }

    public static bool operator !=(CurrencyAmount @this, CurrencyAmount other)
    {
        throw new NotImplementedException("Please implement the != operator.");
    }

    // TODO: implement comparison operators

    public static bool operator >(CurrencyAmount @this, CurrencyAmount other)
    {
        throw new NotImplementedException("Please implement the > operator.");
    }

    public static bool operator <(CurrencyAmount @this, CurrencyAmount other)
    {
        throw new NotImplementedException("Please implement the <!=> operator.");
    }

    // TODO: implement arithmetic operators

    public static CurrencyAmount operator +(CurrencyAmount @this, CurrencyAmount other)
    {
        throw new NotImplementedException("Please implement the + operator.");
    }

    public static CurrencyAmount operator -(CurrencyAmount @this, CurrencyAmount other)
    {
        throw new NotImplementedException("Please implement the - operator.");
    }

    public static CurrencyAmount operator *(CurrencyAmount @this, decimal multiplier)
    {
        throw new NotImplementedException("Please implement the * operator.");
    }

    public static CurrencyAmount operator *(decimal multiplier, CurrencyAmount @this)
    {
        throw new NotImplementedException("Please implement the * operator.");
    }

    public static CurrencyAmount operator /(CurrencyAmount @this, decimal divisor)
    {
        throw new NotImplementedException("Please implement the / operator.");
    }

    // TODO: implement type conversion operators

    public static explicit operator double(CurrencyAmount @this)
    {
        throw new NotImplementedException("Please implement the cast to double operator.");
    }

    public static implicit operator decimal(CurrencyAmount @this)
    {
        throw new NotImplementedException("Please implement the cast to decimal operator.");
    }
}
