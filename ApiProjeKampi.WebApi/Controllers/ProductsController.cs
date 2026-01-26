using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ProductDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiProjeContext _apiProjeContext;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiProjeContext apiProjeContext, IMapper mapper)
        {
            _validator = validator;
            _apiProjeContext = apiProjeContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _apiProjeContext.Products.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var result = _validator.Validate(product);
            if (result.IsValid)
            {
                _apiProjeContext.Products.Add(product);
                _apiProjeContext.SaveChanges();
                return Ok("Ekleme başarılı");
            }
            else
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));
            }
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _apiProjeContext.Products.Find(id);
            _apiProjeContext.Products.Remove(values);
            _apiProjeContext.SaveChanges();
            return Ok("Silme başarılı");
        }
        [HttpGet("GetByIdProduct")]
        public ActionResult GetByIdProduct(int id)
        {
            var values = _apiProjeContext.Products.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            _apiProjeContext.Products.Update(product);
            _apiProjeContext.SaveChanges();
            return Ok("Güncelleme başarılı");
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            _apiProjeContext.Products.Add(values);
            _apiProjeContext.SaveChanges();
            return Ok("Ekleme başarılı");
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _apiProjeContext.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(values));
        }
    }

}
