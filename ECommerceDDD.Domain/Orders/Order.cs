using ECommerceDDD.Domain.Abstractions;
using ECommerceDDD.Domain.Shared;

namespace ECommerceDDD.Domain.Orders
{
    public sealed class Order : Entity
    {
		private Order(Guid id) : base(id)
		{

		}
		public Order(Guid id, string orderNumber, DateTime createdOn, OrderStatusEnum status) : base(id)
        {
            OrderNumber = orderNumber;
            CreatedOn = createdOn;
            Status = status;
        }

        public string OrderNumber { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public OrderStatusEnum Status { get; private set; }
        public ICollection<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();

        public void CreateOrder(List<CreateOrderDto> createOrderDtos)
        {
            createOrderDtos.ForEach(x =>
            {
                if (x.Quantity < 1)
                {
                    throw new ArgumentException("Order quantity must not be smaller than 1");
                }


                OrderLines.Add(new OrderLine(new Guid(),
                                             Id,
                                             x.ProductId,
                                             x.Quantity,
                                             new Money(x.Amount, Currency.FromCode(x.CurrencyCode))));

            });
        }


        public void RemoveOrderLine(Guid orderLineId)
        {
            var orderLine = OrderLines.FirstOrDefault(x => x.Id == orderLineId);

            if (orderLine is null)
            {
                throw new ArgumentException("Order line not found");
            }

            OrderLines.Remove(orderLine);
        }
    }
}
