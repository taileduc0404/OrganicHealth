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
			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.Name).HasMaxLength(30).IsRequired();


			//seed data
			builder.HasData(

				new Category { Id = 1, Name = "Category 1" },
				new Category { Id = 2, Name = "Category 2" },
				new Category { Id = 3, Name = "Category 3" },
				new Category { Id = 4, Name = "Category 4" }
			);
		}
	}
}
