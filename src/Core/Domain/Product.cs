using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Product : BaseEntity
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public decimal? Price { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public int? CategoryId { get; set; }
		public virtual Category? Category { get; set; }
	}
}
