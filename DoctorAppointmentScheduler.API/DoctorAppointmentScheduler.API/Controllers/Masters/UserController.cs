using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.API.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUser _userRepository;

        public UserController(IUser userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new RegisterResponseDto { Message = "Invalid request payload." });
            }

            var result = _userRepository.RegisterUser(dto);

            if (result.UserId == Guid.Empty)
            {
                // Registration failed (e.g., invalid data / user exists)
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST: api/User
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddUser([FromBody] UserRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("User data cannot be null.");
            }

            var result = _userRepository.AddUser(request);

            if (result.StartsWith("Error"))
            {
                return StatusCode(500, result);
            }

            return Ok(result);
        }

        // GET: api/User
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult<List<UserResponseDto>> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public ActionResult<UserResponseDto> GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UserRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("User data cannot be null.");
            }

            var result = _userRepository.UpdateUser(id, request);

            if (result.StartsWith("User not found"))
            {
                return NotFound(result);
            }

            if (result.StartsWith("Error"))
            {
                return StatusCode(500, result);
            }

            return Ok(result);
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var result = _userRepository.DeleteUser(id);

            if (result.StartsWith("User not found"))
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        // GET: api/User/doctors/{id}
        [HttpGet("doctors/{id}")]
        public ActionResult<UserResponseDto> GetDoctorById(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null || user.Role != "Doctor")
                return NotFound("Doctor not found.");

            // Return full user response
            return Ok(user);
        }


        [HttpGet("doctors")]
        public ActionResult<List<userresponsemin>> GetAllDoctors()
        {
            var doctors = _userRepository.GetAllUsers()
                            .Where(u => u.Role == "Doctor")
                            .Select(u => new userresponsemin
                            {
                                UserId=u.UserId,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Specialization = u.Specialization,
                                Gender = u.Gender
                            })
                            .ToList();

            if (!doctors.Any())
                return NotFound("No doctors found.");

            return Ok(doctors);
        }



    }
}
