using System;
using System.Runtime.InteropServices;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount @this, CurrencyAmount other)
    {
        if (@this.currency != other.currency)
        {
            throw new ArgumentException();
        }

        return @this.amount == other.amount;
    }

    public static bool operator !=(CurrencyAmount @this, CurrencyAmount other)
    {
        return @this != other;
    }

    public static bool operator >(CurrencyAmount @this, CurrencyAmount other)
    {
        if (@this.currency != other.currency)
        {
            throw new ArgumentException();
        }

        return @this.amount > other.amount;
    }

    public static bool operator <(CurrencyAmount @this, CurrencyAmount other)
    {
        if (@this.currency != other.currency)
        {
            throw new ArgumentException();
        }

        return @this.amount < other.amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount @this, CurrencyAmount other)
    {
        if (@this.currency != other.currency)
        {
            throw new ArgumentException();
        }

        return new CurrencyAmount(@this.amount + other.amount, @this.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount @this, CurrencyAmount other)
    {
        if (@this.currency != other.currency)
        {
            throw new ArgumentException();
        }

        return new CurrencyAmount(@this.amount - other.amount, @this.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount @this, decimal multiplier)
    {
        return new CurrencyAmount(@this.amount * multiplier, @this.currency);
    }

    public static CurrencyAmount operator *(decimal multiplier, CurrencyAmount @this)
    {
        return new CurrencyAmount(@this.amount * multiplier, @this.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount @this, decimal divisor)
    {
        return new CurrencyAmount(@this.amount / divisor, @this.currency);
    }

    public static CurrencyAmount operator /(decimal divisor, CurrencyAmount @this)
    {
        return new CurrencyAmount(@this.amount / divisor, @this.currency);
    }

    public static explicit operator double (CurrencyAmount @this)
    {
        return (double) @this.amount;
    }

    public static implicit operator decimal (CurrencyAmount @this)
    {
        return @this.amount;
    }
}
