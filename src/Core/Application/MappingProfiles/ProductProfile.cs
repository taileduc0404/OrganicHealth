using Application.Features.Category.Commands.Create;
using Application.Features.Category.Commands.Update;
using Application.Features.Category.Queries.GetAll;
using Application.Features.Category.Queries.GetDetail;
using Application.Features.Product.Commands.Create;
using Application.Features.Product.Commands.Update;
using Application.Features.Product.Queries.GetAll;
using Application.Features.Product.Queries.GetDetail;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<Product, ProductDetailDto>().ReverseMap();
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();
        }
    }
}
