using Application.Features.Product.Queries.GetDetail;
using AutoMapper;
using Domain;
using Microsoft.Extensions.Configuration;

namespace Application.Helpers
{
    public class ProductDetailPictureUrlResolver : IValueResolver<Product, ProductDetailDto, string?>
    {
        private readonly IConfiguration _configuration;

        public ProductDetailPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string Resolve(Product source, ProductDetailDto destination, string? destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProductPicture))
            {
                return _configuration["ApiUrl"] + source.ProductPicture;
            }
            return null!;
        }
    }
}
