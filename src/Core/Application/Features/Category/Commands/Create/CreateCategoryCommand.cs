
using MediatR;

namespace Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string? Name { get; set; }
    }
}
