using MediatR;

namespace Application.Features.Category.Queries.GetAll
{
    public record GetAllCategoryQuery : IRequest<List<CategoryDto>>;
}
