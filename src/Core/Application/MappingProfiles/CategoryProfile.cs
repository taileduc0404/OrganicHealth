using Application.Features.Category.Queries.GetAll;
using Application.Features.Category.Queries.GetDetail;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
	public class CategoryProfile:Profile
	{
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<Category, CategoryDetailDto>().ReverseMap();
            //CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            //CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
		}
	}
}
