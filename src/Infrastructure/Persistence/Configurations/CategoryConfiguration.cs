using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
			builder.HasData(
				new Category
				{
					Id = 1,
					Name = "Trái cây"
				},
				new Category
				{
					Id = 2,
					Name = "Rau củ"
				}
				);
		}
	}
}
