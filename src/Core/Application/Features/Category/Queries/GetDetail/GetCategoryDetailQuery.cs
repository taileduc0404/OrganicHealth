using MediatR;

namespace Application.Features.Category.Queries.GetDetail
{
    //public class GetCategoryDetailQuery : IRequest<CategoryDetailDto>
    //{
    //}

    public record GetCategoryDetailQuery(int Id) : IRequest<CategoryDetailDto>;
}
