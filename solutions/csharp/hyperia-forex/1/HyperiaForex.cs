using System;

public struct CurrencyAmount
{
    private readonly decimal amount;
    private readonly string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    private static void CheckCurrencies(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException("Currencies must be the same for this operation.");
        }
    }

    // Equality operators
    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        CheckCurrencies(a, b);
        return a.amount == b.amount;
    }

    public static bool operator !=(CurrencyAmount a, CurrencyAmount b)
    {
        CheckCurrencies(a, b);
        return a.amount != b.amount;
    }

    // Comparison operators
    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        CheckCurrencies(a, b);
        return a.amount > b.amount;
    }

    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        CheckCurrencies(a, b);
        return a.amount < b.amount;
    }

    // Arithmetic operators (CurrencyAmount to CurrencyAmount)
    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
    {
        CheckCurrencies(a, b);
        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
    {
        CheckCurrencies(a, b);
        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    // Arithmetic operators (CurrencyAmount to scalar)
    public static CurrencyAmount operator *(CurrencyAmount a, decimal multiplier)
    {
        return new CurrencyAmount(a.amount * multiplier, a.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount a, decimal divisor)
    {
        return new CurrencyAmount(a.amount / divisor, a.currency);
    }

    // Type conversion operators
    public static explicit operator double(CurrencyAmount ca)
    {
        return (double)ca.amount;
    }

    public static implicit operator decimal(CurrencyAmount ca)
    {
        return ca.amount;
    }
    

    public override bool Equals(object obj)
    {
        if (obj is CurrencyAmount other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(amount, currency);
    }
}
