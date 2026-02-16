using AutoMapper;
using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalNew.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtiesService _specialtiesService;
        private readonly IMapper _mapper;

        public SpecialtiesController(ISpecialtiesService specialtiesService, IMapper mapper)
        {
            _specialtiesService = specialtiesService;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin,Patient,Manager")]

        [HttpGet]
        public async Task<IActionResult> GetAllSpecialties()
        {
            var specialties = await _specialtiesService.GetAll();
            return Ok(specialties);
        }
        [Authorize(Roles = "Admin,Manager")]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialtyById(int id)
        {
            var spec = await _specialtiesService.GetById(id);
            if (spec == null)
                return NotFound($"No specialty was found with the ID: {id}");
            return Ok(spec);
        }
        [Authorize(Roles = "Admin,Manager")]

        [HttpPost]
        public async Task<IActionResult> AddSpecialty([FromForm] SpecialtyDto specialty)
        {
            await _specialtiesService.AddSpecialty(specialty);
            return Ok(specialty);
        }
        [Authorize(Roles = "Admin,Manager")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpecialty(int id, [FromForm] SpecialtyDto specialty)
        {
            var result =await _specialtiesService.UpdateSpecialty(id, specialty);
            if (specialty == null)
                return NotFound($"No specialty was found with the ID: {id}");
            return Ok(result);
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialty(int id)
        {
            var specialty = await _specialtiesService.DeleteSpecialty(id);
            if (specialty == null) 
                return NotFound($"No specialty was found with the ID: {id}");
            return Ok(specialty);
        }
    }
}
