using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ServiceDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiProjeContext _context;
        private readonly IMapper _mapper;

        public ServicesController(ApiProjeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            return Ok(_mapper.Map<List<ResultServiceDto>>(values));
        }

        [HttpPost]
        public IActionResult ServiceCreate(CreateServiceDto createServiceDto)
        {
            var values = _mapper.Map<Service>(createServiceDto);
            _context.Services.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme Başarılı");

        }
        [HttpDelete]
        public IActionResult ServiceDelete(int id)
        {
            var values = _context.Services.Find(id);
            _context.Services.Remove(values);
            _context.SaveChanges();
            return Ok("Silme Başarılı");
        }
        [HttpGet("ServiceGetById")]
        public IActionResult ServiceGetById(int id)
        {
            var values = _context.Services.Find(id);
            return Ok(_mapper.Map<GetByIdServiceDto>(values));
        }
        [HttpPut]
        public IActionResult ServiceUpdate(UpdateServiceDto updateServiceDto)
        {
            var values = _mapper.Map<Service>(updateServiceDto);
            _context.Services.Update(values);
            _context.SaveChanges();
            return Ok("Güncelleme Başarılı");
        }
    }
}
