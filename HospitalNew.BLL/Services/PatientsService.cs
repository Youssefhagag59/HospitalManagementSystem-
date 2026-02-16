using AutoMapper;
using HospitalNew.DAL.Data;
using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Interfaces;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HospitalNew.BLL.Services
{
    public class PatientsService : GenericService<Patient> , IPatientsService
    {
        private readonly IPatientRepository _patientRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        

        public PatientsService(IPatientRepository patientRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(patientRepository)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Patient> AddPatient(PatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            await _unitOfWork.patientRepository.Add(patient);
            _unitOfWork.SaveChanges();
            return patient;
        }

        public async Task<Patient> DeletePatient(int id)
        {
            var patient = await _unitOfWork.patientRepository.GetById(id);
            if (patient == null)
                return null;
            _unitOfWork.patientRepository.Delete(patient);
            _unitOfWork.SaveChanges();
            return patient;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientID(int id)
        {
            return await _unitOfWork.patientRepository.GetAppointments(id);
        }

        public bool IsValidPatient(int id)
        {
            return _unitOfWork.patientRepository.IsValid(id);
        }

        public async Task<Patient> UpdatePatientInfo(int id, PatientDto patient)
        {
            var pat =await _unitOfWork.patientRepository.GetById(id);
            if(pat == null) 
                return null;
            _mapper.Map(patient, pat);
            _unitOfWork.patientRepository.Update(pat);
            _unitOfWork.SaveChanges();
            return pat;
        }
    }
}
