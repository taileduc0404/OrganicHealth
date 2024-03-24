using MediatR;

namespace Application.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
