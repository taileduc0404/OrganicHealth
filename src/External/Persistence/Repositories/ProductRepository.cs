using Application.Contracts.Persistences;
using Domain;
using Persistence.Context;
using Microsoft.Extensions.FileProviders;
using AutoMapper;
using Application.Features.Product.Queries.GetAll;
using Microsoft.EntityFrameworkCore;
using Application.Features.Product.Commands.Create;
using Application.Features.Product.Commands.Update;

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

        public async Task<bool> Product_AddAsync(CreateProductCommand dto)
        {
            // Biến source để lưu đường dẫn của hình ảnh sản phẩm
            var source = "";

            // Kiểm tra xem có hình ảnh sản phẩm không
            if (dto.ProductPicture is not null)
            {
                // Thư mục gốc cho hình ảnh sản phẩm
                var root = "/images/products/";

                // Tạo tên mới cho hình ảnh sản phẩm bằng cách kết hợp Guid và tên tệp của hình ảnh
                var productName = $"{Guid.NewGuid()}" + dto.ProductPicture!.FileName;

                // Kiểm tra xem thư mục chứa hình ảnh có tồn tại không. Nếu không, tạo mới
                if (!Directory.Exists("wwwroot" + root))
                {
                    Directory.CreateDirectory("wwwroot" + root);
                }

                // Xây dựng đường dẫn đầy đủ cho hình ảnh sản phẩm
                source = root + productName;

                // Lưu trữ hình ảnh vào thư mục đã chỉ định
                var picInfo = _fileProvider.GetFileInfo(source);
                var rootPath = picInfo.PhysicalPath;
                using (var fileStream = new FileStream(rootPath!, FileMode.Create))
                {
                    await dto.ProductPicture.CopyToAsync(fileStream);
                }
            }

            // Ánh xạ thông tin từ CreateProductCommand sang đối tượng Product
            var res = _mapper.Map<Product>(dto);

            // Gán đường dẫn của hình ảnh vào thuộc tính ProductPicture của đối tượng Product
            res.ProductPicture = source;

            // Thêm đối tượng Product vào cơ sở dữ liệu và lưu thay đổi
            await _context.products.AddAsync(res);
            await _context.SaveChangesAsync();

            // Trả về true để chỉ ra rằng việc thêm sản phẩm đã được thực hiện thành công
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

            var res = _mapper.Map<List<ProductDto>>(products);

            return res;
        }

        public async Task<bool> UpdateProductWithImageAsync(int id, UpdateProductCommand dto)
        {
            var currentProduct = await _context.products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            //var currentProduct = await _context.products.FindAsync(id);
            if (currentProduct is not null)
            {

                var src = "";
                if (dto.ProductPicture is not null)
                {
                    var root = "/images/products/";
                    var productName = $"{Guid.NewGuid()}" + dto.ProductPicture.FileName;
                    if (!Directory.Exists("wwwroot" + root))
                    {
                        Directory.CreateDirectory("wwwroot" + root);
                    }

                    src = root + productName;
                    var picInfo = _fileProvider.GetFileInfo(src);
                    var rootPath = picInfo.PhysicalPath;
                    using (var fileStream = new FileStream(rootPath!, FileMode.Create))
                    {
                        await dto.ProductPicture!.CopyToAsync(fileStream);
                    }
                }
                //remove old picture
                if (!string.IsNullOrEmpty(currentProduct.ProductPicture))
                {
                    //delete old picture
                    var picInfo = _fileProvider.GetFileInfo(currentProduct.ProductPicture);
                    var rootPath = picInfo.PhysicalPath;
                    System.IO.File.Delete(rootPath!);
                }

                //update product
                var res = _mapper.Map(dto, currentProduct);
                res.ProductPicture = src;
                res.Id = id;
                _context.products.Update(res);
                await _context.SaveChangesAsync();


                return true;

            }
            return false;
        }
    }
}
