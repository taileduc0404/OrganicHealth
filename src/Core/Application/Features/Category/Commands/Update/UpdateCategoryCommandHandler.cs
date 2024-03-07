using Application.Contracts.Persistences;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository,
                                            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var findCategory= await _categoryRepository.GetByIdAsync(request.Id);
            if (findCategory != null) {
                var res = _mapper.Map<Domain.Category>(request);
                await _categoryRepository.UpdateAsync(res);
                return Unit.Value;
            }
            else
            {
                throw new Exception($"Category with ID {request.Id} not found.");
            }
        }
    }
}
