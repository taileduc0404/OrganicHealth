using Application.Contracts.Persistences;
using Application.Features.Product.Queries.GetAll;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<ProductDto>> GetCategoryListWithProductAsync(int categoryId)
        {
            var response = await _context.products.Where(x => x.CategoryId == categoryId).ToListAsync();

            return _mapper.Map<List<ProductDto>>(response);
        }
        public async Task<List<Product>> GetCategoryDetailWithProductAsync(int categoryId)
        {

            var response = await _context.products.Where(x => x.CategoryId == categoryId).ToListAsync();

            return _mapper.Map<List<Product>>(response);
        }
    }
}
