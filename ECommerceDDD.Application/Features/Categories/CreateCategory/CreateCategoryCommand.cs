using MediatR;

namespace ECommerceDDD.Application.Features.Categories.CreateCategory
{
    public sealed record CreateCategoryCommand(string name) : IRequest;
}
