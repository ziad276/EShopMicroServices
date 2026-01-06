namespace Ordering.Domain.ValueObject
{
    public record OrderName
    {
        private const int DefultLength = 5;
        public string Value { get; }
        private OrderName(string value) => Value = value;
        public static OrderName Of(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            //ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefultLength);

            return new OrderName(value);
        }
    }
}
