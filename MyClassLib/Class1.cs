﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib
{
    public class ArrayClass
    {
        private int[] array;

        public ArrayClass(int[] array)
        {
            this.array = array;
        }

        public static bool operator <(ArrayClass array1, ArrayClass array2)
        {
            return array1.array.Sum() < array2.array.Sum();
        }

        public static bool operator >(ArrayClass array1, ArrayClass array2)
        {
            return array1.array.Sum() > array2.array.Sum();
        }
    }
    public class Money
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money money1, Money money2)
        {
            if (money1.Currency != money2.Currency)
            {
                decimal convertedAmount = CurrencyConverter.Convert(money2.Amount, money2.Currency, money1.Currency);
                return new Money(money1.Amount + convertedAmount, money1.Currency);
            }
            return new Money(money1.Amount + money2.Amount, money1.Currency);
        }

        public static bool operator ==(Money money1, Money money2)
        {
            if (money1.Currency != money2.Currency)
            {
                decimal convertedAmount = CurrencyConverter.Convert(money2.Amount, money2.Currency, money1.Currency);
                return money1.Amount == convertedAmount;
            }
            return money1.Amount == money2.Amount;
        }

        public static bool operator !=(Money money1, Money money2)
        {
            return !(money1 == money2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Money money = (Money)obj;
            return Amount == money.Amount && Currency == money.Currency;
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode() ^ Currency.GetHashCode();
        }
    }

    public static class CurrencyConverter
    {
        public static decimal Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            decimal conversionRate ;
            if (fromCurrency == "USD" && toCurrency == "KZT")
                {
                conversionRate = 450m;
                return amount * conversionRate;
                }
            else if (fromCurrency == "RUB" && toCurrency == "KZT")
            {
                conversionRate = 5m;
                return amount * conversionRate;
            }
            else if (fromCurrency == "EUR" && toCurrency == "KZT")
            {
                conversionRate = 490m;
                return amount * conversionRate;
            }
            return amount;
        }
    }
}
