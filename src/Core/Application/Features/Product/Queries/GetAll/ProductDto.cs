
namespace Application.Features.Product.Queries.GetAll
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ProductPicture { get; set; }
        public decimal? Price { get; set; }
        public int CategoryId { get; set; }
    }
}
