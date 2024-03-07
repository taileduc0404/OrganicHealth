using Application.Features.Category.Queries.GetDetail;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            // Gọi API để lấy dữ liệu
            var response = await _httpClient.GetAsync("https://localhost:44338/api/Category/GetAll/GetAll");
            response.EnsureSuccessStatusCode();

            // Đọc dữ liệu từ API
            var content = await response.Content.ReadAsStringAsync();

            // Chuyển đổi nội dung JSON thành đối tượng
            var data = System.Text.Json.JsonSerializer.Deserialize<List<CategoryVM>>(content);

            // Truyền dữ liệu cho view
            return View(data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<CategoryDetailDto>> GetById(int id)
        {
            // Gọi API để lấy dữ liệu dựa trên id
            var response = await _httpClient.GetAsync($"https://localhost:44338/api/Category/GetAll/GetById/{id}");
            response.EnsureSuccessStatusCode();

            // Đọc dữ liệu từ API
            var content = await response.Content.ReadAsStringAsync();

            // Chuyển đổi nội dung JSON thành đối tượng
            var category = System.Text.Json.JsonSerializer.Deserialize<CategoryDetailDto>(content);

            if (category == null)
            {
                return NotFound(); // Trả về 404 Not Found nếu không tìm thấy
            }

            return Ok(category);
        }
    }
}
