using Domain.Common;

namespace Domain
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
