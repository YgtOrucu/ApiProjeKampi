using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.CategoryDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiProjeContext _apiProjeContext;
        private readonly IMapper _mapper;

        public CategoriesController(ApiProjeContext apiProjeContext, IMapper mapper)
        {
            _apiProjeContext = apiProjeContext;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _apiProjeContext.Categories.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
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
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _apiProjeContext.Categories.Update(category);
            _apiProjeContext.SaveChanges();
            return Ok("Kategori Güncellendi");
        }
    }
}
