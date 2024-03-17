using Microsoft.AspNetCore.Http;
namespace Application.DTOs.ProductDtos
{
    public class AddProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        //public string? ProductPicture { get; set; }
        public int CategoryId { get; set; } 
        public IFormFile? Image {  get; set; }
    }
}
