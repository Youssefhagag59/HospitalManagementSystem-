using AutoMapper;
using HospitalNew.DAL.Data;
using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Helpers;
using HospitalNew.BLL.Interfaces;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalNew.BLL.Services
{
    public class DoctorGenericService : GenericService<Doctor>, IDoctorGenericService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DoctorGenericService(IDoctorRepository doctorRepository, ISpecialtyRepository specialtyRepository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(doctorRepository)
        {
            _doctorRepository = doctorRepository;
            _specialtyRepository = specialtyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Doctor> AddDoctor(DoctorDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            if (!_unitOfWork.specialtyRepository.IsValid(dto.SpecialtyId))
            {
                return null;
            }
            await _unitOfWork.doctorRepository.Add(doctor);
            _unitOfWork.SaveChanges();
            return doctor;
            
        }

        public async Task<Doctor> DeleteDoctorAsync(int id)
        {
            var doc = await _unitOfWork.doctorRepository.GetById(id);
            if (doc == null) 
                return null;
            _unitOfWork.doctorRepository.Delete(doc);
            _unitOfWork.SaveChanges();
            return doc;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDocID(int id)
        {
            return await _unitOfWork.doctorRepository.GetAppointments(id);
        }

        public Task<Doctor> GetDoctorById(int id)
        {
            var doc = _unitOfWork.doctorRepository.GetById(id);
            if (doc == null)
                return null;
            return doc;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorBySpecialty(int specialtyID)
        {
            return await _unitOfWork.doctorRepository.GetBySpecialty(specialtyID);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorDetails()
        {
            return await _unitOfWork.doctorRepository.GetDetails();
        }

        public bool IsValidDoctor(int id)
        {
            return _unitOfWork.doctorRepository.IsValid(id);
        }

        public async Task<ServiceResult<Doctor>> UpdateDoctor(int id, DoctorDto doctor)
        {
            var doc = await _unitOfWork.doctorRepository.GetById(id);
            if (doc == null)
                return ServiceResult<Doctor>.Fail("This doctor doesn't exist");
            if (!_unitOfWork.specialtyRepository.IsValid(doctor.SpecialtyId))
                return ServiceResult<Doctor>.Fail("Invalid specialty");
            var doc2 = _mapper.Map(doctor, doc);
            _unitOfWork.doctorRepository.Update(doc2);
            _unitOfWork.SaveChanges();
            return ServiceResult<Doctor>.Ok(doc2, "Doctor info updated successfully");
        }
    }
}
