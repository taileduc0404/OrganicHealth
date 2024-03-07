using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
