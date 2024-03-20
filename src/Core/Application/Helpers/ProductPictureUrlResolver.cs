using AutoMapper;
using Application.Features.Product.Queries.GetDetail;
using Domain;
using Microsoft.Extensions.Configuration;
using Application.Features.Product.Queries.GetAll;

namespace Application.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductDto, string?>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string Resolve(Product source, ProductDto destination, string? destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProductPicture))
            {
                return _configuration["ApiUrl"] + source.ProductPicture;
            }
            return null!;
        }
    }
}
