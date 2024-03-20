using Application.Features.Product.Commands.Create;
using Application.Features.Product.Commands.Update;
using Application.Features.Product.Queries.GetAll;
using Application.Features.Product.Queries.GetDetail;
using Application.Helpers;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            //CreateMap<Product, ProductDto>()
            //    .ForMember(x => x.CategoryId, a => a.MapFrom(s => s.CategoryId))
            //    .ForMember(x => x.ProductPicture, a => a.MapFrom<ProductPictureUrlResolver>())
            //    .ReverseMap();
            CreateMap<Product, ProductDetailDto>().ReverseMap();
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();
        }
    }
}
