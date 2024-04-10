using ECommerceDDD.Domain.Products;
using MediatR;

namespace ECommerceDDD.Application.Features.Products.GetAllProduct
{
    public sealed record class GetAllProductQuery() : IRequest<List<Product>>;

}
