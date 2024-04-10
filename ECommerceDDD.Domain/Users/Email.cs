namespace ECommerceDDD.Domain.Users
{
    public sealed record Email
    {
        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Email must not be null");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("Email length must be bigger than 3");
            }

            if (!value.Contains("@"))
            {
                throw new ArgumentException("Email is not valid");
            }

            Value = value;
        }

        public string Value { get; init; }
    }
}
