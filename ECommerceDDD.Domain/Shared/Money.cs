using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDDD.Domain.Shared
{
    public sealed record Money(decimal Amount, Currency Currency)
    {
        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Currencies with different values cannot be added together.");
            }

            return new(a.Amount + b.Amount,a.Currency);
        }

        public static Money Zero() => new(0, Currency.None);
        public static Money Zero(Currency currency) => new (0,currency);

        public bool IsZero() => this == Zero(Currency);
    }
}
