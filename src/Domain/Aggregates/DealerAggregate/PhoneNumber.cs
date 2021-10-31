using System;
using Ardalis.GuardClauses;
using SharedKernel;
using System.Text.RegularExpressions;

namespace Domain.Aggregates.DealerAggregate
{
    public class PhoneNumber : ValueObject
    {
        private const string PhoneNumberRegularExpression = @"\+[0-9]*";

        public PhoneNumber(string number)
        {
            Guard.Against.StringLength(number, nameof(number), 5, 20);

            if (!Regex.IsMatch(number, PhoneNumberRegularExpression))
            {
                throw new ArgumentException("Phone number must start with a '+' and contain only digits afterwards.");
            }

            Number = number;
        }

        public string Number { get; }

        public static implicit operator string(PhoneNumber number) => number.Number;

        public static implicit operator PhoneNumber(string number) => new PhoneNumber(number);
    }
}
