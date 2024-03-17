using Application.Contracts.Persistences;
using Domain;
using Persistence.Context;
using Microsoft.Extensions.FileProviders;
using AutoMapper;
using Application.Features.Product.Queries.GetAll;
using Microsoft.EntityFrameworkCore;
using Application.Features.Product.Commands.Create;

namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IFileProvider fileProvider, IMapper mapper) : base(context)
        {
            _context = context;
            _fileProvider = fileProvider;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(CreateProductCommand dto)
        {
            var source = "";
            if (dto.ProductPicture is not null)
            {
                var root = "/images/products/";
                var productName = $"{Guid.NewGuid()}" + dto.ProductPicture!.FileName;
                if (!Directory.Exists("wwwroot" + root)) {
                    Directory.CreateDirectory("wwwroot" + root);
                }
                source = root + productName;
                var picInfo = _fileProvider.GetFileInfo(source);
                var rootPath = picInfo.PhysicalPath;
                using (var fileStream = new FileStream(rootPath!, FileMode.Create))
                {
                    await dto.ProductPicture.CopyToAsync(fileStream);
                }
            }

            var res = _mapper.Map<Product>(dto);
            res.ProductPicture = source;
            await _context.products.AddAsync(res);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> DeleteAsyncWithPicture(int id)
        {
            throw new NotImplementedException();
        }
            
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _context.products
                .Include(p => p.CategoryId)
                .AsNoTracking()
                .ToListAsync();

            var res = _mapper.Map<IEnumerable<ProductDto>>(products);

            return res;
        }

        public Task<bool> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
