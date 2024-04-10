namespace ECommerceDDD.Domain.Shared
{
    public sealed record Name
    {
        public Name(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name must not be null");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("Name length must be bigger than 3");
            }
            Value = value;
        }
        public string Value { get; init; }
    }
}
