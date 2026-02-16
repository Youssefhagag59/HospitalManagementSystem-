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
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsService _patientsService;
        private readonly IMapper _mapper;

        public PatientsController(IMapper mapper, IPatientsService patientsService)
        {
            _mapper = mapper;
            _patientsService = patientsService;
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientsService.GetAll();
            return Ok(patients);
        }
        [Authorize(Roles = "Admin")]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientsService.GetById(id);
            return Ok(patient);
        }
        [Authorize(Roles = "Admin,Patient")]

        [HttpGet("Appointments/{patientID}")]
        public async Task<IActionResult> GetAppointmentsForPatient(int patientID)
        {
            var appointments = await _patientsService.GetAppointmentsByPatientID(patientID);
            var apps = _mapper.Map<IEnumerable<AppointmentDetailsDto>>(appointments);
            return Ok(apps);
        }
        [Authorize(Roles = "Admin,Receptionist")]

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromForm] PatientDto dto)
        {
            await _patientsService.AddPatient(dto);
            return Ok(dto);
        }
        [Authorize(Roles = "Admin,Patient")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id,[FromForm] PatientDto dto)
        {
            var result =await _patientsService.UpdatePatientInfo(id, dto);
            if (result == null)
                return NotFound($"No patient was found with the ID: {id}");
            return Ok(result);

        }
        [Authorize(Roles = "Admin,Receptionist")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _patientsService.DeletePatient(id);
            if(patient == null)
                return NotFound($"No patient was found with the ID: {id}");
            return Ok(patient);

        }
    }
}
