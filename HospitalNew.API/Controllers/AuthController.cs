using AutoMapper;
using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalNew.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IAuthSerice _authSerice;
        private readonly IMapper _mapper;
        public AuthController(IUsersService usersService, IAuthSerice authSerice,IMapper mapper)
        {
            _authSerice = authSerice;
            _usersService = usersService;
            _mapper = mapper;
        }
        
        [HttpPost("LogIn")] 
        public IActionResult Login([FromBody] UserDto dto) 
        {
            var result = _usersService.ValidateUser(dto);
            return Ok(result);

        }
        
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UserDetailsDto dto)
        {
            var add = await _usersService.AddUser(dto);
            return Ok("registed");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user =await _usersService.DeleteUser(id);
            if (user == null)
                return BadRequest("User doesn't exist");
            return Ok(user);
            
        }
    }
}
