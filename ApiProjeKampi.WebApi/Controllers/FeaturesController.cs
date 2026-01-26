using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.FeatureDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiProjeContext _apiProjeContext;
        public FeaturesController(IMapper mapper, ApiProjeContext apiProjeContext)
        {
            _mapper = mapper;
            _apiProjeContext = apiProjeContext;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _apiProjeContext.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var values = _mapper.Map<Feature>(createFeatureDto);
            _apiProjeContext.Features.Add(values);
            _apiProjeContext.SaveChanges();
            return Ok("Ekleme başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values = _apiProjeContext.Features.Find(id);
            _apiProjeContext.Features.Remove(values);
            _apiProjeContext.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetByIdFeature")]
        public IActionResult GetByIdFeature(int id)
        {
            var values = _apiProjeContext.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeatureDto>(values));
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<Feature>(updateFeatureDto);
            _apiProjeContext.Features.Update(values);
            _apiProjeContext.SaveChanges();
            return Ok("Güncelleme başarılı");
        }
    }
}
