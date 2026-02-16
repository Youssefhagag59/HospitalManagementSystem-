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
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorGenericService _service;
        private readonly IMapper _mapper;

        public DoctorsController(IMapper mapper, IDoctorGenericService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [Authorize(Roles = "Admin,Doctor,Patient,Manager")]

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var docs = await _service.GetDoctorDetails();
            var doctors = _mapper.Map<IEnumerable<DoctorDetailsDto>>(docs);
            return Ok(doctors);
        }
        [Authorize(Roles = "Admin,Manager")]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doc = await _service.GetDoctorById(id);
            if (doc == null) 
                return NotFound($"No doctor was found with the ID: {id}");
            return Ok(doc);
        }
        [Authorize(Roles = "Admin,Manager,Patient")]

        [HttpGet("GetBySpecialtyId/{specialtyId}")]
        public async Task<IActionResult> GetDoctorBySpecialtyId(int specialtyId)
        {
            var doctors = await _service.GetDoctorBySpecialty(specialtyId);
            return Ok(doctors);
        }
        [Authorize(Roles = "Admin,Manager")]

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromForm] DoctorDto dto)
        {
            var doc = await _service.AddDoctor(dto);
            if (doc == null)
                return NotFound("Invalid specialty");
            return Ok(doc);
            
        }
        [Authorize(Roles = "Admin,Doctor,Manager")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocInfo(int id, [FromForm] DoctorDto dto)
        {
      
            var result = await _service.UpdateDoctor(id, dto);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
            

        }
        [Authorize(Roles = "Admin,Manager")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _service.DeleteDoctorAsync(id);
            if (doctor == null)
                return NotFound($"No doctor exists with the ID: {id}");
            return Ok(doctor);

        }
    }
}
