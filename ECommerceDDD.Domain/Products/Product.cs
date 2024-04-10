using ECommerceDDD.Domain.Abstractions;
using ECommerceDDD.Domain.Categories;
using ECommerceDDD.Domain.Shared;

namespace ECommerceDDD.Domain.Products
{
    public sealed class Product : Entity
    {
        private Product(Guid id) : base(id)
        {
            
        }

        public Product(Guid id, Name name, int quantity, Money price, Guid categoryId) : base(id)
		{
			Name = name;
            Quantity = quantity;
            Price = price;
            CategoryId = categoryId;
        }

        public Name Name { get; private set; }
        public int Quantity { get; private set; }
        public Money Price { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        public void Update(string name, decimal amount, string currecnyCode, Guid categoryId, int quantity)
        {
            Name = new Name(name);
            Price = new Money(amount, Currency.FromCode(currecnyCode));
            CategoryId = categoryId;
            Quantity = quantity;
        }
    }
}
