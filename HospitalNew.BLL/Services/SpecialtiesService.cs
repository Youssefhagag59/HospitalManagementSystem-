using AutoMapper;
using HospitalNew.DAL.Data;
using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Interfaces;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalNew.BLL.Services
{
    public class SpecialtiesService : GenericService<Specialty>, ISpecialtiesService
    {
        private readonly ISpecialtyRepository _specialtyRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        

        public SpecialtiesService(ISpecialtyRepository specialtyRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Specialty> AddSpecialty(SpecialtyDto dto)
        {
            var specialty = _mapper.Map<Specialty>(dto);
            await _unitOfWork.specialtyRepository.Add(specialty);
            _unitOfWork.SaveChanges();
            return specialty;
        }

        public async Task<Specialty> DeleteSpecialty(int id)
        {
            var specialty = await _unitOfWork.specialtyRepository.GetById(id);
            if (specialty == null)
                return null;
            _unitOfWork.specialtyRepository.Delete(specialty);
            _unitOfWork.SaveChanges();
            return specialty;
        }

        public async Task<Specialty> GetSpecialtyById(int id)
        {
            var spec = await _unitOfWork.specialtyRepository.GetById(id);
            if (spec == null) 
                return null;
            return spec;
        }

        public bool IsValidSpecialty(int id)
        {
            return _unitOfWork.specialtyRepository.IsValid(id);
        }

        public async Task<Specialty> UpdateSpecialty(int id, SpecialtyDto specialty)
        {
            var spec =await _unitOfWork.specialtyRepository.GetById(id);
            if (spec == null)
                return null;
            _mapper.Map(specialty, spec);
            _unitOfWork.specialtyRepository.Update(spec);
            _unitOfWork.SaveChanges();
            return spec;
        }
    }
}
