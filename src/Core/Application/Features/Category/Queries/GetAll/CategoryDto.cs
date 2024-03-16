

namespace Application.Features.Category.Queries.GetAll
{
	public class CategoryDto
	{
        public int Id { get; set; }
        public string? Name { get; set; }
		public virtual ICollection<Domain.Product> Products { get; set; } = new HashSet<Domain.Product>();
	}
}
