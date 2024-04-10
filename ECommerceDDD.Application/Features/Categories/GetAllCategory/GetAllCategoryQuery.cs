using ECommerceDDD.Domain.Categories;
using MediatR;

namespace ECommerceDDD.Application.Features.Categories.GetAllCategory
{
    public sealed record class GetAllCategoryQuery() : IRequest<List<Category>>;
}
