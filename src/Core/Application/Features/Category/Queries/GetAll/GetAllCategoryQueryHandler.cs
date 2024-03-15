using Application.Contracts.Persistences;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetAll
{
	public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;

		public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository,
											IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
		{
			try
			{
                var allCategory = await _categoryRepository.GetAsync();

                return _mapper.Map<List<CategoryDto>>(allCategory);
            }
			catch (Exception)
			{
				throw;
			}	
		}
	}
}
