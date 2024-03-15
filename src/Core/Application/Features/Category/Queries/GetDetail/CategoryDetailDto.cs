using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetDetail
{
	public class CategoryDetailDto
	{
        public int Id { get; set; }
        public string? Name { get; set; }
		//public virtual ICollection<Domain.Product> Products { get; set; } = new HashSet<Domain.Product>();
	}
}
