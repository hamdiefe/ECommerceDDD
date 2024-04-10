using ECommerceDDD.Domain.Abstractions;
using ECommerceDDD.Domain.Products;
using ECommerceDDD.Domain.Shared;

namespace ECommerceDDD.Domain.Categories
{
    public sealed class Category : Entity
    {
		private Category(Guid id) : base(id)
		{

		}
		public Category(Guid id ,Name name) : base(id)
        {
            Name = name;
        }

        public Name Name { get; private set; }

        public ICollection<Product> Products { get; private set; }

        public void ChangeName(string name)
        {
            Name = new Name(name);
        }
    }
}
