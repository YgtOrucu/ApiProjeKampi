using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiProjeContext _apiProjeContext;

        public CategoriesController(ApiProjeContext apiProjeContext)
        {
            _apiProjeContext = apiProjeContext;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _apiProjeContext.Categories.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _apiProjeContext.Categories.Add(category);
            _apiProjeContext.SaveChanges();
            return Ok("Kategori ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var values = _apiProjeContext.Categories.Find(id);
            _apiProjeContext.Categories.Remove(values);
            _apiProjeContext.SaveChanges();
            return Ok("Kategori Silme Başarılı");
        }

        [HttpGet("GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            var values = _apiProjeContext.Categories.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _apiProjeContext.Categories.Update(category);
            _apiProjeContext.SaveChanges();
            return Ok("Kategori Güncellendi");
        }
    }
}
