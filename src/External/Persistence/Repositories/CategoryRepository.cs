using Application.Contracts.Persistences;
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

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        => await _context.products.Where(x => x.CategoryId == categoryId).ToListAsync();
    }
}
