using AutoMapper;
using HospitalNew.DAL.Data;
using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Interfaces;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HospitalNew.BLL.Services
{
    public class UsersService : GenericService<User>, IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthSerice _authSerice;
        private readonly IUnitOfWork _unitOfWork;


        public UsersService(IUserRepository userRepository, IMapper mapper, IAuthSerice authSerice, IUnitOfWork unitOfWork) : base(userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authSerice = authSerice;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> AddUser(UserDetailsDto dto)
        {
            var user = _mapper.Map<User>(dto); // Mapping DTO to User entity 
            await _unitOfWork.userRepository.Add(user);
            _unitOfWork.SaveChanges();
            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _unitOfWork.userRepository.GetById(id);
            if (user == null) 
                return null;
            _unitOfWork.userRepository.Delete(user);
            _unitOfWork.SaveChanges();
            return user;
        }

        public User IsValidUser(string name)
        {
            return _unitOfWork.userRepository.IsValid(name);
        }

        public string ValidateUser(UserDto dto)
        {
            var user = _unitOfWork.userRepository.IsValid(dto.Name);
            if (user == null)
                return "Invalid name";
            //var hash = new PasswordHasher<User>();
            //PasswordVerificationResult verfiy = hash.VerifyHashedPassword(user, user.HashedPassword, dto.HashedPassword);
            //if (verfiy == 0)
            //    return "Invalid password";
            var token = _authSerice.GenerateToken(user);
            return token;

        }
    }
}
