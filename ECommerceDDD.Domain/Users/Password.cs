namespace ECommerceDDD.Domain.Users
{
    public sealed record Password
    {
        public Password(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Password must not be null");
            }

            if (value.Length < 6)
            {
                throw new ArgumentException("Password length must be bigger than 6");
            }

            Value = value;
        }

        public string Value { get; init; }
    }
}
