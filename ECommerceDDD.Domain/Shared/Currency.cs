namespace ECommerceDDD.Domain.Shared
{
    public sealed record Currency
    {
        private Currency(string code)
        {
            Code = code;
        }
        
        internal static readonly Currency None = new ("");
        public static readonly Currency USD = new("USD");
        public static readonly Currency TRY = new("TRY");

        public string Code { get; init; }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Code == code) ?? 
                throw new ArgumentException ("Code is not valid");
        }

        public static readonly IReadOnlyCollection<Currency> All = new[] { USD, TRY };
    }
}
