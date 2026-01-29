using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.TestimonialDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiProjeContext _apiProjeContext;

        public TestimonialsController(IMapper mapper, ApiProjeContext apiProjeContext)
        {
            _mapper = mapper;
            _apiProjeContext = apiProjeContext;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _apiProjeContext.Testimonials.ToList();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(values));
        }

        [HttpPost]
        public IActionResult TestimonialCreate(CreateTestimonialDto createTestimonialDto)
        {
            var values = _mapper.Map<Testimonial>(createTestimonialDto);
            _apiProjeContext.Testimonials.Add(values);
            _apiProjeContext.SaveChanges();
            return Ok("Ekleme başarılı");
        }
        [HttpDelete]
        public IActionResult TestimonialDelete(int id)
        {
            var value = _apiProjeContext.Testimonials.Find(id);
            _apiProjeContext.Testimonials.Remove(value);
            _apiProjeContext.SaveChanges();
            return Ok("Silem Başarılı");
        }
        [HttpGet("GetByIdTestimonial")]
        public IActionResult GetByIdTestimonial(int id)
        {
            var values = _apiProjeContext.Testimonials.Find(id);
            return Ok(_mapper.Map<GetByIdTestimonialDto>(values));
        }
        [HttpPut]
        public IActionResult TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
        {
            var values = _mapper.Map<Testimonial>(updateTestimonialDto);
            _apiProjeContext.Testimonials.Update(values);
            _apiProjeContext.SaveChanges();
            return Ok("Güncelleme başarılı");
        }
    }
}
