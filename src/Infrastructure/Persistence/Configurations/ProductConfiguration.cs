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
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasData(
				new Product
				{
					Id = 1,
					Name = "Cà chua",
					Description = "Đây là cà chua",
					CreatedDate = DateTime.Now,
					CategoryId = 1,
					Price = 200,

				},
				new Product
				{
					Id = 2,
					Name = "Bắp cải",
					Description = "Đây là bắp cải",
					CreatedDate = DateTime.Now,
					CategoryId = 2,
					Price = 100,
				}
				);
		}
	}
}
